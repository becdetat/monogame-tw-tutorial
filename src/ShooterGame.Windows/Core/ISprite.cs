using Microsoft.Xna.Framework;

namespace ShooterGame.Windows.Core
{
    public interface ISprite
    {
        void Draw(GameTime gameTime);
        Vector2 Position { get; set; }
        Rectangle GetBounds();
        void Update(ShooterGameInputState state);
    }
}