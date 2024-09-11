using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    public  class Snake
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

        public void Moverse()
        {
            List<Posicion> nuevaCola = new List<Posicion>();
            nuevaCola.Add(ObtenerNuevaPrimPosicion());

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

        public bool PosicionEnCola(int x, int y)
        {
            return Cola.Any(a => a.X == x && a.Y == y);
        }

        public void ComerManzanas( Manzana manzana, Tablero tablero)
        {
           if (PosicionEnCola(manzana.Posicion.X, manzana.Posicion.Y))
            {
                Puntos++;
                tablero.ContieneManzana = false; // Generar nueva manzana automáticamente 
                Cola.Add(manzana.Posicion); 

            }
        }
    }
}
