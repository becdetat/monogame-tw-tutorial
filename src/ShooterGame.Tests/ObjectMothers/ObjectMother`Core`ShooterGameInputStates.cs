using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using ShooterGame.Windows.Core;

namespace ShooterGame.Tests.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static partial class Core
        {
            public static partial class ShooterGameInputStates
            {
                public static ShooterGameInputState Zeroed { get { return Default.Build(); } }

                public static ShooterGameInputStateBuilder Default
                {
                    get { return new ShooterGameInputStateBuilder(); }
                }

                public class ShooterGameInputStateBuilder
                    : BuilderFor<ShooterGameInputState>
                {
                    public override ShooterGameInputState Build()
                    {
                        var currentKeyboardState = new KeyboardState();
                        var previousKeyboardState = new KeyboardState();
                        var currentMouseState = new MouseState();
                        var previousMouseState = new MouseState();
                        var gameTime = new GameTime();
                        var window = new MetroGameWindow();
                        var currentTouchPanelState = TouchPanel.GetState(window);
                        var previousTouchPanelState = TouchPanel.GetState(window);

                        return new ShooterGameInputState(
                            Get(x => x.CurrentGamePadState, Input.GamePadStates.Default.Build()), 
                            Input.GamePadStates.Default.Build(),
                            currentKeyboardState,
                            previousKeyboardState, currentMouseState, previousMouseState, currentTouchPanelState,
                            previousTouchPanelState, gameTime);
                    }

                    public ShooterGameInputStateBuilder WithCurrentGamePadState(GamePadState gamePadState)
                    {
                        Set(x => x.CurrentGamePadState, gamePadState);
                        return this;
                    }
                }
            }
        }
    }
}