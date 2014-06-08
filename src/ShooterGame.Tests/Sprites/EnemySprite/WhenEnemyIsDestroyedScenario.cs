using NSubstitute;
using ShooterGame.Windows.Core;
using ShooterGame.Windows.Sprites.EnemySprite;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace ShooterGame.Tests.Sprites.EnemySprite
{
    public class WhenEnemyIsDestroyedScenario
    {
        private Enemy _enemy;

        public void GivenAnEnemyThatIsAlive()
        {
            var animation = Substitute.For<IAnimation>();
            var spriteBatch = Substitute.For<ISpriteBatch>();

            _enemy = new Enemy(animation, spriteBatch);
        }

        public void WhenEnemyIsDestroyed()
        {
            _enemy.Destroy();
        }

        public void ThenTheEnemyHealthIsZero()
        {
            _enemy.Health.ShouldBe(0);
        }

        [Fact]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}