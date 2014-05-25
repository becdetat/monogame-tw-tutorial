using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Windows.Storage.Streams;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Win8ShooterGame.Extensions;

namespace Win8ShooterGame
{
    public class ShooterGame : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private readonly Player _player;
        private GamePadState _currentGamePadState;
        private GamePadState _previousGamePadState;
        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;
        private MouseState _currentMouseState;
        private MouseState _previousMouseState;
        ParallaxingBackground _background1 = new ParallaxingBackground();
        ParallaxingBackground _background2 = new ParallaxingBackground();
        private Texture2D _mainBackground;
        private Rectangle _mainBackgroundRect;
        private Texture2D _enemyTexture;
        private ICollection<Enemy> _enemies = new Collection<Enemy>();
        private TimeSpan _enemySpawnTime = TimeSpan.FromSeconds(1);
        private TimeSpan _previousEnemySpawnTime = TimeSpan.Zero;
        Random _random = new Random();
        IDictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();

        public ShooterGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _player = new Player();
        }

        protected override void Initialize()
        {
            TouchPanel.EnabledGestures = GestureType.FreeDrag;



            base.Initialize();
        }

        Texture2D GetTexture(string key)
        {
            if (!_textures.ContainsKey(key))
            {
                _textures[key] = Content.Load<Texture2D>(key);
            }
            return _textures[key];
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _player.Initialize(GetTexture, GraphicsDevice.Viewport);
            
            _background1.Initialize(Content.Load<Texture2D>("Graphics/bgLayer1"), -1, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            _background2.Initialize(Content.Load<Texture2D>("Graphics/bgLayer2"), -2, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            
            _mainBackground = Content.Load<Texture2D>("Graphics/mainBackground");
            _mainBackgroundRect = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        }

        void AddEmemy()
        {
            var enemy = new Enemy();
            enemy.Initialize(GetTexture, GraphicsDevice.Viewport);
            enemy.SetPosition(new Vector2(
                GraphicsDevice.Viewport.Width + enemy.Width / 2,
                _random.Next(100, GraphicsDevice.Viewport.Height - 100)));
            _enemies.Add(enemy);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            UpdateInputStates();

            var currentGameState = GetCurrentState(gameTime);

            _background1.Update(gameTime);
            _background2.Update(gameTime);

            _player.Update(currentGameState);
            UpdateEnemies(currentGameState);
            UpdateCollisions();

            base.Update(gameTime);
        }

        private void UpdateCollisions()
        {
            var playerRectangle = _player.GetBounds();

            foreach (var enemy in _enemies)
            {
                if (playerRectangle.Intersects(enemy.GetBounds()))
                {
                    _player.ReceiveDamage(enemy.Damage);
                    enemy.Destroy();
                }
            }
        }

        private void UpdateEnemies(ShooterGameInputState input)
        {
            if (input.GameTime.TotalGameTime - _previousEnemySpawnTime > _enemySpawnTime)
            {
                _previousEnemySpawnTime = input.GameTime.TotalGameTime;
                AddEmemy();
            }

            foreach (var enemy in _enemies)
            {
                enemy.Update(input);
            }

            _enemies.RemoveWhere(x => !x.IsActive);
        }

        private void UpdateInputStates()
        {
            _previousGamePadState = _currentGamePadState;
            _currentGamePadState = GamePad.GetState(PlayerIndex.One);
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
        }

        private ShooterGameInputState GetCurrentState(GameTime gameTime)
        {
            return new ShooterGameInputState(
                _currentGamePadState, 
                _previousGamePadState, 
                _currentKeyboardState, 
                _previousKeyboardState, 
                _currentMouseState, 
                _previousMouseState, 
                gameTime, 
                GraphicsDevice.Viewport);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_mainBackground, _mainBackgroundRect, Color.White);
            _background1.Draw(_spriteBatch);
            _background2.Draw(_spriteBatch);

            foreach (var enemy in _enemies)
            {
                enemy.Draw(gameTime, _spriteBatch);
            }

            _player.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
