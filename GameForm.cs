using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    class GameForm : Form
    {
        Timer time = new Timer();
        ICell[,] map;
        
        public GameForm()
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(962, 642);
            BackgroundImage = Image.FromFile("res//Wall.png");
            BackgroundImageLayout = ImageLayout.Tile;

            map = CreateMap(" BH ");

            time.Interval = 1000;
            time.Tick += Tick;
            time.Start();
        }

        ICell[,] CreateMap(string plan)
        {
            return null;
        }

        void Tick(object sender, EventArgs e) => Invalidate();

        void GameForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var cell in map) cell.Draw(e.Graphics);
        }

        void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
                case Keys.Left:
                    break;
                case Keys.Right:
                    break;
            }
        }
    }
}
