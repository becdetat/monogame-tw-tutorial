using Microsoft.Xna.Framework;

namespace Win8ShooterGame.Core
{
    public interface IAnimation
    {
        int FrameWidth { get; }
        int FrameHeight { get; }
        void Update(GameTime gameTime);
        void Draw(ISpriteBatch spriteBatch, Vector2 position);
    }
}