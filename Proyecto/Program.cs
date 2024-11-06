using Proyecto.Clases;
using Proyecto.Modelos;
using System;
using System.Threading.Tasks;

namespace Proyecto
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GestionHilos gestion = new GestionHilos();
            // MODIFFICACION
            GestionRecursos gestionRecursos = new GestionRecursos();
            //
            RoundRobin planificador = new RoundRobin();

            Console.Write("¿Cuántos hilos desea crear? ");
            int cantidadHilos = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidadHilos; i++)
            {
                Console.WriteLine("");
                Console.WriteLine("******************************");
                Console.Write($"Ingrese el nombre del hilo {i + 1}: ");
                string nombreHilo = Console.ReadLine();
                nombreHilo = string.IsNullOrEmpty(nombreHilo) ? $"Hilo {i}" : nombreHilo;
                Console.Write($"Ingrese el tiempo de ejecución (en segundos) para el hilo {i + 1}: ");
                int timpoEjecucion = int.Parse(Console.ReadLine());
                Console.Write($"Ingrese el tiempo de proceso (en segundos) para el hilo {i + 1}: ");
                int tiempoProceso = int.Parse(Console.ReadLine());

                // MODIFICACION 
                Console.Write("¿Cuántos recursos necesita? ");
                int cantidadRecursos = int.Parse(Console.ReadLine());
                Recursos recurso = gestionRecursos.CrearRecurso(i + 1, $"Recurso {i + 1}");
                
                Hilos hilo = gestion.CrearHilo(i + 1, nombreHilo, timpoEjecucion, tiempoProceso, recurso);
                //
                hilo = gestionRecursos.AsignarRecurso(hilo, recurso);
                gestionRecursos.ImprimiRecurso(recurso);
                //
                planificador.EncolarHilo(hilo);
            }

            // Ejecuta la planificación
            await planificador.Ejecutar();
            Console.WriteLine("Planificación completada.");
        }
    }
}
