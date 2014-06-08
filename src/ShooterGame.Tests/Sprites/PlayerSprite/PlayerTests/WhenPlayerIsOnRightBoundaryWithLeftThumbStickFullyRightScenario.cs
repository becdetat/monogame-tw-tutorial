using Microsoft.Xna.Framework;
using ShooterGame.Tests.ObjectMothers;
using ShooterGame.Windows.Core;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace ShooterGame.Tests.Sprites.PlayerSprite.PlayerTests
{
    public class WhenPlayerIsOnRightBoundaryWithLeftThumbStickFullyRightScenario
        : GivenThePlayerScenarioBase
    {
        private ShooterGameInputState _state;

        public override void GivenThePlayer()
        {
            base.GivenThePlayer();
        }

        public void AndGivenThePlayerIsOnTheRightBoundary()
        {
            Player.Position = new Vector2(90, 5);
        }

        public void AndGivenTheLeftThumbStickIsFullyRight()
        {
            var gamePadState = ObjectMother.Input.GamePadStates.Default
                .WithLeftThumbstickFullyRight()
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
            Player.Position.X.ShouldBe(90);
        }

        [Fact]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}