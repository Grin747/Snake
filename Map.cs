using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace snake
{
    class Map
    {
        public Cell[,] Cells { get; private set; }
        public Size Size { get; }
        Random rnd = new Random();

        public Map(string[] lines)
        {
            Size = new Size(lines[0].Length, lines.Length);
            Cells = new Cell[lines[0].Length, lines.Length];
            for (int i = 0; i < Cells.GetLength(0); i++)
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    switch (lines[j][i])
                    {
                        case ' ':
                            Cells[i, j] = null;
                            break;
                        case 'S':
                            Cells[i, j] = new Stone(i, j);
                            break;
                    }
                }
        }

        public void Draw(Graphics g)
        {
            foreach (var cell in Cells)
                if (cell != null)
                    cell.Draw(g);
        }

        public void CreateFood(bool running = false)
        {
            int x, y;
            do
            {
                x = rnd.Next(Cells.GetLength(0));
                y = rnd.Next(Cells.GetLength(1));
            }
            while (!(Cells[x, y] is null));
            Cells[x, y] = new Food(x, y);
        }
    }
}
