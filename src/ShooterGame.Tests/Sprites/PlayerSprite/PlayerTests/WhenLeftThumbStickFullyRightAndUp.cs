using System;
using Microsoft.Xna.Framework;
using ShooterGame.Tests.ObjectMothers;
using Shouldly;
using Xunit;

namespace ShooterGame.Tests.Sprites.PlayerSprite.PlayerTests
{
    public class WhenLeftThumbStickFullyRightAndUp
    {
        [Fact]
        public void ThenThePositionMovesUpAndRightAtFullSpeed()
        {
            var player = ObjectMother.Sprites.PlayerSprite.Players.Default.Build();

            var initialPosition = new Vector2(4, 5);
            player.Position = initialPosition;

            var gamePadState = ObjectMother.Input.GamePadStates.Default
                .WithLeftThumbstick(new Vector2(1, 1))
                .Build();
            var state = ObjectMother.Core.ShooterGameInputStates.Default
                .WithCurrentGamePadState(gamePadState)
                .Build();

            player.Update(state);

            var normalisedVelocity = Math.Sqrt(2)/2.0d;
            var changeInPosition = new Vector2(
                player.Speed*(float) normalisedVelocity,
                -player.Speed*(float) normalisedVelocity);

            player.Position.ShouldBe(initialPosition + changeInPosition);
        }
    }
}