using Proyecto.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.Clases
{
    internal class RoundRobin
    {
        private GestionHilos gestionHilos;
        private GestionRecursos gestionRecursos; //AGREGADA SHER
        private Queue<Hilos> colaHilos;

        public RoundRobin()
        {
            colaHilos = new Queue<Hilos>();
            gestionHilos = new GestionHilos();
            gestionRecursos = new GestionRecursos(); // AGREGADA SHER 
        }

        public void EncolarHilo(Hilos hilo)
        {
            gestionHilos.CambiarListo(hilo);
            gestionHilos.ImprimirDatosHilo(hilo);
            colaHilos.Enqueue(hilo);
        }

        public async Task Ejecutar()
        {
            if (colaHilos.Count <= 0) { Console.WriteLine("No existen hilos en la cola."); }
            while (colaHilos.Count > 0)
            {
                Hilos hiloActual = colaHilos.Dequeue();
                //AGREGADA SHER 
                Recursos recurso = new Recursos { IdRecurso = 1, NombreRecurso = "Recurso 1" };
                if (recurso.disponible)
                {
                    gestionRecursos.CambiarEstadoNoDisponible(recurso);
                    gestionRecursos.AsignarRecurso(hiloActual, recurso);
                    gestionHilos.CambiarEnEjecucion(hiloActual);
                    gestionHilos.ImprimirDatosHilo(hiloActual);
                    await Task.Delay(hiloActual.TiempoEjecucion);
                    if (hiloActual.TiempoEjecucion >
                        hiloActual.TiempoProceso)
                    {
                        gestionHilos.CambiarBloqueado(hiloActual);
                        gestionHilos.ImprimirDatosHilo(hiloActual);
                        gestionRecursos.CambiarEstadoDisponible(recurso);
                        gestionRecursos.ImprimiRecurso(recurso);
                    }
                    gestionHilos.CambiarTerminado(hiloActual);
                    gestionHilos.ImprimirDatosHilo(hiloActual);
                }
                else
                {
                    Console.WriteLine($"El recurso {recurso.IdRecurso} no está disponible");
                }
            }
        }
    }
}
    

