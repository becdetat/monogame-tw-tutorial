using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using ShooterGame.Windows.Configuration;
using ShooterGame.Windows.Core;

namespace ShooterGame.Windows.Sprites.PlayerSprite
{
    public class Player : Sprite, IPlayer, IRegistering
    {
        private readonly IAnimation _animation;
        private bool _active = true;
        private int _health = 100;
        private readonly Viewport _viewport;
        private Vector2 _velocity = Vector2.Zero;

        public Player(IContentManager contentManager, IViewport viewport, IAnimationFactory animationFactory, ISpriteBatch spriteBatch)
            : base(spriteBatch)
        {
            _viewport = viewport.Viewport;
            _animation = animationFactory.Build(
                contentManager.Load(@"Graphics\shipAnimation"),
                115, 30, 8);

            Position = new Vector2(_viewport.TitleSafeArea.X, _viewport.TitleSafeArea.Y + _viewport.TitleSafeArea.Height / 2);

            BeforeDraw += time => _animation.Update(time);
            BeforeUpdate += state =>
            {
                if (_health <= 0)
                {
                    _active = false;
                }
                UpdatePosition(state);
            };
        }

        protected override float SpeedMultiplier
        {
            get { return 8.0f; }
        }

        protected override Vector2 Velocity
        {
            get { return _velocity; }
        }

        protected override IDrawMyself Drawable
        {
            get { return _animation; }
        }

        private void UpdatePosition(ShooterGameInputState gameInputState)
        {
            var dx = 0.0f;
            var dy = 0.0f;

            dx += gameInputState.CurrentGamePadState.ThumbSticks.Left.X;
            dy -= gameInputState.CurrentGamePadState.ThumbSticks.Left.Y;

            if (gameInputState.CurrentKeyboardState.IsKeyDown(Keys.Left) ||
                gameInputState.CurrentGamePadState.DPad.Left == ButtonState.Pressed)
            {
                dx--;
            }
            if (gameInputState.CurrentKeyboardState.IsKeyDown(Keys.Right) ||
                gameInputState.CurrentGamePadState.DPad.Right == ButtonState.Pressed)
            {
                dx ++;
            }

            if (gameInputState.CurrentKeyboardState.IsKeyDown(Keys.Up) ||
                gameInputState.CurrentGamePadState.DPad.Up == ButtonState.Pressed)
            {
                dy --;
            }
            if (gameInputState.CurrentKeyboardState.IsKeyDown(Keys.Down) ||
                gameInputState.CurrentGamePadState.DPad.Down == ButtonState.Pressed)
            {
                dy ++;
            }

            while (gameInputState.CurrentTouchPanelState.IsGestureAvailable)
            {
                var gesture = gameInputState.CurrentTouchPanelState.ReadGesture();
                if (gesture.GestureType == GestureType.FreeDrag)
                {
                    // TODO this will need to be sanitised
                    dx += gesture.Delta.X;
                    dy += gesture.Delta.Y;
                }
            }

            if (gameInputState.CurrentMouseState.LeftButton == ButtonState.Pressed)
            {
                var mousePosition = new Vector2(gameInputState.CurrentMouseState.X, gameInputState.CurrentMouseState.Y);
                var mousePositionDelta = mousePosition - Position;
                mousePositionDelta.Normalize();

                // TODO this will need to be sanitised
                dx += mousePositionDelta.X;
                dy += mousePositionDelta.Y;
            }

            _velocity = new Vector2(dx, dy);
        }

        public override Rectangle GetBounds()
        {
            return new Rectangle(
                (int) Position.X,
                (int) Position.Y,
                _animation.FrameHeight,
                _animation.FrameWidth);
        }

        public void ReceiveDamage(int points)
        {
            _health -= points;
        }
    }
}