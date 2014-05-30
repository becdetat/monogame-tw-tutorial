using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using ShooterGame.Windows.Configuration;
using ShooterGame.Windows.Core;
using ShooterGame.Windows.Extensions;
using ShooterGame.Windows.Sprites.EnemySprite;
using ShooterGame.Windows.Sprites.PlayerSprite;

namespace ShooterGame.Windows
{
    public class ShooterGame : Game
    {
        private IPlayer _player;
        private GamePadState _currentGamePadState;
        private GamePadState _previousGamePadState;
        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;
        private MouseState _currentMouseState;
        private MouseState _previousMouseState;
        IParallaxingBackground _background1;
        IParallaxingBackground _background2;
        private ITexture2D _mainBackground;
        private Rectangle _mainBackgroundRect;
        private readonly ICollection<IEnemy> _enemies = new Collection<IEnemy>();
        private TimeSpan _enemySpawnTime = TimeSpan.FromSeconds(1);
        private TimeSpan _previousEnemySpawnTime = TimeSpan.Zero;
        readonly Random _random = new Random();
        private IContainer _container;
        private ISpriteBatch _spriteBatch;
        private IEnemyFactory _enemyFactory;
        private readonly GraphicsDeviceManager _graphics;

        public ShooterGame()
        {
            _graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            TouchPanel.EnabledGestures = GestureType.FreeDrag;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _container = AutofacConfig.Register(this);

            _spriteBatch = _container.Resolve<ISpriteBatch>();
            _enemyFactory = _container.Resolve<IEnemyFactory>();

            _player = _container.Resolve<IPlayer>();

            var contentManager = _container.Resolve<IContentManager>();
            var parallaxingBackgroundFactory = _container.Resolve<IParallaxingBackgroundFactory>();

            _background1 = parallaxingBackgroundFactory.Build(contentManager.Load("Graphics/bgLayer1"), -1,
                GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            _background2 = parallaxingBackgroundFactory.Build(contentManager.Load("Graphics/bgLayer2"), -2,
                GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            _mainBackground = contentManager.Load("Graphics/mainBackground");
            _mainBackgroundRect = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        }

        void AddEmemy()
        {
            var enemy = _enemyFactory.Build();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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
                gameTime);
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
                enemy.Draw(gameTime);
            }

            _player.Draw(gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
