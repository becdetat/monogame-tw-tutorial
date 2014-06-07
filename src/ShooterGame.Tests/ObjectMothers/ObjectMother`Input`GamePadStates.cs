using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ShooterGame.Tests.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static partial class Input
        {
            public static partial class GamePadStates
            {
                public static GamePadStateBuilder Default
                {
                    get { return new GamePadStateBuilder(); }
                }

                public class GamePadStateBuilder
                    : BuilderFor<GamePadState>
                {
                    private Vector2 _leftThumbStick = Vector2.Zero;

                    public override GamePadState Build()
                    {
                        return new GamePadState(_leftThumbStick, Vector2.Zero, 0, 0);
                    }

                    public GamePadStateBuilder WithLeftThumbstick(Vector2 position)
                    {
                        _leftThumbStick = position;
                        return this;
                    }

                    public GamePadStateBuilder WithLeftThumbstickFullyLeft()
                    {
                        _leftThumbStick = new Vector2(-1, 0);
                        return this;
                    }

                    public GamePadStateBuilder WithLeftThumbstickFullyRight()
                    {
                        _leftThumbStick = new Vector2(1, 0);
                        return this;
                    }

                    public GamePadStateBuilder WithLeftThumbstickFullyUp()
                    {
                        _leftThumbStick = new Vector2(0, 1);
                        return this;
                    }

                    public GamePadStateBuilder WithLeftThumbstickFullyDown()
                    {
                        _leftThumbStick = new Vector2(0, -1);
                        return this;
                    }
                }
            }
        }
    }
}