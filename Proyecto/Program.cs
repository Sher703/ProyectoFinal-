using Proyecto.Clases;
using Proyecto.Interfaz;
using Proyecto.Modelos;
using System;
using System.Threading.Tasks;

namespace Proyecto
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                IAlgoritmo iAlgoritmo;
                Console.WriteLine("Seleccione el tipo de Simulación a utilizar");
                Console.WriteLine("1. Semáforo");
                Console.WriteLine("2. Monitor");
                Console.WriteLine("3. BitMap");
                int tipo = Convert.ToInt32(Console.ReadLine());

                switch (tipo)
                {
                    case 1:
                        iAlgoritmo = new Semaforos();
                        break;
                    case 2:
                        iAlgoritmo = new Monitores();
                        break;
                    case 3:
                        iAlgoritmo = new BitMap();
                        break;
                    default:
                        iAlgoritmo = new Semaforos();
                        break;
                }
                iAlgoritmo.Ejecutar();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
