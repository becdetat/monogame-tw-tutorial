using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Win8ShooterGame.Configuration;

namespace Win8ShooterGame.Core
{
    internal class SpriteBatchWrapper
        : ISpriteBatch, IRegistering
    {
        private readonly SpriteBatch _spriteBatch;

        public SpriteBatchWrapper(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void Draw(ITexture2D texture, Rectangle destinationRectangle, Rectangle sourceRectangle, Color color)
        {
            var underlyingTexture = ((Texture2DWrapper) texture).UnderlyingTexture;

            _spriteBatch.Draw(underlyingTexture, destinationRectangle, sourceRectangle, color);
        }

        public void Draw(ITexture2D texture, Rectangle rectangle, Color color)
        {
            var underlyingTexture = ((Texture2DWrapper)texture).UnderlyingTexture;

            _spriteBatch.Draw(underlyingTexture, rectangle, color);
        }

        public void Begin()
        {
            _spriteBatch.Begin();
        }

        public void End()
        {
            _spriteBatch.End();
        }
    }
}