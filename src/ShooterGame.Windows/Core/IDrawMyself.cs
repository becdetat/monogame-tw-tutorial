using Microsoft.Xna.Framework;

namespace ShooterGame.Windows.Core
{
    public interface IDrawMyself
    {
        void Draw(ISpriteBatch spriteBatch, Vector2 position);
    }
}