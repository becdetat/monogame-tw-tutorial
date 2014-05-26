using Win8ShooterGame.Configuration;

namespace Win8ShooterGame.Core
{
    public class ParallaxingBackgroundFactory : IParallaxingBackgroundFactory, IRegistering
    {
        public IParallaxingBackground Build(ITexture2D texture, int speed, int screenWidth, int screenHeight)
        {
            return new ParallaxingBackground(texture, speed, screenWidth, screenHeight);
        }
    }
}