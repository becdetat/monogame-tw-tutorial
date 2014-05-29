using Microsoft.Xna.Framework;
using Win8ShooterGame.Core;

namespace Win8ShooterGame.Sprites.PlayerSprite
{
    public interface IPlayer : ISprite
    {
        void ReceiveDamage(int famage);
    }
}