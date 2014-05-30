using Microsoft.Xna.Framework;

namespace ShooterGame.Windows.Core
{
    public interface IAnimation : IDrawMyself
    {
        int FrameWidth { get; }
        int FrameHeight { get; }
        void Update(GameTime gameTime);
    }
}