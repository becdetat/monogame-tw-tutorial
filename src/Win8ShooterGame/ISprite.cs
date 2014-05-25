using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Win8ShooterGame
{
    public interface ISprite
    {
        void Initialize(Func<string, Texture2D> getTexture, Viewport viewport);
        void Update(ShooterGameInputState input);
        void Draw(GameTime gameTime, SpriteBatch batch);
        Rectangle GetBounds();
    }
}