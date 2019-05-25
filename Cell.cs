using System.Drawing;

namespace snake
{
    public abstract class Cell
    {
        Rectangle rect;
        Image texture;

        public int X => rect.X / 32;
        public int Y => rect.Y / 32;

        public Cell(int x, int y, Image img)
        {
            texture = img;
            rect = new Rectangle(x * 32, y * 32, 32, 32);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(texture, rect);
        }

        public void Draw(Graphics g, Rectangle rect)
        {
            g.DrawImage(texture, rect);
        }
    }
}