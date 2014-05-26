using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Win8ShooterGame.Configuration;

namespace Win8ShooterGame.Core
{
    internal class ContentManagerWrapper
        : IContentManager, IRegistering
    {
        private readonly ContentManager _contentManager;

        public ContentManagerWrapper(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public ITexture2D Load(string assetName)
        {
            var texture = _contentManager.Load<Texture2D>(assetName);
            return new Texture2DWrapper(texture);
        }
    }
}