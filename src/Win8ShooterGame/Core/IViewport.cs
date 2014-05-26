using Microsoft.Xna.Framework;

namespace Win8ShooterGame.Core
{
    public interface IViewport
    {
        Rectangle TitleSafeArea { get; }
    }
}