using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Instanciamos un nuevo tablero
             * con una altura de 20 y una anchura
             * de 20 (20x20).
             * 
             * Llamamos al método DibujarTablero()
             * 
             * Creamos una nueva serpiente
            */

            Tablero tablero = new Tablero(20, 20);
            tablero.DibujarTablero();
            Snake  snake = new Snake(10, 10);
            snake.DibujarSerpiente();

            Console.ReadKey();
        }
    }
}
