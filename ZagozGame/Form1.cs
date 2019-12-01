using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ZagozGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 870;
            this.Height = 940;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            pictureBox1.Size = new Size(801, 801);           
        }

        static public Bitmap bmp = new Bitmap(801, 801);
        static public Graphics g = Graphics.FromImage(bmp);
        Snake snake = new Snake();
        List<Fruit> Fruits = new List<Fruit>();
        private int Score = 0;


        private void CollisionDetection()
        {
            for (int i = 0; i < Fruits.Count; i++)
            {
                if (snake.SnakeBlocks[0].x == Fruits[i].Location.x &&
                snake.SnakeBlocks[0].y == Fruits[i].Location.y)
                {
                    Fruit.Exists = false;
                    if (snake.SnakeBlocks.Count == 1)
                        snake.SnakeBlocks.Add(new Coordinates(Fruits[i].Location.x, Fruits[i].Location.y));
                    Score++;
                }

                if (snake.SnakeBlocks[snake.SnakeBlocks.Count - 1].x == Fruits[i].Location.x &&
                    snake.SnakeBlocks[snake.SnakeBlocks.Count - 1].y == Fruits[i].Location.y)
                {
                    snake.SnakeBlocks.Add(new Coordinates(Fruits[i].Location.x, Fruits[i].Location.y));
                    Fruits.RemoveAt(i);
                }
            }
            
            for (int i = 3; i < snake.SnakeBlocks.Count; i++)
            {
                if (snake.SnakeBlocks[0].x == snake.SnakeBlocks[i].x &&
                    snake.SnakeBlocks[0].y == snake.SnakeBlocks[i].y)
                {
                    LoseGame();
                    break;
                }
            }
             
        }

        private void Draw()
        {
            g.Clear(Color.White);

            if (!Fruit.Exists)
            {
                
                Fruits.Add(new Fruit(Fruit.GenerateCoords(snake)));

                Fruit.Exists = true;
            }
            else
            {
                foreach (Fruit fruit in Fruits)
                    fruit.DrawFruit();
            }

            Area.DrawTileMap();

            snake.DrawSnake();

            Buttons.ClearButtons();

            pictureBox1.Image = bmp;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Draw();
            CollisionDetection();
            ScoreLabel.Text = Score.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up: Buttons.Up = true; break;
                case Keys.Down: Buttons.Down = true; break;
                case Keys.Left: Buttons.Left = true; break;
                case Keys.Right: Buttons.Right = true; break;
            }
        }

        private void LoseGame()
        {
            timer1.Stop();
            MessageBox.Show("You lose :(");
            restartButton.Visible = true;
            
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            restartButton.Visible = false;
            label3.Visible = true;
            PrevScoreLabel.Visible = true;
            SetStartProperties();
            timer1.Start();
        }

        private void SetStartProperties()
        {
            PrevScoreLabel.Text = Score.ToString();
            snake = new Snake();
            Fruits = new List<Fruit>();
            Score = 0;
            Fruit.Exists = false;
            Buttons.ClearButtons();
        }

    }
}
