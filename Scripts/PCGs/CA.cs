using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace monogame_demo
{

    public static class CASnippet
    {

        public static void InitializeCA()
        {

        }

        public static void UpdateCA()
        {

        }

        public static void DrawCA()
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
                get
                {
                    return _positionX;
                }
                set
                {
                    _positionX = value;
                }
            }

            public float PositionY
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

        }

        public class RuleForUpdate
        {

        }


    }
}