using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Win8ShooterGame
{
    public class Player
    {
        private Vector2 _position;

        public Texture2D PlayerTexture { get; private set; }

        public void Initialize(ContentManager content)
        {
            PlayerTexture = content.Load<Texture2D>(@"Graphics\bertAndErnie");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, _position, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None,
                0.0f);
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }
    }
}