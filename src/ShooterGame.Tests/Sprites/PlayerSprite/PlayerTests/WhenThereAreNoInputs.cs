using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using NSubstitute;
using ShooterGame.Tests.ObjectMothers;
using ShooterGame.Windows.Core;
using ShooterGame.Windows.Sprites.PlayerSprite;
using Shouldly;
using Xunit;

namespace ShooterGame.Tests.Sprites.PlayerSprite.PlayerTests
{
    public class WhenThereAreNoInputs
    {
        [Fact]
        public void ThePositionStaysTheSame()
        {
            var player = ObjectMother.Sprites.PlayerSprite.Players.Default.Build();

            var initialPosition = new Vector2(4, 5);
            player.Position = initialPosition;

            var state = ObjectMother.Core.ShooterGameInputStates.Zeroed;
            player.Update(state);

            player.Position.ShouldBe(initialPosition);
        }
    }
}
