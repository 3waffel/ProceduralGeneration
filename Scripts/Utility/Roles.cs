using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        Texture2D _texture;

        public Room(int x, int y, int w, int h)
        {
            //TODO: rectangle will stop the player
            _rectangle = new Rectangle(x, y, w, h);
        }

        public Room(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public int X
        {
            get => _rectangle.X;
            set => _rectangle.X = value;
        }

        public int Y
        {
            get => _rectangle.Y;
            set => _rectangle.Y = value;
        }

        public int Width
        {
            get => _rectangle.Width;
            set => _rectangle.Width = value;
        }

        public int Height
        {
            get => _rectangle.Height;
            set => _rectangle.Height = value;
        }

        public Rectangle Rectangle
        {
            get => _rectangle;
            set => _rectangle = value;
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

        Texture2D _texture;

        public Player(int x, int y, int speed)
        {
            _positionX = x;
            _positionY = y;
            _speed = speed;
        }

        public void SetTexture(Texture2D texture)
        {
            _texture = texture;
        }

        public int PositionX
        {
            get => _positionX;
            set => _positionX = value;
        }

        public int PositionY
        {
            get => _positionY;
            set => _positionY = value;
        }

        public int Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public void Move(int x, int y)
        {
            _positionX += x * _speed;
            _positionY += y * _speed;
        }

        public void Reset()
        {
            _positionX = 0;
            _positionY = 0;
        }
    }
}
