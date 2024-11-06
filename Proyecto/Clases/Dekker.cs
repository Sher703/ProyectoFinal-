using Proyecto.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Clases
{
    public class Dekker
    {
        bool flag1;
        bool flag2;
        public int turn = 1;

        public void dekker(Hilos hilo) 
        {
            for (int i = 0; i < 5; i++)
            {
                flag1 = true; 
                while (flag2) 
                {
                    if (turn == 2)
                    {
                        flag1 = false; 
                        while (turn == 2) ;
                        flag1 = true; 
                    }
                }
                SeccionCritica(hilo);
                turn = 2;
                flag1 = false;
                Thread.Sleep(500); 
            }
        }

        private static void SeccionCritica(Hilos hilo)
        {
            Console.WriteLine($"{hilo} está en la sección crítica.");
            Thread.Sleep(1000); 
            Console.WriteLine($"{hilo} ha salido de la sección crítica.");
        }
    }
}
