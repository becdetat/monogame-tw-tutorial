using Microsoft.Xna.Framework;
using Win8ShooterGame.Core;

namespace Win8ShooterGame.Sprites.EnemySprite
{
    public interface IEnemy : ISprite
    {
        int Width { get; }
        void Destroy();
        int Damage { get; }
        bool IsActive { get; }
    }
}