using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

class Program
{
    const string TargetDirectory = @"C:\Temp\EmailQueue";
    const int MaxFiles = 20;
    const int DelayBetweenFilesMs = 500;
    const int SimulationDurationBeforeEncolamientoSec = 120;

    static DateTime startTime;
    static bool encolamiento = false;
    static bool isClone = false;

    static void Main(string[] args)
    {
        Directory.CreateDirectory(TargetDirectory);
        startTime = DateTime.Now;

        int encolados = Directory.GetFiles(TargetDirectory).Length;
        if (encolados > MaxFiles)
        {
            Console.WriteLine(">>> Cola detectada con archivos en espera. Limpiando...");
            foreach (var file in Directory.GetFiles(TargetDirectory))
            {
                try
                {
                    File.Delete(file);
                    Console.WriteLine("Archivo eliminado: " + Path.GetFileName(file));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar: " + ex.Message);
                }
            }
            Console.WriteLine(">>> {0} correos simulados como enviados al reiniciar.", encolados);
        }

        if (args.Length > 0 && args[0] == "clone")
        {
            isClone = true;
            Console.WriteLine("Instancia clon en ejecución (sin limpieza).");
        }

        if (!isClone)
        {
            new Thread(() =>
            {
                Thread.Sleep(SimulationDurationBeforeEncolamientoSec * 1000);
                encolamiento = true;

                string exePath = Process.GetCurrentProcess().MainModule.FileName;
                Process.Start(exePath, "clone");
                Console.WriteLine(">>> Simulación de encolamiento: se ha lanzado instancia duplicada.");
            }).Start();
        }

        int contador = 1;
        Random rnd = new Random();
        while (true)
        {
            string filePath = Path.Combine(
                TargetDirectory,
                string.Format("correo_{0}_{1}.txt", DateTime.Now.ToString("HHmmss"), contador)
            );

            try
            {
                File.WriteAllText(filePath, string.Format("Simulación de correo número {0} - {1}", contador, DateTime.Now));
                Console.WriteLine("Creado: " + Path.GetFileName(filePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear archivo: " + ex.Message);
            }

            contador++;

            if (!encolamiento && !isClone)
            {
                var archivos = Directory.GetFiles(TargetDirectory);
                if (archivos.Length > 0 && rnd.Next(0, 100) < 80)
                {
                    string eliminar = archivos[rnd.Next(archivos.Length)];
                    try
                    {
                        File.Delete(eliminar);
                        Console.WriteLine("Eliminado (simulado envío): " + Path.GetFileName(eliminar));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al eliminar archivo: " + ex.Message);
                    }
                }
            }

            Thread.Sleep(DelayBetweenFilesMs);
        }
    }
}

