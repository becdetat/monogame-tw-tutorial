using Microsoft.Xna.Framework;

namespace Win8ShooterGame.Core
{
    public class Animation : IAnimation, ISprite
    {
        private readonly Color _color;
        private readonly int _frameCount;
        private readonly int _frameTime;
        private readonly bool _looping = true;
        private readonly float _scale;
        private readonly ITexture2D _spriteStrip;
        private bool _active = true;
        private int _currentFrame = 0;
        private int _elapsedTime = 0;
        private Rectangle _sourceRect;

        public Animation(ITexture2D spriteStrip, int frameWidth, int frameTime, int frameCount, bool looping = true,
            float scale = 1.0f, Color color = default(Color))
        {
            _spriteStrip = spriteStrip;
            _scale = scale;
            FrameWidth = frameWidth;
            _looping = looping;
            _color = color == default(Color) ? Color.White : color;
            _frameTime = frameTime;
            _frameCount = frameCount;
        }

        private int ScaledWidth
        {
            get { return (int) (FrameWidth*_scale); }
        }

        private int ScaledHeight
        {
            get { return (int) (FrameHeight*_scale); }
        }

        public int FrameWidth { get; private set; }

        public int FrameHeight
        {
            get { return _spriteStrip.Height; }
        }

        public void Update(GameTime gameTime)
        {
            if (!_active)
            {
                return;
            }

            _elapsedTime += (int) gameTime.ElapsedGameTime.TotalMilliseconds;
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
        }

        public void Draw(ISpriteBatch batch, Vector2 position)
        {
            if (!_active)
            {
                return;
            }

            var destRect = new Rectangle(
                (int) position.X - ScaledWidth/2,
                (int) position.Y - ScaledHeight/2,
                ScaledWidth,
                ScaledHeight);

            batch.Draw(_spriteStrip, destRect, _sourceRect, _color);
        }
    }
}