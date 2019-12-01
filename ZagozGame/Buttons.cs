using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagozGame
{
    class Buttons
    {
        static public bool Up = false;

        static public bool Down = false;

        static public bool Left = false;

        static public bool Right = false;

        static public void ClearButtons()
        {
            Down = false;
            Up = false;
            Left = false;
            Right = false;
        }
    }
}
