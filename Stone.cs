using System.Drawing;

namespace snake
{
    internal class Stone : ICell
    {
        Image texture;
        Rectangle rect;

        public Stone(int x, int y)
        {
            texture = Image.FromFile("res//Stone.png");
            rect = new Rectangle(x, y, 32, 32);
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(texture, rect);
        }
    }
}