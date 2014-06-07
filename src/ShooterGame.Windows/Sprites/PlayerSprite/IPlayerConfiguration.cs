namespace ShooterGame.Windows.Sprites.PlayerSprite
{
    public interface IPlayerConfiguration
    {
        int LeftBoundary { get; }
        int TopBoundary { get; }
        int RightBoundary { get; }
        int BottomBoundary { get; }
        int Width { get; }
        int Height { get; }
    }
}