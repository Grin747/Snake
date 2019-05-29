using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace snake
{
    class Game : Form
    {
        System.Windows.Forms.Timer time { get; }
        bool directionChanged;
        Snake snake { get; }
        Map map { get; }
        Image wall = Image.FromFile("..//..//res//tex//Wall.png");

        public Game()
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.Manual;
            BackgroundImage = wall;
            BackgroundImageLayout = ImageLayout.Tile;
            DoubleBuffered = true;
            KeyDown += Form_KeyDown;

            map = new Map(File.ReadAllLines("..//..//res//lvl//1.txt"));
            Size = map.WindowSize;

            map.CreateFood();

            snake = new Snake(map, this, 3);

            time = new System.Windows.Forms.Timer();
            time.Interval = 200;
            time.Tick += Tick;
            time.Start();
        }

        public void Break()
        {
            time.Stop();
            Thread.Sleep(3000);
            this.Close();
        }

        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (directionChanged) return;
            directionChanged = true;
            switch(e.KeyCode)
            {
                case Keys.Right:
                    if (snake.Direction != Direction.Left)
                        snake.Direction = Direction.Right;
                    break;
                case Keys.Left:
                    if (snake.Direction != Direction.Right)
                        snake.Direction = Direction.Left;
                    break;
                case Keys.Up:
                    if (snake.Direction != Direction.Down)
                        snake.Direction = Direction.Up;
                    break;
                case Keys.Down:
                    if (snake.Direction != Direction.Up)
                        snake.Direction = Direction.Down;
                    break;
            }
        }

        void Tick(object sender, EventArgs e)
        {
            directionChanged = false;
            snake.Move();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            snake.Draw(e.Graphics);
            map.Draw(e.Graphics);
        }
    }
}
