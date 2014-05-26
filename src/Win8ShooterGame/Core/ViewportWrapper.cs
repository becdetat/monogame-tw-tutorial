using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Win8ShooterGame.Configuration;

namespace Win8ShooterGame.Core
{
    internal class ViewportWrapper : IViewport, IRegistering
    {
        private readonly Viewport _viewport;

        public ViewportWrapper(GraphicsDevice graphicsDevice)
        {
            _viewport = graphicsDevice.Viewport;
        }

        public Rectangle TitleSafeArea { get { return _viewport.TitleSafeArea; } }
    }
}