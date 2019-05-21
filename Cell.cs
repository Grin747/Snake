using System.Drawing;

namespace snake
{
    public abstract class Cell
    {
        Rectangle rect;
        Image texture;

        public int X => rect.X;
        public int Y => rect.Y;

        public Cell(int x, int y, Image img)
        {
            texture = img;
            rect = new Rectangle(x * 32, y * 32, 32, 32);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(texture, rect);
        }
    }
}