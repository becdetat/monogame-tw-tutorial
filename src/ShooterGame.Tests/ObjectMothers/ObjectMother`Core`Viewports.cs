using Microsoft.Xna.Framework.Graphics;
using NSubstitute;
using ShooterGame.Windows.Core;

namespace ShooterGame.Tests.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static partial class Core
        {
            public static partial class Viewports
            {
                public static ViewportBuilder Default
                {
                    get { return new ViewportBuilder(); }
                }

                public class ViewportBuilder
                    : BuilderFor<IViewport>
                {
                    private int _height = 480;
                    private int _width = 640;

                    public override IViewport Build()
                    {
                        var viewport = Substitute.For<IViewport>();
                        viewport.Viewport.Returns(new Viewport(0, 0, _width, _height));
                        return viewport;
                    }

                    public ViewportBuilder WithWidth(int width)
                    {
                        _width = width;
                        return this;
                    }

                    public ViewportBuilder WithHeight(int height)
                    {
                        _height = height;
                        return this;
                    }
                }
            }
        }
    }
}