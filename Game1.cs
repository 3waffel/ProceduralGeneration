using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace monogame_demo
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _roomTexture;
        private Texture2D _playerTexture;

        //private List<Rectangle> _partitions;

        private Rectangle _spaceBounds;

        private Player _player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // Set the screen size
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            _roomTexture = new Texture2D(GraphicsDevice, 100, 100);
            Generator.GenerateTexture(_roomTexture);
            _playerTexture = new Texture2D(GraphicsDevice, 10, 10);
            Generator.GenerateTexture(_playerTexture);

            _player = new Player(0, 0, 1);

            _spaceBounds = new Rectangle(0, 0, 800, 600);

            // BSPNode root = Generator.BinarySpacePartition(_spaceBounds, 0, 5, 5, 20);
            // _partitions = Generator.GetRoomRectangles(root);

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _player.Move(-1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _player.Move(1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _player.Move(0, -1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _player.Move(0, 1);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGoldenrodYellow);

            _spriteBatch.Begin();

            // foreach (Rectangle partition in _partitions)
            // {
            //     _spriteBatch.Draw(_roomTexture, partition, Color.White);
            // }

            _spriteBatch.Draw(_playerTexture, new Rectangle(_player.PositionX, _player.PositionY, 10, 10), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
