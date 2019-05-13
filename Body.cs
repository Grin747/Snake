using System.Drawing;

namespace snake
{
    public class Body : Cell
    {
        public Body(int x, int y) : base(x, y, Image.FromFile("..//..//res//tex//Stone.png"))
        {
        }
    }
}