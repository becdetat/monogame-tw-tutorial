using Microsoft.Xna.Framework;
using Win8ShooterGame.Core;

namespace Win8ShooterGame.Actors.PlayerActor
{
    public interface IPlayer
    {
        void Update(ShooterGameInputState currentGameState);
        Rectangle GetBounds();
        void ReceiveDamage(int famage);
        void Draw(GameTime gameTime, ISpriteBatch spriteBatch);
    }
}