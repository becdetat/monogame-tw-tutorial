using Microsoft.Xna.Framework;

namespace Win8ShooterGame.Core
{
    public interface ISprite
    {
        void Draw(ISpriteBatch spriteBatch, Vector2 position);
    }
}