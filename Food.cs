using System.Drawing;

namespace snake
{
    class Food : Cell
    {
        public Food(int x, int y) : base(x, y, Image.FromFile("..//..//res//tex//Food.png"))
        {
        }
    }
}
