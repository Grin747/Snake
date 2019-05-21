using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Snake
    {
        public Queue<Body> pieces = new Queue<Body>();

        public Snake(int x, int y, int length, Direction direction)
        {
            var piece = new Body(x, y);
            for (int i = 0; i < length; i++)
            {
                pieces.Enqueue(piece);
                piece = CreateNext(piece, direction);
            }
        }

        public void Move(Direction direction)
        {
            pieces.Enqueue(CreateNext(pieces.Last(), direction));
            pieces.Dequeue();
        }

        public void Draw(Graphics g)
        {
            foreach (var p in pieces) p.Draw(g);
        }

        public Body CreateNext(Body current, Direction direction)
        {
            return new Body(current.X + 1, current.Y);
        }
    }
}
