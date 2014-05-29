using Microsoft.Xna.Framework;

namespace Win8ShooterGame.Core
{
    public interface IDrawMyself
    {
        void Draw(ISpriteBatch spriteBatch, Vector2 position);
    }
}