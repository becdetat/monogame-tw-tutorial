using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Win8ShooterGame
{
    public class Player
    {
        private float _speed = 8.0f;
        private Vector2 _position;

        public Texture2D PlayerTexture { get; private set; }
        public int Width { get { return PlayerTexture.Width; } }
        public int Height { get { return PlayerTexture.Height; } }

        public void Initialize(ContentManager content)
        {
            PlayerTexture = content.Load<Texture2D>(@"Graphics\player");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, _position, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None,
                0.0f);
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        public void Update(ShooterGameInputState gameInputState)
        {
            var dx = 0.0f;
            var dy = 0.0f;

            dx += gameInputState.CurrentGamePadState.ThumbSticks.Left.X * _speed;
            dy -= gameInputState.CurrentGamePadState.ThumbSticks.Left.Y * _speed;

            if (gameInputState.CurrentKeyboardState.IsKeyDown(Keys.Left) || gameInputState.CurrentGamePadState.DPad.Left == ButtonState.Pressed)
            {
                dx -= _speed;
            }
            if (gameInputState.CurrentKeyboardState.IsKeyDown(Keys.Right) || gameInputState.CurrentGamePadState.DPad.Right == ButtonState.Pressed)
            {
                dx += _speed;
            }

            if (gameInputState.CurrentKeyboardState.IsKeyDown(Keys.Up) || gameInputState.CurrentGamePadState.DPad.Up == ButtonState.Pressed)
            {
                dy -= _speed;
            }
            if (gameInputState.CurrentKeyboardState.IsKeyDown(Keys.Down) || gameInputState.CurrentGamePadState.DPad.Down == ButtonState.Pressed)
            {
                dy += _speed;
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
                mousePositionDelta = mousePositionDelta * _speed;

                dx += mousePositionDelta.X;
                dy += mousePositionDelta.Y;
            }

            _position.X = MathHelper.Clamp(_position.X + dx, 0, gameInputState.Viewport.Width - Width);
            _position.Y = MathHelper.Clamp(_position.Y + dy, 0, gameInputState.Viewport.Height - Height);
        }
    }
}