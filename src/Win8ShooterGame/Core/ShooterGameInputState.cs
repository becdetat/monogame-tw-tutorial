using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Win8ShooterGame.Core
{
    public class ShooterGameInputState
    {
        public ShooterGameInputState(GamePadState currentGamePadState, GamePadState previousGamePadState,
            KeyboardState currentKeyboardState, KeyboardState previousKeyboardState, MouseState currentMouseState,
            MouseState previousMouseState, GameTime gameTime, Viewport viewport)
        {
            Viewport = viewport;
            GameTime = gameTime;
            PreviousMouseState = previousMouseState;
            CurrentMouseState = currentMouseState;
            PreviousKeyboardState = previousKeyboardState;
            CurrentKeyboardState = currentKeyboardState;
            PreviousGamePadState = previousGamePadState;
            CurrentGamePadState = currentGamePadState;
        }

        public GamePadState CurrentGamePadState { get; private set; }
        public GamePadState PreviousGamePadState { get; private set; }
        public KeyboardState CurrentKeyboardState { get; private set; }
        public KeyboardState PreviousKeyboardState { get; private set; }
        public MouseState CurrentMouseState { get; private set; }
        public MouseState PreviousMouseState { get; private set; }
        public GameTime GameTime { get; private set; }
        public Viewport Viewport { get; private set; }
    }
}