using ShooterGame.Windows.Configuration;

namespace ShooterGame.Windows.Core
{
    public class ParallaxingBackgroundFactory : IParallaxingBackgroundFactory, IRegistering
    {
        public IParallaxingBackground Build(ITexture2D texture, int speed, int screenWidth, int screenHeight)
        {
            return new ParallaxingBackground(texture, speed, screenWidth, screenHeight);
        }
    }
}