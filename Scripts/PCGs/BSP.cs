using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_demo
{
    public static class BSPSnippet
    {
        /// <summary>
        /// Binary Space Partition
        /// </summary>
        /// <param name="bounds"></param>
        /// <param name="seed"></param>
        /// <param name="maxDepth"></param>
        /// <param name="minRoomSize"></param>
        /// <param name="maxRoomSize"></param>
        /// <returns></returns>
        public static BSPNode
        BinarySpacePartition(
            Rectangle bounds,
            int seed,
            int maxDepth,
            int minRoomSize,
            int maxRoomSize
        )
        {
            Random random = new Random(seed);
            BSPNode root = new BSPNode(bounds);
            if (maxDepth <= 0)
            {
                return root;
            }
            if (
                root.Rectangle.Width > minRoomSize &&
                root.Rectangle.Height > minRoomSize
            )
            {
                int split = random.Next(0, 2);
                if (split == 0)
                {
                    root.SplitHorizontal(random.Next(minRoomSize, maxRoomSize));
                }
                else if (split == 1)
                {
                    root.SplitVertical(random.Next(minRoomSize, maxRoomSize));
                }
            }
            if (root.Left != null)
            {
                root.Left =
                    BinarySpacePartition(root.Left.Rectangle,
                    seed + 1,
                    maxDepth - 1,
                    minRoomSize,
                    maxRoomSize);
            }
            if (root.Right != null)
            {
                root.Right =
                    BinarySpacePartition(root.Right.Rectangle,
                    seed - 1,
                    maxDepth - 1,
                    minRoomSize,
                    maxRoomSize);
            }
            return root;
        }

        /// <summary>
        /// Get the list of rooms from the BSP tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<Rectangle> GetRectanglesList(BSPNode root)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            if (root.Left != null)
            {
                rectangles.AddRange(GetRectanglesList(root.Left));
            }
            if (root.Right != null)
            {
                rectangles.AddRange(GetRectanglesList(root.Right));
            }
            if (root.Left == null && root.Right == null)
            {
                rectangles.Add(root.Rectangle);
            }
            return rectangles;
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
            get
            {
                return _left;
            }
            set
            {
                _left = value;
            }
        }

        public BSPNode Right
        {
            get
            {
                return _right;
            }
            set
            {
                _right = value;
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

        public void SplitHorizontal(int split)
        {
            _left =
                new BSPNode(new Rectangle(_rectangle.X,
                        _rectangle.Y,
                        split,
                        _rectangle.Height));
            _right =
                new BSPNode(new Rectangle(_rectangle.X + split,
                        _rectangle.Y,
                        _rectangle.Width - split,
                        _rectangle.Height));
        }

        public void SplitVertical(int split)
        {
            _left =
                new BSPNode(new Rectangle(_rectangle.X,
                        _rectangle.Y,
                        _rectangle.Width,
                        split));
            _right =
                new BSPNode(new Rectangle(_rectangle.X,
                        _rectangle.Y + split,
                        _rectangle.Width,
                        _rectangle.Height - split));
        }
    }
}
