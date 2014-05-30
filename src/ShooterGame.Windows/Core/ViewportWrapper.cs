using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Windows.Configuration;

namespace ShooterGame.Windows.Core
{
    internal class ViewportWrapper : IViewport, IRegistering
    {
        private readonly Viewport _viewport;

        public ViewportWrapper(GraphicsDevice graphicsDevice)
        {
            _viewport = graphicsDevice.Viewport;
        }

        public Viewport Viewport
        {
            get { return _viewport; }
        }
    }
}