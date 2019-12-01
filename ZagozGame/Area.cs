using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZagozGame
{
    class Area
    {
        static public int TileHeight = 40;
        static public int TileWidth = 40;

        static public void DrawTileMap()
        {
            Pen pen = new Pen(Color.Black);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Form1.g.DrawRectangle(pen, 0 + TileWidth * i, 0 + TileHeight * j, TileWidth, TileHeight);
                }
            }
        }
    }
}
