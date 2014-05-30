using Microsoft.Xna.Framework;

namespace ShooterGame.Windows.Core
{
    public abstract class Sprite : ISprite
    {
        private readonly ISpriteBatch _spriteBatch;
        private Vector2 _position = Vector2.Zero;

        protected Sprite(ISpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        protected abstract float SpeedMultiplier { get; }
        protected abstract Vector2 Velocity { get; }
        protected abstract IDrawMyself Drawable { get; }

        protected Vector2 Position
        {
            get { return _position; }
        }

        protected event BeforeUpdateHandler BeforeUpdate;
        protected event AfterUpdateHandler AfterUpdate;
        protected event BeforeDrawHandler BeforeDraw;
        protected event AfterDrawHandler AfterDraw;

        public void Update(ShooterGameInputState state)
        {
            if (BeforeUpdate != null)
            {
                BeforeUpdate(state);
            }

            _position.X += Velocity.X*SpeedMultiplier;
            _position.Y += Velocity.Y*SpeedMultiplier;

            if (AfterUpdate != null)
            {
                AfterUpdate(state);
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (BeforeDraw != null)
            {
                BeforeDraw(gameTime);
            }

            Drawable.Draw(_spriteBatch, _position);

            if (AfterDraw != null)
            {
                AfterDraw(gameTime);
            }
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        protected delegate void AfterDrawHandler(GameTime gameTime);

        protected delegate void AfterUpdateHandler(ShooterGameInputState state);

        protected delegate void BeforeDrawHandler(GameTime gameTime);

        protected delegate void BeforeUpdateHandler(ShooterGameInputState state);

        public abstract Rectangle GetBounds();
    }
}