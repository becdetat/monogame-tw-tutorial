using Microsoft.Xna.Framework;

namespace ShooterGame.Windows.Core
{
    public interface IParallaxingBackground
    {
        void Update(GameTime gameTime);
        void Draw(ISpriteBatch spriteBatch);
    }
}