using LiteDB;
using MyAD.Log;
using MyAD.POCO;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic;

namespace MyAD.DBAdapter
{
    public class LiteDBAdapter : IDBAdapter
    {
        private const string ColName = "lockouts";

        //public bool LiteDBJournaling = true; //faster write if disable
        //this shit has problem with quick creation of LiteDatase object
        //author suggests singleton instance
        //also, "Shared" read mode seems to be working but it has something to do with Net35
        //some portion of the LiteDB code seem to be greyed out with along with Shared mode so its not so safe to do.
        private static LiteDatabase _db;

        private readonly ILogger _logger;
        public int RecordPerPage { get; set; } = 100;

        public bool IsDBOpen => _db != null;

        public string CollectionName { get; private set; }
        public string Path { get; private set; }

        public LiteDBAdapter(string dbPath, string collectionName)
        {
            _logger = LogManager.GetLogger(GetType());
            CollectionName = collectionName;
            Path = dbPath;
        }

        public void BeginDBAccess(bool readMode = true)
        {
            _logger.Log("accessing db....");
            if (IsDBOpen) throw new InvalidOperationException(string.Format("db is currently open"));
            _db = readMode ? new LiteDatabase(GetCommitConnectionString(Path)) : new LiteDatabase(GetReadOnlyConnectionString(Path));
        }

        public void EndDBAccess()
        {
            _logger.Log("closing db....");
            if (!IsDBOpen) throw new InvalidOperationException("theres currently no db opened");
            _db.Dispose();
            _db = null;
        }

        private string GetCommitConnectionString(string path)
        {
            return $"filename={path}; Timeout=10";
        }

        private string GetReadOnlyConnectionString(string path)
        {
            return $"filename={path}; Timeout=10; Mode=ReadOnly";
        }

        /// <summary>
        /// get data
        /// </summary>
        /// <param name="lim">limit</param>
        /// <returns></returns>
        public IEnumerable<UserLockouts> GetData(int from, int take, out int totalRecord)
        {
            var db = GetCurrentOpeningDB();
            var col = db.GetCollection<UserLockouts>(ColName);
            totalRecord = col.Count(Query.All());
            return col.Find(Query.All(), from, take);
        }

        public IEnumerable<UserLockouts> GetData(string filter, object[] filterParam, out int totalRecord)
        {
            //if these get data methods get call right after each other IOEx is thrown
            //but this should not happen in real usage
            var db = GetCurrentOpeningDB();
            var col = db.GetCollection<UserLockouts>(ColName);
            var collection = col.FindAll().Where(filter, filterParam);
            totalRecord = collection.Count();
            return collection;
        }

        public IEnumerable<UserLockouts> GetData(string filter, object[] filterParam, int from, int take, out int totalRecord)
        {
            //if these get data methods get call right after each other IOEx is thrown
            //but this should not happen in real usage
            var db = GetCurrentOpeningDB();
            var col = db.GetCollection<UserLockouts>(ColName);
            var collection = col.Find(Query.All(), from, take).Where(filter, filterParam);
            totalRecord = collection.Count();
            return collection;
        }

        private LiteDatabase GetCurrentOpeningDB()
        {
            return IsDBOpen ? _db : throw new InvalidOperationException("theres currently no db opened"); //first time using C#7 feat yay!
            //if (!IsDBOpen) throw new InvalidOperationException("theres currently no db opened");
            //return _db;
        }

        public IEnumerable<UserLockouts> GetData(string sql)
        {
            throw new NotImplementedException();
        }

        public void LogUnlockAction(string adName, string unlocker)
        {
            // Open database (or create if doesn't exist)

            var db = GetCurrentOpeningDB();
            // Get a collection (or create, if doesn't exist)
            var col = db.GetCollection<UserLockouts>(ColName);
            // Create your new customer instance
            var unlock = new UserLockouts
            {
                ADName = adName,
                UnlockTime = DateTime.Now,
                Unlocker = unlocker
            };
            // Insert new customer document (Id will be auto-incremented)
            col.Insert(unlock);
            // Index document using document Name property
            col.EnsureIndex(x => x.ADName);
            _logger.Log($"unlocked: {adName} by {unlocker} is logged");
        }

        //too specific
        //let the user do these

        //public int GetMaxPage()
        //{
        //    var db = GetCurrentOpeningDB();
        //    var col = db.GetCollection<UserLockouts>(COL_NAME);
        //    return Helper.HelperClass.CalculatePage(GetRecordCount(), RecordPerPage);
        //}

        //public IEnumerable<UserLockouts> GetDataPage(int page)
        //{
        //    if(page < 1) throw new InvalidOperationException(string.Format("requested page {0} is invalid", page));
        //    return GetData((page - 1) * RecordPerPage, RecordPerPage);
        //}

        public int GetAllRecordCount()
        {
            var db = GetCurrentOpeningDB();
            var col = db.GetCollection<UserLockouts>(ColName);
            return col.Count();
        }

        public void Dispose()
        {
            _db.Dispose();
            _db = null;
        }
    }
}