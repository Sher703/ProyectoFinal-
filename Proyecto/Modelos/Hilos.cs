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
    }
}
    

  


