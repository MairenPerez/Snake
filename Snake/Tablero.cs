using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Tablero
    {
        public readonly int Altura;
        public readonly int Anchura;

        // Constructor
        public Tablero(int altura, int anchura)
        {
            Altura = altura;
            Anchura = anchura;
        }

        /// <summary>
        /// Dibujamos tablero 
        /// 
        /// Con un for vamos a dibujar 
        /// las líneas de arriba y de abajo.
        /// </summary>
        public void DibujarTablero()
        {
            for (int i = 0; i <= Altura; i++)
            {
                // Línea de abajo
                Console.SetCursorPosition(Anchura, i);
                Console.WriteLine("<");

                // Línea de arriba
                Console.SetCursorPosition(0, i);
                Console.WriteLine(">");
            }
        }
    }
}
