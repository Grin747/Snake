using System.Drawing;

namespace snake
{
    class Stone : Cell
    {
        public Stone(int x, int y) : base(x, y, Image.FromFile("..//..//res//tex//Stone.png"))
        {
        }
    }
}
