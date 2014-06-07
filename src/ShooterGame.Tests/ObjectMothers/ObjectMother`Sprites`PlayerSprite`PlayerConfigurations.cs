using NSubstitute;
using ShooterGame.Windows.Sprites.PlayerSprite;

namespace ShooterGame.Tests.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static partial class Sprites
        {
            public static partial class PlayerSprite
            {
                public static partial class PlayerConfigurations
                {
                    public static PlayerConfigurationBuilder Default
                    {
                        get { return new PlayerConfigurationBuilder(); }
                    }

                    public class PlayerConfigurationBuilder
                        : BuilderFor<IPlayerConfiguration>
                    {
                        private readonly IPlayerConfiguration _playerConfiguration =
                            Substitute.For<IPlayerConfiguration>();

                        public PlayerConfigurationBuilder()
                        {
                            _playerConfiguration.Width.Returns(10);
                            _playerConfiguration.Height.Returns(10);
                        }

                        public override IPlayerConfiguration Build()
                        {
                            return _playerConfiguration;
                        }

                        public PlayerConfigurationBuilder WithLeftBoundary(int boundary)
                        {
                            _playerConfiguration.LeftBoundary.Returns(boundary);
                            return this;
                        }

                        public PlayerConfigurationBuilder WithRightBoundary(int boundary)
                        {
                            _playerConfiguration.RightBoundary.Returns(boundary);
                            return this;
                        }

                        public PlayerConfigurationBuilder WithTopBoundary(int boundary)
                        {
                            _playerConfiguration.TopBoundary.Returns(boundary);
                            return this;
                        }

                        public PlayerConfigurationBuilder WithBottomBoundary(int boundary)
                        {
                            _playerConfiguration.BottomBoundary.Returns(boundary);
                            return this;
                        }
                    }
                }
            }
        }
    }
}