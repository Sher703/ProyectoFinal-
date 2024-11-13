using Proyecto.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto.Clases
{
    internal class GestionHilos

    {
        public GestionRecursos gestionRecursos = new GestionRecursos();
        public Hilos CrearHilo(int id, string nombre, int tiemposegundos, int tiempoEjecucion)
        {

            Hilos hilo = new Hilos();
            hilo.id = id;
            hilo.nombre = nombre;
            hilo.TiempoProceso = tiemposegundos * 1000;
            hilo.TiempoEjecucion = tiempoEjecucion * 1000;
            hilo.estado = new Estados() { Nuevo = true };
            ImprimirDatosHilo(hilo);
            return hilo;
        }

        public Hilos CambiarListo(Hilos hilo)
        {
            hilo.estado = new Estados();
            hilo.estado.Listo = true;
            return hilo;
        }

        public Hilos CambiarEnEjecucion(Hilos hilo)
        {
            hilo.estado = new Estados();
            hilo.estado.Ejecucion = true;
            return hilo;
        }

        public Hilos CambiarBloqueado(Hilos hilo)
        {
            hilo.estado = new Estados();
            hilo.estado.Bloqueado = true;
            return hilo;
        }

        public Hilos CambiarTerminado(Hilos hilo)
        {
            hilo.estado = new Estados();
            hilo.estado.Terminado = true;
            return hilo;
        }

        public bool HiloBloqueado(Hilos hilo)
        {
            return hilo.estado.Bloqueado;
        }

        public bool HiloEnEjecucion(Hilos hilos)
        {
            return hilos.estado.Ejecucion;
        }

        public void AsignarCritico(Hilos hilos) 
        {
            hilos.critico = true;
        }

        public void DesasignarCritico(Hilos hilos)
        {
            hilos.critico = false;
        }

        public void ImprimirDatosHilo(Hilos hilo)
        {
            Console.WriteLine("");
            Console.WriteLine("******Cambio de Estado*******");
            Console.WriteLine($"ID: {hilo.id}");
            Console.WriteLine($"Nombre: {hilo.nombre}");
            Console.WriteLine($"Es critico {hilo.critico}");
            Console.WriteLine($"Estado: {ObtenerEstadoActual(hilo)}");
            Console.WriteLine($"Mensajes:");
        }



        public string ObtenerEstadoActual(Hilos hilos)
        {
            string estado = "";
            if (hilos.estado.Nuevo == true)
            {
                estado = "Nuevo";
            }
            else if (hilos.estado.Bloqueado == true)
            {
                estado = "Bloqueado";
            }
            else if (hilos.estado.Ejecucion == true)
            {
                estado = "En Ejecucion";
            }
            else if (hilos.estado.Terminado == true)
            {
                estado = "Terminado";
            }
            else if (hilos.estado.Listo == true)
            {
                estado = "Listo";
            }
            return estado;
        }

    }
}