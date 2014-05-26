using Win8ShooterGame.Configuration;
using Win8ShooterGame.Core;

namespace Win8ShooterGame.Actors.EnemyActor
{
    public class EnemyFactory : IEnemyFactory, IRegistering
    {
        private readonly IContentManager _contentManager;
        private readonly IAnimationFactory _animationFactory;

        public EnemyFactory(IContentManager contentManager, IAnimationFactory animationFactory)
        {
            _contentManager = contentManager;
            _animationFactory = animationFactory;
        }

        public IEnemy Build()
        {
            var texture = _contentManager.Load("Graphics/mineAnimation");
            var animation = _animationFactory.Build(texture, 47, 30, 8);
            return new Enemy(animation);
        }
    }
}