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

            Tablero tablero = new Tablero(29, 29);
            Snake snake = new Snake(10, 10);
            Manzana manzana = new Manzana(0, 0);
            bool haComido = false;

            // Mientras la serpiente no haya muerto...
            do
            {
                Console.Clear();
                tablero.DibujarTablero();

                snake.ComprobamosMuerte(tablero);
                if (snake.estaViva)
                {
                    // Movemos la serpiente
                    snake.Moverse(haComido); 

                    // Comprobamos si se ha comido la manzana
                    haComido = snake.ComerManzanas(manzana, tablero);
                    snake.DibujarSerpiente();

                    if (!tablero.ContieneManzana)
                    {
                        manzana = Manzana.CrearManzana(snake, tablero);
                    }

                        manzana.DibujarManzana();

                        // Esperamos 250 milisegundos
                        var sw = Stopwatch.StartNew();
                        while (sw.ElapsedMilliseconds <= 250)
                        {
                            snake.Direccion = LeerMovimiento(snake.Direccion); // Dirección actual de la serpiente
                        }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Util.DibujarPosicion(tablero.Anchura / 2, tablero.Altura / 2, "GAME OVER");
                    Util.DibujarPosicion(tablero.Anchura / 2, (tablero.Altura / 2) + 1, $"Puntuacion {snake.Puntos}");
                    Console.ResetColor();
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
