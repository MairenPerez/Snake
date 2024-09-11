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



            //if (!estaViva)
            //    return;


            //// Verificar colisiones con el borde del tablero
            //if (nuevaCabeza.X < 0 || nuevaCabeza.X >= 20 || nuevaCabeza.Y < 0 || nuevaCabeza.Y >= 20)
            //{
            //    Morir();
            //    return;
            //}

            //// Verificar colisiones con el propio cuerpo
            //if (Cola.Any(p => p.X == nuevaCabeza.X && p.Y == nuevaCabeza.Y))
            //{
            //    Morir();
            //    return;
            //}

            //Cola.Insert(0, nuevaCabeza);

            //// Removemos la última posición de la cola si la serpiente no ha comido
            //Cola.RemoveAt(Cola.Count - 1);
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

        public void comerManzanas()
        {
            // Implementar la lógica para aumentar el tamaño y los puntos
            throw new NotImplementedException();
        }
    }
}
