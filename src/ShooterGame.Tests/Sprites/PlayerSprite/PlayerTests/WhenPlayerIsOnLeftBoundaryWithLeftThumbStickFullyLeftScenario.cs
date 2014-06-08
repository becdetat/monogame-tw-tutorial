using Microsoft.Xna.Framework;
using ShooterGame.Tests.ObjectMothers;
using ShooterGame.Windows.Core;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace ShooterGame.Tests.Sprites.PlayerSprite.PlayerTests
{
    public class WhenPlayerIsOnLeftBoundaryWithLeftThumbStickFullyLeftScenario
        : GivenThePlayerScenarioBase
    {
        private ShooterGameInputState _state;

        public override void GivenThePlayer()
        {
            base.GivenThePlayer();
        }

        public void AndGivenThePlayerIsOnTheLeftBoundary()
        {
            Player.Position = new Vector2(10, 5);
        }

        public void AndGivenTheLeftThumbStickIsFullyLeft()
        {
            var gamePadState = ObjectMother.Input.GamePadStates.Default
                .WithLeftThumbstickFullyLeft()
                .Build();
            _state = ObjectMother.Core.ShooterGameInputStates.Default
                .WithCurrentGamePadState(gamePadState)
                .Build();
        }

        public void WhenUpdatingThePlayerState()
        {
            Player.Update(_state);
        }

        public void ThenThePositionIsNotChanged()
        {
            Player.Position.X.ShouldBe(10);
        }

        [Fact]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}