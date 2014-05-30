using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using NSubstitute;
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
            var contentManager = Substitute.For<IContentManager>();
            var viewport = Substitute.For<IViewport>();
            var animationFactory = Substitute.For<IAnimationFactory>();
            var spriteBatch = Substitute.For<ISpriteBatch>();

            var player = new Player(contentManager, viewport, animationFactory, spriteBatch);

            var initialPosition = new Vector2(4, 5);
            player.Position = initialPosition;

            var state = GetInputState();
            player.Update(state);

            player.Position.ShouldBe(initialPosition);
        }

        private static ShooterGameInputState GetInputState()
        {
            var currentGamePadState = new GamePadState(Vector2.Zero, Vector2.Zero, 0, 0);
            var previousGamePadState = new GamePadState(Vector2.Zero, Vector2.Zero, 0, 0);
            var currentKeyboardState = new KeyboardState();
            var previousKeyboardState = new KeyboardState();
            var currentMouseState = new MouseState();
            var previousMouseState = new MouseState();
            var gameTime = new GameTime();
            var window = new MetroGameWindow();
            var currentTouchPanelState = TouchPanel.GetState(window);
            var previousTouchPanelState = TouchPanel.GetState(window);
            var state = new ShooterGameInputState(currentGamePadState, previousGamePadState, currentKeyboardState,
                previousKeyboardState, currentMouseState, previousMouseState, currentTouchPanelState, previousTouchPanelState, gameTime);
            return state;
        }
    }
}
