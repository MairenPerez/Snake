using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Snake  snake = new Snake(10, 10);

            // Mientras la serpiente no haya muerto...
            do
            {
                Console.Clear(); // Limpiamos la consola
                tablero.DibujarTablero(); // Dibujamos el tablero
                snake.DibujarSerpiente();
                snake.Moverse(); // Movemos la serpiente

                // Esperamos 250 milisegundos
                var sw = Stopwatch.StartNew();
                while (sw.ElapsedMilliseconds < 250)
                {
                    snake.Direccion = LeerMovimiento(snake.Direccion); // Dirección actual de la serpiente
                }



            } while (snake.estaViva);


            Console.ReadKey();
        }
        
        /// <summary>
        /// Si el jugador no pulsa
        /// ninguna tecla, la serpiente
        /// mantendrá su posición acutal.
        /// </summary>
        /// <param name="movimientoActual"></param>
        /// <returns></returns>
        static Direccion LeerMovimiento( Direccion movimientoActual)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow && movimientoActual != Direccion.Abajo)
                {
                    return Direccion.Arriba;
                }
                else if (key == ConsoleKey.DownArrow && movimientoActual != Direccion.Arriba)
                {
                    return Direccion.Abajo;
                }
                else if (key == ConsoleKey.LeftArrow && movimientoActual != Direccion.Derecha)
                {
                    return Direccion.Izquierda;
                }
                else if (key == ConsoleKey.RightArrow && movimientoActual != Direccion.Izquierda)
                {
                    return Direccion.Derecha;
                }
            }

            return movimientoActual;
        }
    }
}
