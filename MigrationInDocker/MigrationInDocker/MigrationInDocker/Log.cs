using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationInDocker
{
    [Table("logs")]
    public class Log
    {
        public Log()
        {
            Time = DateTime.Now;
        }

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
