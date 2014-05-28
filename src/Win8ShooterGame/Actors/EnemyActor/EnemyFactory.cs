using Win8ShooterGame.Configuration;
using Win8ShooterGame.Core;

namespace Win8ShooterGame.Actors.EnemyActor
{
    public class EnemyFactory : IEnemyFactory, IRegistering
    {
        private readonly IContentManager _contentManager;
        private readonly IAnimationFactory _animationFactory;
        private ITexture2D _texture;

        public EnemyFactory(IContentManager contentManager, IAnimationFactory animationFactory)
        {
            _contentManager = contentManager;
            _animationFactory = animationFactory;
            _texture = _contentManager.Load("Graphics/mineAnimation");
        }

        public IEnemy Build()
        {
            var animation = _animationFactory.Build(_texture, 47, 30, 8);
            return new Enemy(animation);
        }
    }
}