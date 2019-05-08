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
        Point direction;
        
        public GameForm()
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterScreen;
            BackgroundImage = Image.FromFile("..//..//res//tex//Wall.png");
            BackgroundImageLayout = ImageLayout.Tile;
            DoubleBuffered = true;
            direction = new Point(1, 0);

            map = CreateMap(File.ReadAllLines("..//..//res//lvl//1.txt"));
            Size = new Size(map.GetLength(1)*32, map.GetLength(0)*32);


            time = new Timer();
            time.Interval = 1000;
            time.Tick += Tick;
            time.Start();
        }

        Cell[,] CreateMap(string[] lines)
        {
            var res = new Cell[lines.Length, lines[0].Length];
            for (int i = 0; i < lines.Length; i++)
                for (int j = 0; j < lines[i].Length; j++)
                {
                    //TODO
                    switch (lines[i][j])
                    {
                        case ' ': res[i, j] = null;
                            continue;
                        case 'S': res[i, j] = new Cell(j*32, i*32);
                            continue;
                        case 'B':
                            continue;
                    }
                }
            return res;
        }

        void Tick(object sender, EventArgs e) => Invalidate();

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
                    direction.X = -1;
                    direction.Y = 0;
                    break;
                case Keys.Down:
                    direction.X = 1;
                    direction.Y = 0;
                    break;
                case Keys.Left:
                    direction.X = 0;
                    direction.Y = -1;
                    break;
                case Keys.Right:
                    direction.X = 0;
                    direction.Y = 1;
                    break;
            }
        }
    }
}
