using System;
using System.Collections.Generic;


namespace MyAD.POCO
{
    public struct UserLockouts
    {
        public int Id { get; set; }
        public string ADName { get; set; }
        public DateTime UnlockTime { get; set; }
        public string Unlocker { get; set; }

        public UserLockouts(int id, string adName, DateTime time, string unlocker)
        {
            Id = id;
            ADName = adName;
            UnlockTime = time;
            Unlocker = unlocker;
        }

        public UserLockouts Clone()
        {
            return new UserLockouts()
            {
                Id = this.Id,
                ADName = this.ADName,
                Unlocker = this.Unlocker,
                UnlockTime = this.UnlockTime
            };
        }

        //public (int id, string adName, DateTime unlockTime, string unlocker) ToTuple()
        //{
        //    return (Id, ADName, UnlockTime, Unlocker);
        //}

        public object[] GetDataArray()
        {
            var list = new List<object> {Id, ADName, UnlockTime, Unlocker};
            return list.ToArray();
        }

        public static void BuildDynamicLinqFilter(string adName, DateTime unlockDate, string unlocker, out string filter, out object[] param)
        {
            filter = string.Empty;
            var paramList = new List<object>();
            int paramIndex = 0;
            if (!string.IsNullOrEmpty(adName))
            {
                filter = string.Format("ADName = @{0}", paramIndex);
                paramIndex++;
                paramList.Add(adName);
            }
            if (!string.IsNullOrEmpty(unlocker))
            {
                if (filter != string.Empty) filter += " And ";
                filter += string.Format("Unlocker = @{0}", paramIndex);
                paramIndex++;
                paramList.Add(unlocker);
            }
            if (unlockDate != DateTime.MinValue)
            {
                if (filter != string.Empty) filter += " And ";
                filter += string.Format("UnlockTime = @{0}", paramIndex);
                paramList.Add(unlockDate);
            }
            param = paramList.ToArray();
        }
    }
}