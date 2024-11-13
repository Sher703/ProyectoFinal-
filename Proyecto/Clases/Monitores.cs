using Proyecto.Interfaz;
using Proyecto.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Clases
{
    internal class Monitores : IAlgoritmo
    {
        public async Task Ejecutar()
        {
            GestionHilos gestionHilos = new GestionHilos();
            GestionRecursos gestionRecursos = new GestionRecursos();
            RoundRobin planificador = new RoundRobin();

            Console.Write("¿Cuántos hilos desea crear? ");
            int cantidadHilos = int.Parse(Console.ReadLine());

            // Monitor para controlar la condición de carrera
            object monitorLock = new object();

            Console.Write("¿Cuántos recursos necesita? ");
            int cantidadRecursos = int.Parse(Console.ReadLine());
            


            for (int i = 0; i < cantidadHilos; i++)
            {
                Console.WriteLine("\n******************************");
                Console.Write($"Ingrese el nombre del hilo {i + 1}: ");
                string nombreHilo = Console.ReadLine();
                nombreHilo = string.IsNullOrEmpty(nombreHilo) ? $"Hilo {i + 1}" : nombreHilo;

                Console.Write($"Ingrese el tiempo de ejecución (en segundos) para el hilo {i + 1}: ");
                int tiempoEjecucion = int.Parse(Console.ReadLine());

                Console.Write($"Ingrese el tiempo de proceso (en segundos) para el hilo {i + 1}: ");
                int tiempoProceso = int.Parse(Console.ReadLine());



                // Crear el hilo y asignar el recurso con sincronización
                Hilos hilo;
                lock (monitorLock)
                {
                    hilo = gestionHilos.CrearHilo(i + 1, nombreHilo, tiempoProceso, tiempoEjecucion);                   
                }
                planificador.EncolarHilo(hilo);
            }

            // Ejecutar la planificación de forma asincrónica
            Console.WriteLine("\nIniciando la planificación de hilos...");
            await planificador.Ejecutar(cantidadRecursos);

            Console.WriteLine("\nPlanificación completada.");
        }
    }
}
