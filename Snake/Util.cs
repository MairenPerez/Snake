﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Util
    {
        public static void DibujarPosicion(int x, int y, string caracter)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(caracter);
        }
    }
}
