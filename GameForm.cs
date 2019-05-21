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
        Map map;
        Snake snake;
        Graphics g;

        public GameForm()
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.Manual;
            BackgroundImage = Image.FromFile("..//..//res//tex//Wall.png");
            BackgroundImageLayout = ImageLayout.Tile;
            DoubleBuffered = true;
            g = this.CreateGraphics();

            map = new Map(File.ReadAllLines("..//..//res//lvl//1.txt"));
            Size = map.WindowSize;

            snake = new Snake(0 , 0, 4, Direction.Right);

            time = new Timer();
            time.Interval = 1000;
            time.Tick += Tick;
            time.Start();
        }

        void Tick(object sender, EventArgs e)
        {
            Refresh();
            map.CreateFood();
            map.Draw(g);
        }
    }
}
