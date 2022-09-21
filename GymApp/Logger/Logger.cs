using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;
using System.Reflection;
using Serilog;
using System.Diagnostics;

namespace GymApp.Logger
{
    public static class Logger
    {
        public static void WriteLog(Level level, MethodBase info, string message)
        {
            string? logPath = ConfigurationManager.AppSettings["logPath"];

            Thread currentThread = Thread.CurrentThread;

            using (StreamWriter writer = new(logPath, true))
            {
                writer.WriteLine($"Time: {DateTime.Now}, Log level: {level}; message: {message};" +
                    $" thread {currentThread.Name}; thread's status: {currentThread.ThreadState};" +
                    $" priority of thread: {currentThread.Priority}; method's name:{info.Name}");
            }
           
        }

        public enum Level
        {
            Info,
            Debug,
            Error
        }
    }
}
