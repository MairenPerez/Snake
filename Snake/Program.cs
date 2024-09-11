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
            Snake snake = new Snake(10, 10);

            // Mientras la serpiente no haya muerto...
            do
            {
                Console.Clear();
                tablero.DibujarTablero();

                snake.Moverse(); // Movemos la serpiente
                snake.DibujarSerpiente();

                // Esperamos 250 milisegundos
                var sw = Stopwatch.StartNew();
                while (sw.ElapsedMilliseconds <= 250)
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
        public static Direccion LeerMovimiento(Direccion movimientoActual)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        return movimientoActual != Direccion.Abajo ? Direccion.Arriba : movimientoActual;
                    case ConsoleKey.DownArrow:
                        return movimientoActual != Direccion.Arriba ? Direccion.Abajo : movimientoActual;
                    case ConsoleKey.LeftArrow:
                        return movimientoActual != Direccion.Derecha ? Direccion.Izquierda : movimientoActual;
                    case ConsoleKey.RightArrow:
                        return movimientoActual != Direccion.Izquierda ? Direccion.Derecha : movimientoActual;
                }
            }

            return movimientoActual;
        }
    }
}
