using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace snake
{
    class Snake
    {
        Queue<Body> pieces = new Queue<Body>();
        public Direction Direction { get; set; }
        bool isGrowing;

        readonly Map map;
        readonly Game game;

        public Snake(Map map, Game game, int length, int x = 1, int y = 1)
        {
            this.map = map;
            this.game = game;
            Direction = Direction.Right;
            var piece = new Body(x, y);
            for (int i = 0; i < length; i++)
            {
                pieces.Enqueue(piece);
                piece = CreateNext(piece, Direction);
            }
        }

        public void Move()
        {
            pieces.Enqueue(CreateNext(pieces.Last(), Direction));
            if (!isGrowing) pieces.Dequeue();
            isGrowing = false;
        }

        public void Draw(Graphics g)
        {
            foreach (var p in pieces) p.Draw(g);
        }

        public Body CreateNext(Body current, Direction direction)
        {
            Body nextPart = current;
            switch(direction)
            {
                case Direction.Right:
                    nextPart = new Body(current.X + 1, current.Y);
                    break;
                case Direction.Left:
                    nextPart = new Body(current.X - 1, current.Y);
                    break;
                case Direction.Up:
                    nextPart = new Body(current.X, current.Y - 1);
                    break;
                case Direction.Down:
                    nextPart = new Body(current.X, current.Y + 1);
                    break;
            }
            if (map.Cells[nextPart.X, nextPart.Y] is Stone)
            {
                game.Break();
                return null;
            }
            if (map.Cells[nextPart.X, nextPart.Y] is Food)
            {
                isGrowing = true;
                map.Cells[nextPart.X, nextPart.Y] = null;
                map.CreateFood();
            }
            return nextPart;
        }
    }
}
