﻿using MyAD.Forms;
using System;
using System.Collections.Generic;

namespace MyAD.Log
{
    public static class LogManager
    {
        public static LogViewer LogViewer { get; set; }
        private const string LogFileName = "log.txt";
        private static readonly List<string> CacheLogs = new List<string>();
        private static readonly List<ILogger> ListLogger = new List<ILogger>();
        private static readonly object WriteLogLocker = new object();
        public static bool WriteToFile { get; set; } = false;

        static LogManager()
        {
            IsConsole = false;
        }

        //private static string LogPath => string.Format(@"{0}\{1}", EmailService.AssemblyDirectory, LogFileName);
        public static bool IsConsole { get; set; }

        public static ILogger GetLogger(Type t)
        {
            var logger = new SimpleLogger(t);
            ListLogger.Add(logger);
            logger.OnNewLog += Logger_OnNewLog;
            return logger;
        }

        private static void Logger_OnNewLog(ILogger log, NewLogEventArgs e)
        {
            if (e.Log == string.Empty) return;
            lock (WriteLogLocker)
            {
                WriteLog(e.Log);
            }
        }

        private static void WriteLog(string log)
        {
            if (IsConsole)
                Console.WriteLine(FormatLog(log));
            if (LogViewer == null)
                throw new NullReferenceException("LogViewer is not set.");
            LogViewer.Log(FormatLog(log));
            //try
            //{
            //    if (CacheLogs.Count > 0) //try to write failed log first
            //    {
            //        File.AppendAllLines(LogPath, CacheLogs, Encoding.UTF8);
            //        CacheLogs.Clear();
            //    }
            //    //write new log
            //    File.AppendAllLines(LogPath, new List<string> {FormatLog(log)}, Encoding.UTF8);
            //}
            //catch (UnauthorizedAccessException)
            //{
            //    CacheLogs.Add("UnauthorizedAccessException -> store log to try later.");
            //    CacheLogs.Add(FormatLog(log));
            //    //cache message to try later
            //}
        }

        private static string FormatLog(string log)
        {
            return string.Format("{0:G} - {1}\n", DateTime.Now, log);
        }
    }
}