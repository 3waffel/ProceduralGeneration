using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_demo
{
    public static class AssetUtils
    {
        /// <summary>
        /// Generate a texture for room and player in a computational way
        /// </summary>
        /// <param name="texture"></param>
        public static void InitializeTexture(Texture2D texture)
        {
            Color[] data = new Color[texture.Width * texture.Height];
            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    if (
                        x == 0 ||
                        x == texture.Width - 1 ||
                        y == 0 ||
                        y == texture.Height - 1
                    )
                    {
                        data[x + y * texture.Width] = Color.Black;
                    }
                    else
                    {
                        data[x + y * texture.Width] = Color.White;
                    }
                }
            }
            texture.SetData (data);
        }

        public static Texture2D GenerateTexture(GraphicsDevice graphicsDevice, int width, int height)
        {
            Texture2D texture = new Texture2D(graphicsDevice, width, height);
            InitializeTexture(texture);
            return texture;
        }
    }
}
