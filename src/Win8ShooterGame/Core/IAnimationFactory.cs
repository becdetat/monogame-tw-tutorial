using Microsoft.Xna.Framework;

namespace Win8ShooterGame.Core
{
    public interface IAnimationFactory
    {
        IAnimation Build(ITexture2D spriteStrip, int frameWidth, int frameTime, int frameCount, bool looping = true,
            float scale = 1.0f, Color color = default(Color));
    }
}