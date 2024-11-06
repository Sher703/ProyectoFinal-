using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Modelos
{

    public class Estados
   
    {
        public bool Nuevo { get; set; } = false; //1
        public bool Listo { get; set; } = false; //2
        public bool Ejecucion { get; set; } = false; //3
        public bool Bloqueado { get; set; } = false; //2.5
        public bool Terminado { get; set; } = false; //4

    }
}
