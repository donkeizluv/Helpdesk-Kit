using MyAD.DBAdapter;
using System;

namespace MyAD.Forms
{
    public static class DataCollectionManager
    {
        public static DataCollection UnFilteredData { get; set; }
        public static DataCollection FilteredData { get; set; }
        public static IDBAdapter DBAdapter { get; set; }

        public static void Innit(IDBAdapter adapter)
        {
            DBAdapter = adapter;
            UnFilteredData = new DataCollection(DBAdapter);
        }

        public static void CreateUnFilteredData()
        {
            if (DBAdapter == null) throw new InvalidOperationException("innit first");
            UnFilteredData = new DataCollection(DBAdapter);
        }

        public static void CreateFilteredData(string filter, object[] param)
        {
            if (DBAdapter == null) throw new InvalidOperationException("innit first");
            FilteredData = new DataCollection(DBAdapter, filter, param);
        }
    }
}