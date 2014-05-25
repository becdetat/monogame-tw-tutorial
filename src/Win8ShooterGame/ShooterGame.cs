using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

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

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _player.Initialize(Content, GraphicsDevice.Viewport);
            _background1.Initialize(Content.Load<Texture2D>("Graphics/bgLayer1"), -1, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            _background2.Initialize(Content.Load<Texture2D>("Graphics/bgLayer2"), -2, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            _mainBackground = Content.Load<Texture2D>("GRaphics/mainBackground");
            _mainBackgroundRect = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            UpdateInputStates();

            var currentGameState = GetCurrentState(gameTime);

            _player.Update(currentGameState);
            _background1.Update(gameTime);
            _background2.Update(gameTime);

            base.Update(gameTime);
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
            _player.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
