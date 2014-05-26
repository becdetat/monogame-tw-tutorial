using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Win8ShooterGame.Configuration;
using Win8ShooterGame.Core;

namespace Win8ShooterGame.Actors.PlayerActor
{
    public class Player : IPlayer, IRegistering
    {
        private const float Speed = 8.0f;
        private readonly IAnimation _animation;
        private bool _active = true;
        private int _health = 100;
        private Vector2 _position;

        public Player(IContentManager contentManager, IViewport viewport, IAnimationFactory animationFactory)
        {
            _animation = animationFactory.Build(
                contentManager.Load(@"Graphics\shipAnimation"),
                115, 30, 8);

            _position = new Vector2(viewport.TitleSafeArea.X, viewport.TitleSafeArea.Y + viewport.TitleSafeArea.Height/2);
        }

        private int Width
        {
            get { return _animation.FrameWidth; }
        }

        private int Height
        {
            get { return _animation.FrameHeight; }
        }

        public void Draw(GameTime gameTime, ISpriteBatch spriteBatch)
        {
            _animation.Update(gameTime);
            _animation.Draw(spriteBatch, _position);
        }

        public void Update(ShooterGameInputState gameInputState)
        {
            if (_health <= 0)
            {
                _active = false;
            }

            UpdatePosition(gameInputState);
        }

        private void UpdatePosition(ShooterGameInputState gameInputState)
        {
            var dx = 0.0f;
            var dy = 0.0f;

            dx += gameInputState.CurrentGamePadState.ThumbSticks.Left.X*Speed;
            dy -= gameInputState.CurrentGamePadState.ThumbSticks.Left.Y*Speed;

            if (gameInputState.CurrentKeyboardState.IsKeyDown(Keys.Left) ||
                gameInputState.CurrentGamePadState.DPad.Left == ButtonState.Pressed)
            {
                dx -= Speed;
            }
            if (gameInputState.CurrentKeyboardState.IsKeyDown(Keys.Right) ||
                gameInputState.CurrentGamePadState.DPad.Right == ButtonState.Pressed)
            {
                dx += Speed;
            }

            if (gameInputState.CurrentKeyboardState.IsKeyDown(Keys.Up) ||
                gameInputState.CurrentGamePadState.DPad.Up == ButtonState.Pressed)
            {
                dy -= Speed;
            }
            if (gameInputState.CurrentKeyboardState.IsKeyDown(Keys.Down) ||
                gameInputState.CurrentGamePadState.DPad.Down == ButtonState.Pressed)
            {
                dy += Speed;
            }

            while (TouchPanel.IsGestureAvailable)
            {
                var gesture = TouchPanel.ReadGesture();
                if (gesture.GestureType == GestureType.FreeDrag)
                {
                    dx += gesture.Delta.X;
                    dy += gesture.Delta.Y;
                }
            }

            if (gameInputState.CurrentMouseState.LeftButton == ButtonState.Pressed)
            {
                var mousePosition = new Vector2(gameInputState.CurrentMouseState.X, gameInputState.CurrentMouseState.Y);
                var mousePositionDelta = mousePosition - _position;
                mousePositionDelta.Normalize();
                mousePositionDelta = mousePositionDelta*Speed;

                dx += mousePositionDelta.X;
                dy += mousePositionDelta.Y;
            }

            _position.X = MathHelper.Clamp(_position.X + dx, 0, gameInputState.Viewport.Width - Width);
            _position.Y = MathHelper.Clamp(_position.Y + dy, 0, gameInputState.Viewport.Height - Height);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(
                (int) _position.X,
                (int) _position.Y,
                _animation.FrameHeight,
                _animation.FrameWidth);
        }

        public void ReceiveDamage(int points)
        {
            _health -= points;
        }
    }
}