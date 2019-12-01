using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZagozGame
{
    class Fruit
    {
        public Fruit(Coordinates coords)
        {
            Location = coords;
            Exists = true;
        }

        static public bool Exists = false;

        public Coordinates Location;

        static Random rnd = new Random();

        public void DrawFruit()
        {
            SolidBrush brush = new SolidBrush(Color.Orange);
            Form1.g.FillRectangle(brush, Location.x * Area.TileWidth, Location.y * Area.TileHeight, Area.TileWidth, Area.TileHeight);
        }

        static public Coordinates GenerateCoords(Snake snake)
        {
            Coordinates fruitCoords;
            bool match = false;
            do
            {
                fruitCoords = new Coordinates(Fruit.rnd.Next(0, 20), Fruit.rnd.Next(0, 20));

                for (int i = 0; i < snake.SnakeBlocks.Count; i++)
                {
                    if (fruitCoords.x == snake.SnakeBlocks[i].x && fruitCoords.y == snake.SnakeBlocks[i].y)
                    {
                        match = true;
                        break;
                    }
                }
            }
            while (match);
            
            return fruitCoords;
        }
    }
}
