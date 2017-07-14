using MyAD.DBAdapter;
using MyAD.Log;
using MyAD.POCO;
using System;
using System.Collections.Generic;

namespace MyAD.Forms
{
    public interface IDataCollection
    {
        IEnumerable<UserLockouts> GetPage(int page);

        Dictionary<int, IEnumerable<UserLockouts>> Cached { get; }

        //int CurrentPage { get; set; }
        int LastPage { get; }

        int RecordCount { get; }
        bool IsDataFiltered { get; }
        bool IsInnitalized { get; }
        string FilterString { get; }
        object[] FilterParam { get; }

        //bool IsAtLastPage { get; }
        void RefreshData();
    }

    public class DataCollection : IDataCollection, IDisposable
    {
        private IDBAdapter _adapter;
        private ILogger _logger;

        public DataCollection(IDBAdapter adapter)
        {
            _logger = LogManager.GetLogger(GetType());
            _adapter = adapter;
            RefreshData(); //refresh data will move current page/collection to 1
        }

        public DataCollection(IDBAdapter adapter, string filter, object[] param)
        {
            _logger = LogManager.GetLogger(GetType());
            _adapter = adapter;
            FilterString = filter;
            FilterParam = param;
            IsDataFiltered = true;
            RefreshData();
        }

        //private int _currentPage;
        //public int CurrentPage
        //{
        //    get
        //    {
        //        return _currentPage;
        //    }
        //    set
        //    {
        //        if (value > LastPage) throw new InvalidOperationException("invalid page");
        //        _currentPage = value;
        //    }
        //}

        public int LastPage { get; private set; }

        public int RecordCount { get; private set; }

        public string FilterString { get; private set; }

        public object[] FilterParam { get; private set; }

        //public bool IsAtLastPage
        //{
        //    get
        //    {
        //        return CurrentPage == LastPage;
        //    }
        //}

        public bool IsDataFiltered { get; private set; }

        public Dictionary<int, IEnumerable<UserLockouts>> Cached { get; private set; }
            = new Dictionary<int, IEnumerable<UserLockouts>>();

        public bool IsInnitalized { get; private set; } = false;

        public void Dispose()
        {
            _adapter.Dispose();
            _adapter = null;
        }

        public IEnumerable<UserLockouts> GetPage(int page)
        {
            if (!IsInnitalized) throw new InvalidOperationException("call RefreshData() first!");
            if (page > LastPage && !IsInnitalized) throw new InvalidOperationException("invalid page");
            if (Cached.ContainsKey(page))
            {
                var collection = Cached[page];
                return collection;
            }
            else
            {
                var list = new List<UserLockouts>();
                _adapter.BeginDBAccess();
                if (IsDataFiltered)
                {
                    if (string.IsNullOrEmpty(FilterString) || FilterParam == null) throw new InvalidOperationException("filter is not set");
                    var collection = _adapter.GetData(FilterString, FilterParam,
                    (page - 1) * _adapter.RecordPerPage, _adapter.RecordPerPage, out int total);
                    //bc of lazy or smt if we dont clone the UserLockouts when endDB is called our UserLockouts will be lost
                    foreach (var item in collection)
                    {
                        list.Add(item.Clone());
                    }
                    Cached.Add(page, list);
                    RecordCount = total;
                    LastPage = Helper.HelperClass.CalculatePage(RecordCount, _adapter.RecordPerPage);
                }
                else
                {
                    var collection = _adapter.GetData((page - 1) * _adapter.RecordPerPage, _adapter.RecordPerPage, out int total);
                    foreach (var item in collection)
                    {
                        list.Add(item.Clone());
                    }
                    Cached.Add(page, list);
                    RecordCount = total;
                    LastPage = Helper.HelperClass.CalculatePage(RecordCount, _adapter.RecordPerPage);
                }
                _adapter.EndDBAccess();
                return list;
            }
        }

        /// <summary>
        /// refresh data will clear cached data
        /// </summary>
        public void RefreshData()
        {
            //dont really see many reason to call this often
            //bc RecordCount & LasPage is updated every time a new page is request
            Cached.Clear();
            IsInnitalized = true;
            GetPage(1);
        }
    }
}