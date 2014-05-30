using Microsoft.Xna.Framework;

namespace ShooterGame.Windows.Core
{
    public interface ISpriteBatch
    {
        void Draw(ITexture2D texture, Rectangle destinationRectangle, Rectangle sourceRectangle, Color color);
        void Draw(ITexture2D texture, Rectangle rectangle, Color color);
        void Begin();
        void End();
    }
}