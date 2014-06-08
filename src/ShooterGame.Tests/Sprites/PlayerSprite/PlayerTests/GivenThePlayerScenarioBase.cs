using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShooterGame.Tests.ObjectMothers;
using ShooterGame.Windows.Sprites.PlayerSprite;

namespace ShooterGame.Tests.Sprites.PlayerSprite.PlayerTests
{
    public abstract class GivenThePlayerScenarioBase
    {
        protected Player Player;

        public virtual void GivenThePlayer()
        {
            var configuration = ObjectMother.Sprites.PlayerSprite.PlayerConfigurations.Default
                .WithTopBoundary(10)
                .WithRightBoundary(10)
                .WithBottomBoundary(10)
                .WithLeftBoundary(10)
                .Build();
            var viewport = ObjectMother.Core.Viewports.Default
                .WithHeight(100)
                .WithWidth(100)
                .Build();
            Player = ObjectMother.Sprites.PlayerSprite.Players.Default
                .WithPlayerConfiguration(configuration)
                .WithViewport(viewport)
                .Build();
        }
    }
}
