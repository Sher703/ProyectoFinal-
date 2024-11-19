using Proyecto.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Clases
{
    internal class BitMap:IAlgoritmo
    {

        private bool[] bitmap;
        public async Task Ejecutar()
        {
            string salir = "S";
            Console.WriteLine("Ingrese el tamaño del BitMap");
            int tamanioBitmap = Convert.ToInt32(Console.ReadLine());
            bitmap = new bool[tamanioBitmap];
            while (salir == "S") 
            {
                Console.Clear();
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Remover");                
                int tipo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inicio");
                int inicio = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Fin");
                int fin = Convert.ToInt32(Console.ReadLine());
                switch (tipo)
                {
                    case 1:
                        Add(inicio, fin);
                        break;
                    case 2:
                       Remove(inicio, fin);
                        break;
                    default:
                        Console.WriteLine("Opcion no válida");
                        break;
                }

                Console.WriteLine("Estado del bitmap: " + ConvertirString()); 
                Console.WriteLine("Continuar? S/N");
                salir = Console.ReadLine().ToUpper();                
            }            
        }        

        public void Add(int startPosition, int endPosition)
        {
            if (IsValidRange(startPosition, endPosition))
            {
                for (int i = startPosition; i <= endPosition; i++)
                {
                    bitmap[i] = true;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("El rango especificado está fuera de los límites del bitmap.");
            }
        }

        public void Remove(int startPosition, int endPosition)
        {
            if (IsValidRange(startPosition, endPosition))
            {
                for (int i = startPosition; i <= endPosition; i++)
                {
                    bitmap[i] = false;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("El rango especificado está fuera de los límites del bitmap.");
            }
        }

        private bool IsValidRange(int startPosition, int endPosition)
        {
            return startPosition >= 0 && endPosition < bitmap.Length && startPosition <= endPosition;
        }

        public string ConvertirString()
        {
            // Construir la cadena manualmente usando un StringBuilder
            System.Text.StringBuilder result = new System.Text.StringBuilder();

            foreach (bool bit in bitmap)
            {
                // Convertir true a "1" y false a "0"
                result.Append(bit ? "1" : "0");
            }

            return result.ToString();
        }


    }
}
