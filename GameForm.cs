using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace snake
{
    class GameForm : Form
    {
        Timer time;
        Cell[,] map;
        Snake snake;
        Direction direction = Direction.Right;

        public GameForm()
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterScreen;
            BackgroundImage = Image.FromFile("..//..//res//tex//Wall.png");
            BackgroundImageLayout = ImageLayout.Tile;
            DoubleBuffered = true;

            map = CreateMap(File.ReadAllLines("..//..//res//lvl//1.txt"));
            Size = new Size(map.GetLength(0)*32, map.GetLength(1)*32);

            snake = new Snake();

            KeyDown += GameForm_KeyDown;

            time = new Timer();
            time.Interval = 200;
            time.Tick += Tick;
            time.Start();
        }

        Cell[,] CreateMap(string[] lines)
        {
            var res = new Cell[lines[0].Length, lines.Length];
            for (int i = 0; i < res.GetLength(0); i++)
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    switch (lines[j][i])
                    {
                        case ' ': res[i, j] = null;
                            continue;
                        case 'S': res[i, j] = new Stone(i, j);
                            continue;
                    }
                }
            return res;
        }

        void Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint (PaintEventArgs e)
        {
            foreach(var cell in map)
                if(cell != null) cell.Draw(e.Graphics);
        }



        void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    direction = Direction.Up;
                    break;
                case Keys.Down:
                    direction = Direction.Down;
                    break;
                case Keys.Left:
                    direction = Direction.Left;
                    break;
                case Keys.Right:
                    direction = Direction.Right;
                    break;
            }
        }
    }
}
