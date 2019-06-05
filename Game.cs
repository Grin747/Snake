using System;
using System.Drawing;
using System.Windows.Forms;

namespace snake
{
    class Game : Form
    {
        Menu menu { get; }
        Timer time { get; }
        bool directionChanged { get; set; }
        Snake snake { get; }
        Map map { get; }
        Label progress { get; }
        public int Score { get; set; }
        public int LvlNum { get; }

        public Game(Menu menu, int number, string[] lvl = null)
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.Manual;
            BackgroundImage = Image.FromFile(@"../../res/tex/Wall.png");
            BackgroundImageLayout = ImageLayout.Tile;
            DoubleBuffered = true;
            KeyDown += Form_KeyDown;
            this.menu = menu;
            LvlNum = number;

            map = new Map(lvl);
            Size = map.WindowSize;

            map.CreateFood();

            snake = new Snake(map, this, 3);

            progress = new Label()
            {
                Location = new Point(0, map.WindowSize.Height - 32),
                Size = new Size(map.WindowSize.Width, 32),
                BackColor = Color.White
            };

            time = new Timer();
            time.Interval = LvlNum < 5 ? 300 - LvlNum * 50 : 50;
            time.Tick += Tick;
            time.Start();
        }

        public void StartNextLvl()
        {
            var lvl = new Game(menu, LvlNum + 1);
            time.Stop();
            lvl.Show();
            Hide();
        }

        public void Break()
        {
            time.Stop();
            System.Threading.Thread.Sleep(3000);
            menu.Show();
            Close();
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
