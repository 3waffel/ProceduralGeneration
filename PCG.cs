using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;


namespace monogame_demo
{
    /// <summary>
    /// Generator 
    /// </summary>
    public static class Generator
    {
        public static void GenerateTexture(Texture2D texture)
        {
            //generate a black border
            int[,] map = new int[texture.Width, texture.Height];
            Color[] data = new Color[texture.Width * texture.Height];
            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    if (x == 0 || x == texture.Width - 1 || y == 0 || y == texture.Height - 1)
                    {
                        map[x, y] = 1;
                        data[x + y * texture.Width] = Color.Black;
                    }
                    else
                    {
                        map[x, y] = 0;
                        data[x + y * texture.Width] = Color.White;
                    }

                }
            }
            texture.SetData(data);
        }

        public static void GenerateRooms(List<Room> rooms, int seed, int minWidth, int minHeight, int maxWidth, int maxHeight, int maxRooms, int maxAttempts)
        {

        }

        public static BSPNode BinarySpacePartition(Rectangle bounds, int seed, int maxDepth, int minRoomSize, int maxRoomSize)
        {
            System.Console.WriteLine("BSP: " + maxDepth);
            Random random = new Random(seed);
            BSPNode root = new BSPNode(bounds);
            if (maxDepth <= 0)
            {
                return root;
            }
            if (root.Rectangle.Width > minRoomSize && root.Rectangle.Height > minRoomSize)
            {
                int split = random.Next(0, 3);
                if (split == 0)
                {
                    root.SplitHorizontal(random.Next(minRoomSize, maxRoomSize));
                }
                else if (split == 1)
                {
                    root.SplitVertical(random.Next(minRoomSize, maxRoomSize));
                }
            }
            root.Left = BinarySpacePartition(root.Left.Rectangle, seed, maxDepth - 1, minRoomSize, maxRoomSize);
            root.Right = BinarySpacePartition(root.Right.Rectangle, seed, maxDepth - 1, minRoomSize, maxRoomSize);
            return root;
        }

        public static List<Rectangle> GetRoomRectangles(BSPNode root)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            if (root.Left != null)
            {
                rectangles.AddRange(GetRoomRectangles(root.Left));
            }
            if (root.Right != null)
            {
                rectangles.AddRange(GetRoomRectangles(root.Right));
            }
            if (root.Left == null && root.Right == null)
            {
                rectangles.Add(root.Rectangle);
            }
            return rectangles;
        }

    }

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
            get { return _rectangle.X; }
            set { _rectangle.X = value; }
        }

        public int Y
        {
            get { return _rectangle.Y; }
            set { _rectangle.Y = value; }
        }

        public int Width
        {
            get { return _rectangle.Width; }
            set { _rectangle.Width = value; }
        }

        public int Height
        {
            get { return _rectangle.Height; }
            set { _rectangle.Height = value; }
        }

        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set { _rectangle = value; }
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
            get { return _positionX; }
            set { _positionX = value; }
        }

        public int PositionY
        {
            get { return _positionY; }
            set { _positionY = value; }
        }

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public void Move(int x, int y)
        {
            _positionX += x * _speed;
            _positionY += y * _speed;
        }

    }

    /// <summary>
    /// Binary Space Partition Node
    /// </summary>
    public class BSPNode 
    {
        protected BSPNode _left;
        protected BSPNode _right;
        protected Rectangle _rectangle;

        public BSPNode(Rectangle rect)
        {
            _rectangle = rect;
            _left = null;
            _right = null;
        }

        public BSPNode Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public BSPNode Right
        {
            get { return _right; }
            set { _right = value; }
        }
        
        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }

        public void SplitHorizontal(int split)
        {
            _left = new BSPNode(new Rectangle(_rectangle.X, _rectangle.Y, split, _rectangle.Height));
            _right = new BSPNode(new Rectangle(_rectangle.X + split, _rectangle.Y, _rectangle.Width - split, _rectangle.Height));
        }

        public void SplitVertical(int split)
        {
            _left = new BSPNode(new Rectangle(_rectangle.X, _rectangle.Y, _rectangle.Width, split));
            _right = new BSPNode(new Rectangle(_rectangle.X, _rectangle.Y + split, _rectangle.Width, _rectangle.Height - split));
        }
    }

}