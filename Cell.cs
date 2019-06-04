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

        public override bool Equals(object obj) =>
            !(obj is Cell) || (obj as Cell).X == X && (obj as Cell).Y == Y;

        public override int GetHashCode()
        {
            unchecked
            {
                return X * 1023 + Y;
            }
        }
    }

    public class Body : Cell
    {
        public Body(int x, int y) : base(x, y, Image.FromFile("..//..//res//tex//Body.png"))
        {
        }
    }

    class Food : Cell
    {
        public Food(int x, int y) : base(x, y, Image.FromFile("..//..//res//tex//Food.png"))
        {
        }
    }

    class Stone : Cell
    {
        public Stone(int x, int y) : base(x, y, Image.FromFile("..//..//res//tex//Stone.png"))
        {
        }
    }
}