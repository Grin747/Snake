using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace snake
{
    class Game : Form
    {
        Timer time { get; }
        bool directionChanged;
        Snake snake { get; }
        Map map { get; }

        public Game(string[] lvl = null)
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.Manual;
            BackgroundImage = Image.FromFile("..//..//res//tex//Wall.png");
            BackgroundImageLayout = ImageLayout.Tile;
            DoubleBuffered = true;
            KeyDown += Form_KeyDown;

            map = new Map(lvl);
            Size = map.WindowSize;

            map.CreateFood();

            snake = new Snake(map, this, 3);

            time = new Timer();
            time.Interval = 200;
            time.Tick += Tick;
            time.Start();
        }

        public void Break()
        {
            time.Stop();
            System.Threading.Thread.Sleep(3000);
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
