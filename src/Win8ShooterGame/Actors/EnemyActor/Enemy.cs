using Microsoft.Xna.Framework;
using Win8ShooterGame.Core;

namespace Win8ShooterGame.Actors.EnemyActor
{
    public class Enemy : IEnemy
    {
        private readonly IAnimation _animation;

        private int _health = 10;
        private Vector2 _position;
        private int _scoreValue = 100;
        private float _speed = 6.0f;

        public Enemy(IAnimation animation)
        {
            _animation = animation;
            IsActive = true;
        }

        public int Damage
        {
            get { return 10; }
        }

        public bool IsActive { get; private set; }

        public int Width
        {
            get { return _animation.FrameWidth; }
        }

        public void Update()
        {
            _position.X -= _speed;

            if (_position.X < -Width || _health <= 0)
            {
                IsActive = false;
            }
        }

        public void Draw(GameTime gameTime, ISpriteBatch batch)
        {
            _animation.Update(gameTime);
            _animation.Draw(batch, _position);
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(
                (int) _position.X,
                (int) _position.Y,
                _animation.FrameHeight,
                _animation.FrameWidth);
        }

        public void Destroy()
        {
            _health = 0;
        }
    }
}