using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ZagozGame
{
    class Snake
    {
        public Snake()
        {
            SnakeBlocks.Add(new Coordinates(rnd.Next(0, 20), rnd.Next(0, 20)));
        }

        private Random rnd = new Random();
        private int DirectionX = 0;
        private int DirectionY = 0;

        public List<Coordinates> SnakeBlocks = new List<Coordinates>();

        private void DrawBlock(Coordinates coords)
        {
            SolidBrush brush = new SolidBrush(Color.Green);
            Form1.g.FillRectangle(brush, coords.x * Area.TileWidth, coords.y * Area.TileHeight, Area.TileWidth, Area.TileHeight);
        }

        private void MoveBlocks()
        {
            SnakeBlocks[0].x += DirectionX;
            SnakeBlocks[0].y += DirectionY;

            for (int i = SnakeBlocks.Count - 1; i > 0; i--)
            {
                SnakeBlocks[i].x = SnakeBlocks[i - 1].x;
                SnakeBlocks[i].y = SnakeBlocks[i - 1].y;

            }
        }

        private void ChangeDirection()
        {
            if (Buttons.Up && DirectionY != 1)
            {
                DirectionY = -1;
                DirectionX = 0;
            }
            if (Buttons.Down && DirectionY != -1)
            {
                DirectionY = 1;
                DirectionX = 0;
            }
            if (Buttons.Left && DirectionX != 1)
            {
                DirectionY = 0;
                DirectionX = -1;
            }
            if (Buttons.Right && DirectionX != -1)
            {
                DirectionY = 0;
                DirectionX = 1;
            }
        }

        public void DrawSnake()
        {
            ChangeDirection();
            TeleportSnake();
            MoveBlocks();   
            for (int i = 0; i < SnakeBlocks.Count; i++)
            {
                DrawBlock(SnakeBlocks[i]);
            }
            
            
        }

        private void TeleportSnake()
        {

            if (SnakeBlocks[0].x < 0 && DirectionX == -1)
            {
                SnakeBlocks[0].x = 20;
            }
            if (SnakeBlocks[0].x > 20 && DirectionX == 1)
            {
                SnakeBlocks[0].x = -1;
            }
            if (SnakeBlocks[0].y < 0 && DirectionY == -1)
            {
                SnakeBlocks[0].y = 20;
            }
            if (SnakeBlocks[0].y > 20 && DirectionY == 1)
            {
                SnakeBlocks[0].y = -1;
            }
        }
    }
}
