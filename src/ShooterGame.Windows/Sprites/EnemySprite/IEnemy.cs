using ShooterGame.Windows.Core;

namespace ShooterGame.Windows.Sprites.EnemySprite
{
    public interface IEnemy : ISprite
    {
        int Width { get; }
        void Destroy();
        int Damage { get; }
        bool IsActive { get; }
    }
}