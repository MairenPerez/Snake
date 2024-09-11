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
        public Manzana(int x , int y)
        {
            Posicion = new Posicion(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Util.DibujarPosicion(Posicion.X, Posicion.Y, "O");
            Console.ResetColor();
        }

        public void DibujarManzana()
        { }
    }
}
