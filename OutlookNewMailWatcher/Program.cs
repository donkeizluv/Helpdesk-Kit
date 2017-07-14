using MyAD.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookNewMailWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var outlook = new OutlookWrapper();
            outlook.MonitorIncomingEmail("luu.nhat-hong@hdsaison.com.vn", "Helpdesk");
            outlook.IncommingEmail += Outlook_IncommingEmail;
            Console.WriteLine("Working.....");
            Console.WriteLine("enter to stop monitor");
            Console.ReadLine();
            outlook.StopMonitorIncomingEmail();
            Console.WriteLine("Stopped monitoring....");
            Console.ReadLine();
        }

        private static void Outlook_IncommingEmail(object sender, NewEnailEventArgs e)
        {
            Console.WriteLine(e.Email.Subject);
            Console.WriteLine(e.ContainAd? e.Ad : "no");
        }
    }
}
