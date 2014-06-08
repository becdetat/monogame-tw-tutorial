using Microsoft.Xna.Framework;
using ShooterGame.Tests.ObjectMothers;
using ShooterGame.Windows.Core;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace ShooterGame.Tests.Sprites.PlayerSprite.PlayerTests
{
    public class WhenPlayerIsOnBottomBoundaryWithLeftThumbStickFullyDownScenario
        : GivenThePlayerScenarioBase
    {
        private ShooterGameInputState _state;

        public override void GivenThePlayer()
        {
            base.GivenThePlayer();
        }

        public void AndGivenThePlayerIsOnTheBottomBoundary()
        {
            Player.Position = new Vector2(20, 90);
        }

        public void AndGivenTheLeftThumbStickIsFullyDown()
        {
            var gamePadState = ObjectMother.Input.GamePadStates.Default
                .WithLeftThumbstickFullyDown()
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
            Player.Position.Y.ShouldBe(90);
        }

        [Fact]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}