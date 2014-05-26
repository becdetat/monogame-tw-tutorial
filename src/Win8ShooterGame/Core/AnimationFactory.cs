using Microsoft.Xna.Framework;
using Win8ShooterGame.Configuration;

namespace Win8ShooterGame.Core
{
    public class AnimationFactory
        : IAnimationFactory, IRegistering
    {
        public IAnimation Build(ITexture2D spriteStrip, int frameWidth, int frameTime, int frameCount,
            bool looping = true,
            float scale = 1, Color color = new Color())
        {
            return new Animation(
                spriteStrip, frameWidth, frameTime, frameCount, looping, scale, color);
        }
    }
}