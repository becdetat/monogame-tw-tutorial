using Microsoft.Xna.Framework;
using ShooterGame.Tests.ObjectMothers;
using ShooterGame.Windows.Core;
using ShooterGame.Windows.Sprites.PlayerSprite;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace ShooterGame.Tests.Sprites.PlayerSprite.PlayerTests
{
    public class WhenPlayerIsOnTopBoundaryWithLeftThumbStickFullyUpScenario
        : GivenThePlayerScenarioBase
    {
        private ShooterGameInputState _state;

        public override void GivenThePlayer()
        {
            base.GivenThePlayer();
        }

        public void AndGivenThePlayerIsAtTheTopOfTheScreen()
        {
            Player.Position = new Vector2(20, 10);
        }

        public void AndGivenTheThumbstickIsFullyUp()
        {
            var gamePadState = ObjectMother.Input.GamePadStates.Default
                .WithLeftThumbstickFullyUp()
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
            Player.Position.Y.ShouldBe(10);
        }

        [Fact]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}