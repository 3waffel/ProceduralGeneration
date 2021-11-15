using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_demo
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        private SpriteFont _font;

        private Effect _simpleEffect;

        private Texture2D _roomTexture;

        private Texture2D _playerTexture;

        private Rectangle _spaceBounds;

        private List<Rectangle> _partitions;

        private Player _player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            _roomTexture = new Texture2D(GraphicsDevice, 100, 100);
            Generator.GenerateTexture (_roomTexture);
            _playerTexture = new Texture2D(GraphicsDevice, 10, 10);
            Generator.GenerateTexture (_playerTexture);

            _spaceBounds = new Rectangle(0, 0, 800, 600);

            BSPNode root =
                Generator.BinarySpacePartition(_spaceBounds, 0, 10, 50, 200);
            _partitions = Generator.GetRectanglesList(root);

            _player = new Player(0, 0, 1);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("Fonts/SimpleFont");
            _simpleEffect = Content.Load<Effect>("Shaders/SimpleShader");
        }

        protected override void Update(GameTime gameTime)
        {
            if (
                GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape)
            ) Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                _player.Speed = 3;
            else
                _player.Speed = 1;

            if (
                Keyboard.GetState().IsKeyDown(Keys.Left) ||
                Keyboard.GetState().IsKeyDown(Keys.A)
            )
            {
                _player.Move(-1, 0);
            }
            if (
                Keyboard.GetState().IsKeyDown(Keys.Right) ||
                Keyboard.GetState().IsKeyDown(Keys.D)
            )
            {
                _player.Move(1, 0);
            }
            if (
                Keyboard.GetState().IsKeyDown(Keys.Up) ||
                Keyboard.GetState().IsKeyDown(Keys.W)
            )
            {
                _player.Move(0, -1);
            }
            if (
                Keyboard.GetState().IsKeyDown(Keys.Down) ||
                Keyboard.GetState().IsKeyDown(Keys.S)
            )
            {
                _player.Move(0, 1);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGoldenrodYellow);

            _spriteBatch
                .Begin(SpriteSortMode.Deferred,
                BlendState.Opaque,
                SamplerState.PointClamp);

            // Draw the partitions
            foreach (Rectangle partition in _partitions)
            {
                _spriteBatch.Draw(_roomTexture, partition, Color.White);
                if (
                    partition
                        .Intersects(new Rectangle(_player.PositionX,
                            _player.PositionY,
                            10,
                            10))
                )
                {
                    _spriteBatch.Draw(_roomTexture, partition, Color.RoyalBlue);
                }
            }

            // Draw the player
            _spriteBatch
                .Draw(_playerTexture,
                new Rectangle(_player.PositionX, _player.PositionY, 10, 10),
                Color.Coral);
            _spriteBatch.End();

            _spriteBatch.Begin();

            // Draw count of the partitions
            _spriteBatch
                .DrawString(_font,
                _partitions.Count.ToString(),
                new Vector2(10, 10),
                Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
