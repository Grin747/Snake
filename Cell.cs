using System.Drawing;

namespace snake
{
    internal class Cell
    {
        Image texture;
        Rectangle rect;

        public Cell(int x, int y)
        {
            texture = Image.FromFile("res//Stone.png");
            rect = new Rectangle(x, y, 32, 32);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(texture, rect);
        }
    }
}