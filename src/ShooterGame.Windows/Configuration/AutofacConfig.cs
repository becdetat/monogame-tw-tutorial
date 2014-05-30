using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShooterGame.Windows.Configuration
{
    public static class AutofacConfig
    {
        public static IContainer Register(Game game)
        {
            var builder = new ContainerBuilder();

            game.Content.RootDirectory = "Content";

            builder.RegisterInstance(new SpriteBatch(game.GraphicsDevice)).AsSelf();
            builder.RegisterInstance(game.Content).AsSelf();
            builder.RegisterInstance(game.GraphicsDevice).AsSelf();

            builder.RegisterAssemblyTypes(typeof (AutofacConfig).Assembly)
                .Where(t => t.IsAssignableTo<IRegistering>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}