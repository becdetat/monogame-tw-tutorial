using Microsoft.Xna.Framework;
using ShooterGame.Tests.ObjectMothers;
using Shouldly;
using Xunit;

namespace ShooterGame.Tests.Sprites.PlayerSprite.PlayerTests
{
    public class WhenPlayerIsOnTopBoundaryWithLeftThumbStickFullyUp
    {
        [Fact]
        public void ThenThePositionIsNotChanged()
        {
            var configuration = ObjectMother.Sprites.PlayerSprite.PlayerConfigurations.Default
                .WithTopBoundary(10)
                .Build();
            var viewport = ObjectMother.Core.Viewports.Default
                .WithHeight(100)
                .WithWidth(100)
                .Build();
            var player = ObjectMother.Sprites.PlayerSprite.Players.Default
                .WithPlayerConfiguration(configuration)
                .WithViewport(viewport)
                .Build();
            var initialPosition = new Vector2(20, 10);
            player.Position = initialPosition;

            var gamePadState = ObjectMother.Input.GamePadStates.Default
                .WithLeftThumbstickFullyUp()
                .Build();
            var state = ObjectMother.Core.ShooterGameInputStates.Default
                .WithCurrentGamePadState(gamePadState)
                .Build();

            player.Update(state);

            player.Position.Y.ShouldBe(10);
        }
    }
}