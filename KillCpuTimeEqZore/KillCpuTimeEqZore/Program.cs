using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillCpuTimeEqZero
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] ps = null;
            try
            {
                ps = Process.GetProcesses()
                    .Where(s => s.ProcessName.Contains("dp")).ToArray();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }

            if (ps == null) return;

            foreach (var p in ps)
            {
                try
                {
                    if (p.UserProcessorTime >= TimeSpan.FromMinutes(5))
                    {
                        p.Kill();
                        p.Dispose();
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                }
            }
        }
    }
}
