namespace Win8ShooterGame.Core
{
    public interface IParallaxingBackgroundFactory
    {
        IParallaxingBackground Build(ITexture2D texture, int speed, int screenWidth, int screenHeight);
    }
}