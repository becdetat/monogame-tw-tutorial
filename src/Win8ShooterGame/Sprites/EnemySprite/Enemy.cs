using Microsoft.Xna.Framework;
using Win8ShooterGame.Core;

namespace Win8ShooterGame.Sprites.EnemySprite
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

        protected override float SpeedMultiplier
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
                (int) Position.X,
                (int) Position.Y,
                _animation.FrameHeight,
                _animation.FrameWidth);
        }

        public void Destroy()
        {
            _health = 0;
        }
    }
}