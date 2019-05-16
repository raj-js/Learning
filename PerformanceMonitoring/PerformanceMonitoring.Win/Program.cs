using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace PerformanceMonitoring.Win
{
    class Program
    {
        static void Main(string[] args)
        {
            var psDic = new Dictionary<Process, PerformanceCounter>();

            var i = 10;
            while (i-- > 0)
            {
                var processes = Process.GetProcesses().OrderBy(s => s.ProcessName);
                foreach (var p in processes)
                {
                    if (!psDic.ContainsKey(p))
                        psDic.Add(p, new PerformanceCounter("Process", "% Processor Time", p.ProcessName, "."));

                    try
                    {
                        if (DateTime.Now - p.StartTime > TimeSpan.FromMinutes(5))
                        {
                            var cpuCounter = psDic[p];
                            if (cpuCounter == null)
                            {
                                Console.WriteLine("p.Kill() --> cpuCounter == null");
                                // p.Kill();
                            }

                            var cpuUse = cpuCounter.NextValue();
                            Console.WriteLine($" Name: {p.ProcessName}, Id: {p.Id}, CpuUse: {cpuUse}");

                            if (cpuUse == 0)
                            {
                                Console.WriteLine("p.Kill() --> cpuUse == 0");
                                // p.Kill();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Console.WriteLine($"{p?.ProcessName} --> Access Denied");
                    }
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
