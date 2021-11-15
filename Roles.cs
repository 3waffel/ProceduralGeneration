using Microsoft.Xna.Framework;

namespace monogame_demo
{
    /// <summary>
    /// Room class (Not used)
    /// </summary>
    public class Room
    {
        protected int _id;

        public static int roomCount = 0;

        protected Rectangle _rectangle;

        public Room(int x, int y, int w, int h)
        {
            //rectangle will stop the player
            _rectangle = new Rectangle(x, y, w, h);
        }

        public Room(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public int X
        {
            get
            {
                return _rectangle.X;
            }
            set
            {
                _rectangle.X = value;
            }
        }

        public int Y
        {
            get
            {
                return _rectangle.Y;
            }
            set
            {
                _rectangle.Y = value;
            }
        }

        public int Width
        {
            get
            {
                return _rectangle.Width;
            }
            set
            {
                _rectangle.Width = value;
            }
        }

        public int Height
        {
            get
            {
                return _rectangle.Height;
            }
            set
            {
                _rectangle.Height = value;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return _rectangle;
            }
            set
            {
                _rectangle = value;
            }
        }
    }

    /// <summary>
    /// Player will be able to move around the map
    /// </summary>
    public class Player
    {
        int _positionX;

        int _positionY;

        int _speed;

        public Player(int x, int y, int speed)
        {
            _positionX = x;
            _positionY = y;
            _speed = speed;
        }

        public int PositionX
        {
            get
            {
                return _positionX;
            }
            set
            {
                _positionX = value;
            }
        }

        public int PositionY
        {
            get
            {
                return _positionY;
            }
            set
            {
                _positionY = value;
            }
        }

        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        public void Move(int x, int y)
        {
            _positionX += x * _speed;
            _positionY += y * _speed;
        }
    }
}
