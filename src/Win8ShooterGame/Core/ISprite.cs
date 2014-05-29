using Microsoft.Xna.Framework;

namespace Win8ShooterGame.Core
{
    public interface ISprite
    {
        void Draw(GameTime gameTime);
        void SetPosition(Vector2 position);
        Rectangle GetBounds();
        void Update(ShooterGameInputState state);
    }
}