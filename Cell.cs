using System.Drawing;

namespace snake
{
    public abstract class Cell
    {
        public const int Resolution = 64;

        Rectangle rect;
        Image texture;

        public int X => rect.X / Resolution;
        public int Y => rect.Y / Resolution;

        public Cell(int x, int y, Image img)
        {
            texture = img;
            rect = new Rectangle(x * Resolution, y * Resolution, Resolution, Resolution);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(texture, rect);
        }

        public void Draw(Graphics g, Rectangle rect)
        {
            g.DrawImage(texture, rect);
        }

        public override bool Equals(object obj) =>
            !(obj is Cell) || (obj as Cell).X == X && (obj as Cell).Y == Y;
    }
}