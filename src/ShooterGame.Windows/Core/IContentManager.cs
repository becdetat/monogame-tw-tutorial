namespace ShooterGame.Windows.Core
{
    public interface IContentManager
    {
        ITexture2D Load(string assetName);
    }
}