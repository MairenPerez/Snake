using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake
    {
        // Definimos la posición de la serptiente 
        List<Posicion> Cola { get; set; }

        Direccion direccion { get; set; }

        int Puntos { get; set; }

        /// <summary>
        /// Inicializamos su posición inicial
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Snake (int x, int y)
        {
            Posicion posicionInicial = new Posicion(x, y);
            Cola = new List<Posicion>() { posicionInicial };
            direccion = Direccion.Abajo;
        }

        public void Morir()
        {
            throw new NotImplementedException();
        }

        public void Moverse()
        {
            throw new NotImplementedException();
        }

        public void comerManzanas()
        {
            /* Cada vez que la serpiente coma,
             * se le aumentará el tamaño y los puntos
             * 
             * Cuando la serpiente haya recogido su comida, 
             * ésta desaparecerá.
            */
            throw new NotImplementedException();
        }
    }
}
