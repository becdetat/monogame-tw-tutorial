using Microsoft.Xna.Framework;
using ShooterGame.Tests.ObjectMothers;
using Shouldly;
using Xunit;

namespace ShooterGame.Tests.Sprites.PlayerSprite.PlayerTests
{
    public class WhenPlayerIsOnRightBoundaryWithLeftThumbStickFullyRight
    {
        [Fact]
        public void ThenThePositionIsNotChanged()
        {
            var configuration = ObjectMother.Sprites.PlayerSprite.PlayerConfigurations.Default
                .WithRightBoundary(10)
                .Build();
            var viewport = ObjectMother.Core.Viewports.Default
                .WithHeight(100)
                .WithWidth(100)
                .Build();
            var player = ObjectMother.Sprites.PlayerSprite.Players.Default
                .WithPlayerConfiguration(configuration)
                .WithViewport(viewport)
                .Build();
            var initialPosition = new Vector2(90, 5);
            player.Position = initialPosition;

            var gamePadState = ObjectMother.Input.GamePadStates.Default
                .WithLeftThumbstickFullyRight()
                .Build();
            var state = ObjectMother.Core.ShooterGameInputStates.Default
                .WithCurrentGamePadState(gamePadState)
                .Build();

            player.Update(state);

            player.Position.X.ShouldBe(90);
        }
    }
}