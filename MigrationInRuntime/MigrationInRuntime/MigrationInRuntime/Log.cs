using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationInRuntime
{
    public class Log
    {
        public int LogId { get; set; }

        public LogLevel Level { get; set; }

        public DateTime Time { get; set; }

        public string Content { get; set; }
    }

    public enum LogLevel
    {
        Info,
        Debug,
        Error
    }
}
