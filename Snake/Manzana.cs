using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Manzana
    {
        Posicion Posicion { get; set; }

        /// <summary>
        /// Posiciones donde aleatoriamente
        /// aparecerán las manzanas.
        /// 
        /// Dibujamos la manzana en la posición X, Y
        /// El color de la manzana se dibujará en rojo.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Manzana(int x, int y)
        {
            Posicion = new Posicion(x, y);
        }

        public void DibujarManzan()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Util.DibujarPosicion(Posicion.X, Posicion.Y, "O");
            Console.ResetColor();
        }

        /// <summary>
        /// Creamos la manzana
        /// 
        /// La manzana la pondremos
        /// en un sitio aleatorio del tablero
        /// para que así no coincida con la serpiente.
        /// </summary>
        /// <param name="snake"></param>
        /// <param name="tablero"></param>
        /// <returns>Manzana</returns>
        public static Manzana CrearManzana(Snake snake, Tablero tablero)
        {
            bool manzanaValida = false;
            int x = 0;
            int y = 0;

            do
            {
                Random random = new Random();
                x = random.Next(1, tablero.Anchura - 1);
                y = random.Next(1, tablero.Altura - 1);

                manzanaValida = !snake.PosicionEnCola(x, y);

            } while (manzanaValida);

            return new Manzana(x, y);
        }
    }
}
