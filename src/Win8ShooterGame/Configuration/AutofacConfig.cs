using System.Reflection;
using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Win8ShooterGame.Configuration
{
    public static class AutofacConfig
    {
        public static IContainer Register(Game game)
        {
            var builder = new ContainerBuilder();

            var spriteBatch = new SpriteBatch(game.GraphicsDevice);
            game.Content.RootDirectory = "Content";

            builder.RegisterInstance(game.Content).AsSelf();
            builder.RegisterInstance(spriteBatch).AsSelf();
            builder.RegisterInstance(game.GraphicsDevice).AsSelf();

            builder.RegisterAssemblyTypes(typeof (AutofacConfig).GetTypeInfo().Assembly)
                .Where(t => t.IsAssignableTo<IRegistering>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}