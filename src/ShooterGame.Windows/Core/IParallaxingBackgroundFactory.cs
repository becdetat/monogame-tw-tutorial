namespace ShooterGame.Windows.Core
{
    public interface IParallaxingBackgroundFactory
    {
        IParallaxingBackground Build(ITexture2D texture, int speed, int screenWidth, int screenHeight);
    }
}