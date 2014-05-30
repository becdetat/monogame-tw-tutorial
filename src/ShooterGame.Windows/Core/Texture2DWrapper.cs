using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Windows.Configuration;

namespace ShooterGame.Windows.Core
{
    internal class Texture2DWrapper
        : ITexture2D, IRegistering
    {
        private readonly Texture2D _texture;

        public Texture2DWrapper(Texture2D texture)
        {
            _texture = texture;
        }

        public int Height { get { return _texture.Height; } }
        public int Width { get { return _texture.Width;} }
        public Texture2D UnderlyingTexture { get { return _texture; } }
    }
}