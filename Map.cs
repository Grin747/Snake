using System;
using System.Drawing;

namespace snake
{
    class Map
    {
        public Cell[,] Cells { get; private set; }
        public Size Size { get; }
        public Size WindowSize { get; }
        Random rnd = new Random();

        public Map(string[] lines = null)
        {
            if (lines != null)
            {
                Size = new Size(lines[0].Length, lines.Length);
                WindowSize = new Size(lines[0].Length * Cell.Resolution, lines.Length * Cell.Resolution);
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
            else
            {
                int wigth = rnd.Next(10) + 13;
                int heigth = rnd.Next(7) + 7;
                Size = new Size(wigth, heigth);
                WindowSize = new Size(Size.Width * Cell.Resolution, Size.Height * Cell.Resolution);
                Cells = new Cell[wigth, heigth];
                for (int i = rnd.Next(3) + 4; i >= 0; i--)
                {
                    int x = rnd.Next(wigth);
                    int y = rnd.Next(heigth);
                    Cells[x, y] = new Stone(x, y);
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
