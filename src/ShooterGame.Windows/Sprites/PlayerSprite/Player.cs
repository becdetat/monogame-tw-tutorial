using System;
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
        private readonly IPlayerConfiguration _configuration;
        private readonly IAnimation _animation;
        private bool _active = true;
        private int _health = 100;
        private readonly Viewport _viewport;
        private Vector2 _velocity = Vector2.Zero;
        private readonly Rectangle[] _boundaries;

        public Player(IContentManager contentManager, IViewport viewport, IAnimationFactory animationFactory, ISpriteBatch spriteBatch,
            IPlayerConfiguration configuration)
            : base(spriteBatch)
        {
            _configuration = configuration;
            _viewport = viewport.Viewport;
            _animation = animationFactory.Build(
                contentManager.Load(@"Graphics\shipAnimation"),
                115, 30, 8);

            Position = new Vector2(_viewport.TitleSafeArea.X + 100, _viewport.TitleSafeArea.Y + _viewport.TitleSafeArea.Height / 2);

            BeforeDraw += time => _animation.Update(time);
            BeforeUpdate += state =>
            {
                if (_health <= 0)
                {
                    _active = false;
                }
                UpdateVelocity(state);
            };

            _boundaries = new[]
            {
                new Rectangle(-100, 0, 100 + _configuration.LeftBoundary, _viewport.Height),
                new Rectangle(_viewport.Width - _configuration.RightBoundary, 0, 100, _viewport.Height), 
                new Rectangle(0, -100, _viewport.Width, 100 + _configuration.TopBoundary), 
                new Rectangle(0, _viewport.Height - _configuration.BottomBoundary, _viewport.Width, 100), 
            };
        }

        protected override bool CheckNewPosition(Vector2 newPosition)
        {
            var newBounds = GetBoundsAt(newPosition);

            foreach (var boundary in _boundaries)
            {
                if (boundary.Intersects(newBounds))
                {
                    return false;
                }
            }

            return true;
        }

        public override float Speed
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

        private void UpdateVelocity(ShooterGameInputState gameInputState)
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
            return GetBoundsAt(Position);
        }

        protected Rectangle GetBoundsAt(Vector2 position)
        {
            return new Rectangle(
                (int) position.X - _configuration.Width / 2,
                (int) position.Y - _configuration.Height / 2,
                _configuration.Width,
                _configuration.Height);
        }

        protected int Width { get { return _configuration.Width; } }
        protected int Height { get { return _configuration.Height; } }

        public void ReceiveDamage(int points)
        {
            _health -= points;
        }
    }
}