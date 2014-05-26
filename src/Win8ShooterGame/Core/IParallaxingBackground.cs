using Microsoft.Xna.Framework;

namespace Win8ShooterGame.Core
{
    public interface IParallaxingBackground
    {
        void Update(GameTime gameTime);
        void Draw(ISpriteBatch spriteBatch);
    }
}