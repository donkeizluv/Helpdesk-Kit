using MyAD.POCO;
using System;
using System.Collections.Generic;

namespace MyAD.DBAdapter
{
    public interface IDBAdapter : IDisposable
    {
        int RecordPerPage { get; set; }

        //int GetMaxPage(); //too specific
        int GetAllRecordCount();

        void LogUnlockAction(string adName, string unlocker);

        IEnumerable<UserLockouts> GetData(int from, int take, out int totalRecord);

        //IEnumerable<UserLockouts> GetDataPage(int page);
        IEnumerable<UserLockouts> GetData(string filter, object[] filterParam, out int totalRecord); //dynamic linq

        IEnumerable<UserLockouts> GetData(string filter, object[] filterParam, int from, int take, out int totalRecord);

        IEnumerable<UserLockouts> GetData(string sql); // incase of sql db

        void BeginDBAccess(bool readMode = false); //shit to deal with LiteDB design

        void EndDBAccess();
    }
}