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

        public async Task EjecutarSemaforo()
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

        public async Task Ejecutar(int cantidadRecursos)
        {
            if (colaHilos.Count <= 0) { Console.WriteLine("No existen hilos en la cola."); }
            List<Hilos> listaHilos = colaHilos.ToList();
            Queue<Recursos> recursos = new Queue<Recursos>();
            for (int i = 0; i < cantidadRecursos; i++)
            {
                Recursos recurso = gestionRecursos.CrearRecurso(i + 1, $"Recurso {i + 1}");
                recursos.Enqueue(recurso);
            }

            while (colaHilos.Count > 0)
            {
                Hilos hiloActual = colaHilos.Dequeue();

                Console.WriteLine("Enviar mensaje desde este hilo S/N");
                string respuesta = Console.ReadLine();
                if (respuesta.ToUpper().Trim().Equals("S"))
                {
                    Console.WriteLine("Ingrese el ID del hilo destino");
                    int IdHilo = Convert.ToInt32(Console.ReadLine());
                    Hilos hiloDestino = listaHilos.FirstOrDefault(h => h.id == 1);
                    if (hiloDestino != null)
                    {
                        Console.WriteLine("Escriba el mensaje");
                        string mensaje = Console.ReadLine();
                        hiloActual.EnviarMensaje(hiloDestino, mensaje);
                    }
                    else
                    {
                        Console.WriteLine("No existe un Hilo con este Id");
                    }
                }

                if (recursos.Count > 0)
                {
                    Recursos recurso = recursos.Dequeue();
                    gestionRecursos.CambiarEstadoNoDisponible(recurso);
                    gestionRecursos.AsignarRecurso(hiloActual, recurso);
                    gestionHilos.CambiarEnEjecucion(hiloActual);
                    gestionHilos.ImprimirDatosHilo(hiloActual);
                    //await Task.Delay(hiloActual.TiempoEjecucion);
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
                    hiloActual.ProcesarMensajes();
                }
                else
                {
                    Console.WriteLine($"No hay recursos disponibles para el hilo {hiloActual.id}");
                    continue;
                }
            }
        }
    }
}
    

