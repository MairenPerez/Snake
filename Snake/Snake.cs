using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    public class Snake
    {
        private List<Posicion> Cola { get; set; }
        public Direccion Direccion { get; set; }
        private int Puntos { get; set; }
        public bool estaViva { get; set; }

        public Snake(int x, int y)
        {
            Posicion posicionInicial = new Posicion(x, y);
            Cola = new List<Posicion>() { posicionInicial };
            Direccion = Direccion.Abajo;
            Puntos = 0;
            estaViva = true;
        }

        public void DibujarSerpiente()
        {
            foreach (Posicion posicion in Cola)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Util.DibujarPosicion(posicion.X, posicion.Y, "^");
                Console.ResetColor();
            }
        }

        public void Morir()
        {
            estaViva = false;
            Console.WriteLine("¡La serpiente ha muerto!");
        }

        public void Moverse(bool haComido)
        {
            List<Posicion> nuevaCola = new List<Posicion>();
            nuevaCola.Add(ObtenerNuevaPrimPosicion());

            nuevaCola.AddRange(Cola); // Añadir el resto de la cola

            if (!haComido)
            {
                nuevaCola.Remove(nuevaCola.Last());
            }

            Cola = nuevaCola;
        }

        private Posicion ObtenerNuevaPrimPosicion()
        {
            int x = Cola.First().X;
            int y = Cola.First().Y;

            switch (Direccion)
            {
                case Direccion.Abajo:
                    y += 1;
                    break;
                case Direccion.Arriba:
                    y -= 1;
                    break;
                case Direccion.Derecha:
                    x += 1;
                    break;
                case Direccion.Izquierda:
                    x -= 1;
                    break;
            }

            return new Posicion(x, y);
        }

        /// <summary>
        /// Añadir un elemento a la cola
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool PosicionEnCola(int x, int y)
        {
            return Cola.Any(a => a.X == x && a.Y == y);
        }

        /// <summary>
        /// Comer manzanas
        /// 
        /// Cada vez que la serpiente
        /// interactue con la manzana 
        /// aumentará su tamaño así como sus puntos.
        /// </summary>
        /// <param name="manzana"></param>
        /// <param name="tablero"></param>
        /// <returns>False</returns>
        public bool ComerManzanas(Manzana manzana, Tablero tablero)
        {
            if (PosicionEnCola(manzana.Posicion.X, manzana.Posicion.Y))
            {
                Puntos += 10;
                tablero.ContieneManzana = false; // Generar nueva manzana automáticamente 
                return true;
            }

            return false;
        }
    }
}
