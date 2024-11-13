using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Modelos
{
    public class Hilos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Estados estado { get; set; }
        public int TiempoProceso { get; set; }
        public int TiempoEjecucion { get; set; }
        public Recursos recurso { get; set; }
        public bool critico {  get; set; }        
        public Queue<Mensajes> ColaMensajes { get; } = new Queue<Mensajes>();

        public void EnviarMensaje(Hilos destinatario, string contenido)
        {
            Mensajes mensaje = new Mensajes
            {
                RemitenteId = this.id,
                DestinatarioId = destinatario.id,
                Contenido = contenido
            };
            destinatario.ColaMensajes.Enqueue(mensaje);
            Console.WriteLine($"Mensaje enviado de Hilo {this.id} a Hilo {destinatario.id}: {contenido}");
        }

        public void ProcesarMensajes()
        {
            while (ColaMensajes.Count > 0)
            {
                Mensajes mensaje = ColaMensajes.Dequeue();
                Console.WriteLine($"Hilo {id} procesó mensaje de Hilo {mensaje.RemitenteId}: {mensaje.Contenido}");
            }
        }
    }
}
    

  


