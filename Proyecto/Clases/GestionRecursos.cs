using Proyecto.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Clases
{
    public class GestionRecursos
    {
        Recursos recursos = new Recursos(); // Preguntar por esta linea 


        public GestionRecursos() { }
        public Recursos CrearRecurso(int IdRecurso, string nombreRecurso)
        {
            return new Recursos()
            {
                IdRecurso = IdRecurso,
                NombreRecurso = nombreRecurso,
                disponible = true
            };
        }
        public Recursos CambiarEstadoDisponible(Recursos recurso)
        {
            recurso.disponible = true;
            return recurso;
        }

        public Recursos CambiarEstadoNoDisponible(Recursos recurso)
        {
            recurso.disponible = false;
            return recurso;
        }

        public Hilos AsignarRecurso(Hilos hilo, Recursos recursos)
        {
            if (recursos.disponible)
            {
                hilo.recurso = recursos;
            }
            else
            {

            }
            
            CambiarEstadoNoDisponible(recursos);
            return hilo;
        }

        public void ImprimiRecurso(Recursos recursos)
        {
            string texto = recursos.disponible ?
            $"Recurso Disponible {recursos.NombreRecurso}" :
            $"Recurso No disponible {recursos.NombreRecurso}";
            Console.WriteLine(texto);

        }
    }
}



