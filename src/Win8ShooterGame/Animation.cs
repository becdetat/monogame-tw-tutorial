using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.WebUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Win8ShooterGame
{
    public class Animation
    {
        private Texture2D _spriteStrip;
        private float _scale;
        private int _elapsedTime = 0;
        private int _frameTime;
        private int _frameCount;
        private int _currentFrame = 0;
        private Color _color;
        private Rectangle _sourceRect;
        private Rectangle _destRect;
        public int FrameWidth { get; private set; }
        public int FrameHeight { get { return _spriteStrip.Height; } }
        private bool _active = true;
        private bool _looping = true;

        private int ScaledWidth { get { return (int)(FrameWidth * _scale); } }
        private int ScaledHeight { get { return (int)(FrameHeight * _scale); } }

        public void Initialize(Texture2D spriteStrip, int frameWidth, int frameTime, int frameCount, bool looping = true, float scale = 1.0f, Color color = default(Color))
        {
            _spriteStrip = spriteStrip;
            _scale = scale;
            FrameWidth = frameWidth;
            _looping = looping;
            _color = color == default(Color) ? Color.White : color;
            _frameTime = frameTime;
            _frameCount = frameCount;
        }

        public void Update(GameTime gameTime, Vector2 position)
        {
            if (!_active)
            {
                return;
            }

            _elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_elapsedTime > _frameTime)
            {
                _elapsedTime = 0;
                _currentFrame ++;
                if (_currentFrame == _frameCount)
                {
                    _currentFrame = 0;
                    _active = _active && _looping;
                }
            }

            _sourceRect = new Rectangle(_currentFrame*FrameWidth, 0, FrameWidth, FrameHeight);
            _destRect = new Rectangle(
                (int)position.X - ScaledWidth / 2,
                (int)position.Y - ScaledHeight / 2,
                ScaledWidth,
                ScaledHeight);
        }

        public void Draw(SpriteBatch batch)
        {
            if (!_active)
            {
                return;
            }

            batch.Draw(_spriteStrip, _destRect, _sourceRect, _color);
        }
    }
}
