using System;
using Microsoft.Xna.Framework;

namespace ShooterGame.Windows.Core
{
    public abstract class Sprite : ISprite
    {
        private readonly ISpriteBatch _spriteBatch;

        protected Sprite(ISpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            Position = Vector2.Zero;
        }

        public abstract float Speed { get; }
        protected abstract Vector2 Velocity { get; }
        protected abstract IDrawMyself Drawable { get; }

        public void Update(ShooterGameInputState state)
        {
            if (BeforeUpdate != null)
            {
                BeforeUpdate(state);
            }

            var deltaX = Velocity.X*Speed;
            var deltaY = Velocity.Y*Speed;

            var newPosition = Position + new Vector2(deltaX, deltaY);
            if (CheckNewPosition(newPosition))
            {
                Position = newPosition;
            }

            if (AfterUpdate != null)
            {
                AfterUpdate(state);
            }
        }

        protected virtual bool CheckNewPosition(Vector2 newPosition)
        {
            return true;
        }

        public void Draw(GameTime gameTime)
        {
            if (BeforeDraw != null)
            {
                BeforeDraw(gameTime);
            }

            Drawable.Draw(_spriteBatch, Position);

            if (AfterDraw != null)
            {
                AfterDraw(gameTime);
            }
        }

        public Vector2 Position { get; set; }
        public abstract Rectangle GetBounds();

        protected event BeforeUpdateHandler BeforeUpdate;
        protected event AfterUpdateHandler AfterUpdate;
        protected event BeforeDrawHandler BeforeDraw;
        protected event AfterDrawHandler AfterDraw;

        protected delegate void AfterDrawHandler(GameTime gameTime);

        protected delegate void AfterUpdateHandler(ShooterGameInputState state);

        protected delegate void BeforeDrawHandler(GameTime gameTime);

        protected delegate void BeforeUpdateHandler(ShooterGameInputState state);
    }
}