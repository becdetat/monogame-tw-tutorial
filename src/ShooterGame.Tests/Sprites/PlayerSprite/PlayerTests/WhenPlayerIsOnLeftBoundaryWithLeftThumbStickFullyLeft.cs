using Microsoft.Xna.Framework;
using ShooterGame.Tests.ObjectMothers;
using Shouldly;
using Xunit;

namespace ShooterGame.Tests.Sprites.PlayerSprite.PlayerTests
{
    public class WhenPlayerIsOnLeftBoundaryWithLeftThumbStickFullyLeft
    {
        [Fact]
        public void ThenThePositionIsNotChanged()
        {
            var configuration = ObjectMother.Sprites.PlayerSprite.PlayerConfigurations.Default
                .WithLeftBoundary(10)
                .Build();
            var player = ObjectMother.Sprites.PlayerSprite.Players.Default
                .WithPlayerConfiguration(configuration)
                .Build();
            var initialPosition = new Vector2(10, 5);
            player.Position = initialPosition;

            var gamePadState = ObjectMother.Input.GamePadStates.Default
                .WithLeftThumbstickFullyLeft()
                .Build();
            var state = ObjectMother.Core.ShooterGameInputStates.Default
                .WithCurrentGamePadState(gamePadState)
                .Build();

            player.Update(state);

            player.Position.X.ShouldBe(10);
        }
    }
}