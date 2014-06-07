using Microsoft.Xna.Framework;
using ShooterGame.Windows.Core;

namespace ShooterGame.Windows.Sprites.EnemySprite
{
    public class Enemy : Sprite, IEnemy
    {
        private readonly IAnimation _animation;

        protected override Vector2 Velocity
        {
            get { return new Vector2(-1, 0); }
        }

        protected override IDrawMyself Drawable
        {
            get { return _animation; }
        }

        public override float Speed
        {
            get { return 6.0f; }
        }

        private int _health = 10;
        private int _scoreValue = 100;

        public Enemy(IAnimation animation, ISpriteBatch spriteBatch)
            : base(spriteBatch)
        {
            _animation = animation;
            IsActive = true;

            BeforeUpdate += state =>
            {
                if (Position.X < -Width || _health <= 0)
                {
                    IsActive = false;
                }
            };

            BeforeDraw += time => _animation.Update(time);
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

        public override Rectangle GetBounds()
        {
            return new Rectangle(
                (int)Position.X - _animation.FrameWidth / 2,
                (int) Position.Y - _animation.FrameHeight / 2,
                _animation.FrameHeight,
                _animation.FrameWidth);
        }

        public void Destroy()
        {
            _health = 0;
        }
    }
}