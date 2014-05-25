using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Win8ShooterGame
{
    public class Enemy : ISprite
    {
        private int _health = 10;
        private readonly Animation _animation = new Animation();
        public bool IsActive { get; private set; }
        private Vector2 _position;
        private int _damage = 10;
        private float _speed = 6.0f;
        private int _scoreValue = 100;
        public int Width { get { return _animation.FrameWidth; } }

        public Enemy()
        {
            IsActive = true;
        }

        public void Initialize(Func<string, Texture2D> getTexture, Viewport viewport)
        {
            var texture = getTexture("Graphics/mineAnimation");
            _animation.Initialize(texture, 47, 30,  8);
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        public void Update(ShooterGameInputState input)
        {
            _position.X -= _speed;

            if (_position.X < -Width || _health <= 0)
            {
                IsActive = false;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            _animation.Update(gameTime, _position);
            _animation.Draw(batch);
        }
    }

    public interface ISprite
    {
        void Initialize(Func<string, Texture2D> getTexture, Viewport viewport);
        void Update(ShooterGameInputState input);
        void Draw(GameTime gameTime, SpriteBatch batch);
    }
}
