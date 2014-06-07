using ShooterGame.Windows.Configuration;

namespace ShooterGame.Windows.Sprites.PlayerSprite
{
    public class PlayerConfiguration : IPlayerConfiguration, IRegistering
    {
        public int LeftBoundary
        {
            get { return 20; }
        }

        public int TopBoundary
        {
            get { return 20; }
        }

        public int RightBoundary
        {
            get { return 60; }
        }

        public int BottomBoundary
        {
            get { return 20; }
        }

        public int Width
        {
            get { return 115; }
        }

        public int Height
        {
            get { return 69; }
        }
    }
}