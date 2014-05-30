using ShooterGame.Windows.Core;

namespace ShooterGame.Windows.Sprites.PlayerSprite
{
    public interface IPlayer : ISprite
    {
        void ReceiveDamage(int famage);
    }
}