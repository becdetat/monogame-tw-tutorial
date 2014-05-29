using Win8ShooterGame.Configuration;
using Win8ShooterGame.Core;

namespace Win8ShooterGame.Sprites.EnemySprite
{
    public class EnemyFactory : IEnemyFactory, IRegistering
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly ISpriteBatch _spriteBatch;
        private readonly ITexture2D _texture;

        public EnemyFactory(IContentManager contentManager, IAnimationFactory animationFactory, ISpriteBatch spriteBatch)
        {
            _animationFactory = animationFactory;
            _spriteBatch = spriteBatch;
            _texture = contentManager.Load("Graphics/mineAnimation");
        }

        public IEnemy Build()
        {
            var animation = _animationFactory.Build(_texture, 47, 30, 8);
            return new Enemy(animation, _spriteBatch);
        }
    }
}