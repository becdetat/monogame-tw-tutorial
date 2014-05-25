using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Win8ShooterGame
{
    public class Enemy : ISprite
    {
        private readonly Animation _animation = new Animation();
        public int Damage{get { return 10; }}
        private int _health = 10;
        private Vector2 _position;
        private int _scoreValue = 100;
        private float _speed = 6.0f;

        public Enemy()
        {
            IsActive = true;
        }

        public bool IsActive { get; private set; }

        public int Width
        {
            get { return _animation.FrameWidth; }
        }

        public void Initialize(Func<string, Texture2D> getTexture, Viewport viewport)
        {
            var texture = getTexture("Graphics/mineAnimation");
            _animation.Initialize(texture, 47, 30, 8);
        }

        public void Update(ShooterGameInputState input)
        {
            _position.X -= _speed;

            if (_position.X < -Width || _health <= 0)
            {
                IsActive = false;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            _animation.Update(gameTime, _position);
            _animation.Draw(batch);
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(
                (int)_position.X,
                (int)_position.Y,
                _animation.FrameHeight,
                _animation.FrameWidth);
        }

        public void Destroy()
        {
            _health = 0;
        }
    }
}