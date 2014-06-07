using Microsoft.Xna.Framework.Graphics;
using NSubstitute;
using ShooterGame.Windows.Core;
using ShooterGame.Windows.Sprites.PlayerSprite;

namespace ShooterGame.Tests.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static partial class Sprites
        {
            public static partial class PlayerSprite
            {
                public static partial class Players
                {
                    public static PlayerBuilder Default { get { return new PlayerBuilder();} }

                    public class PlayerBuilder
                        : BuilderFor<Player>
                    {
                        private IPlayerConfiguration _playerConfiguration;
                        private IViewport _viewport;

                        public PlayerBuilder()
                        {
                            _viewport = Substitute.For<IViewport>();
                            _viewport.Viewport.Returns(new Viewport(0, 0, 640, 480));
                        }

                        public override Player Build()
                        {
                            
                            return new Player(
                                Substitute.For<IContentManager>(),
                                _viewport,
                                Substitute.For<IAnimationFactory>(),
                                Substitute.For<ISpriteBatch>(),
                                _playerConfiguration ?? Substitute.For<IPlayerConfiguration>());
                        }

                        public PlayerBuilder WithPlayerConfiguration(IPlayerConfiguration playerConfiguration)
                        {
                            _playerConfiguration = playerConfiguration;
                            return this;
                        }

                        public PlayerBuilder WithViewport(IViewport viewport)
                        {
                            _viewport = viewport;
                            return this;
                        }
                    }
                }
            }
        }
    }
}