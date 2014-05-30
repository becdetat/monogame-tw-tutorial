using Microsoft.Xna.Framework;

namespace ShooterGame.Windows.Core
{
    public interface ISprite
    {
        void Draw(GameTime gameTime);
        void SetPosition(Vector2 position);
        Rectangle GetBounds();
        void Update(ShooterGameInputState state);
    }
}