using Microsoft.Xna.Framework;

namespace Win8ShooterGame.Core
{
    public interface IAnimation : IDrawMyself
    {
        int FrameWidth { get; }
        int FrameHeight { get; }
        void Update(GameTime gameTime);
    }
}