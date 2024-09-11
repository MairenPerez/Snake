using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Tablero
    {
        public readonly int Altura;
        public readonly int Anchura;
        public bool ContieneManzana;

        // Constructor
        public Tablero(int altura, int anchura)
        {
            Altura = altura;
            Anchura = anchura;
            ContieneManzana = false;
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
                // Línea laterales 
                Util.DibujarPosicion(Anchura, i, "|");
                Util.DibujarPosicion( 0, i, "|");
            }

            for (int i = 0; i <= Anchura; i++)
            {
                Util.DibujarPosicion( i, 0, "-");
                Util.DibujarPosicion(i, Altura, "-");
            }
        }

       
    }
}
