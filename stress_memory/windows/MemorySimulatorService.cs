using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic.Devices;

public class MemoryService : ServiceBase
{
    private StringBuilder[] builders = new StringBuilder[0];
    private PerformanceCounter memCounter = new PerformanceCounter("Memory", "Available MBytes");

    public MemoryService()
    {
        this.ServiceName = "MemorySimulatorService";
    }

    protected override void OnStart(string[] args)
    {
        Thread workerThread = new Thread(new ThreadStart(WorkerMethod));
        workerThread.IsBackground = true;
        workerThread.Start();
    }

    private void WorkerMethod()
    {
        try
        {
            while (true)
            {
                float memUsage = GetMemoryUsage();
                if (memUsage < 90)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < 10000; i++)
                    {
                        sb.Append('A', 1024);
                    }
                    Array.Resize(ref builders, builders.Length + 1);
                    builders[builders.Length - 1] = sb;
                }
                Thread.Sleep(10000);
            }
        }
        catch (ThreadAbortException)
        {
        }
    }

    private float GetMemoryUsage()
    {
        float freeMem = memCounter.NextValue();
        ComputerInfo ci = new ComputerInfo();
        float totalMem = (float)(ci.TotalPhysicalMemory / (1024 * 1024));
        return 100 - (freeMem / totalMem * 100);
    }

    protected override void OnStop()
    {
        builders = new StringBuilder[0];
    }

    public static void Main()
    {
        ServiceBase.Run(new MemoryService());
    }
}
