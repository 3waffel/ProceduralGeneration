using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace monogame_demo
{

    public static class CASnippet
    {

        public static void InitializeCA(int width, int height, int seed, int rule, int[] initialState)
        {

        }

        public static void UpdateCA(int width, int height, int rule, int[] currentState, int[] nextState)
        {


        }

        public static void DrawCA(int width, int height, int[] currentState, SpriteBatch spriteBatch, Texture2D texture)
        {


        }


        public class CA
        {
            float _positionX, _positionY;
            float _size;
            int state;
            int previous;

            public CA(float x, float y, float size)
            {
                this._positionX = x;
                this._positionY = y;
                this._size = size;
                state = 0;
                previous = 0;
            }

            public float PositionX
            {
                get => _positionX;
                set => _positionX = value;
            }

            public float PositionY
            {
                get => _positionY;
                set => _positionY = value;
            }

            public void UpdateState(int rule, int[] currentState)
            {

            }

        }

        public class RuleForUpdate
        {
            
        }


    }
}