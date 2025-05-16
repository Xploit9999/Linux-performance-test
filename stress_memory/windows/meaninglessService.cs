using System.ServiceProcess;
using System.Diagnostics;

public class MiServicio : ServiceBase
{
    public MiServicio()
    {
        this.ServiceName = "MiServicioBasico";
    }

    protected override void OnStart(string[] args)
    {
        EventLog.WriteEntry("MiServicioBasico iniciado.");
    }

    protected override void OnStop()
    {
        EventLog.WriteEntry("MiServicioBasico detenido.");
    }

    public static void Main()
    {
        ServiceBase.Run(new MiServicio());
    }
}

