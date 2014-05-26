using Microsoft.Xna.Framework;
using Win8ShooterGame.Core;

namespace Win8ShooterGame.Actors.EnemyActor
{
    public interface IEnemy
    {
        void SetPosition(Vector2 position);
        int Width { get; }
        Rectangle GetBounds();
        void Destroy();
        int Damage { get; }
        void Update();
        bool IsActive { get; }
        void Draw(GameTime gameTime, ISpriteBatch spriteBatch);
    }
}