using Microsoft.Xna.Framework;
using ShooterGame.Windows.Configuration;

namespace ShooterGame.Windows.Core
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