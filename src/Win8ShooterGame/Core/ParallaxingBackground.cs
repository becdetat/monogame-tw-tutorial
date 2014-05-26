using System;
using Microsoft.Xna.Framework;

namespace Win8ShooterGame.Core
{
    public class ParallaxingBackground : IParallaxingBackground
    {
        private readonly int[] _positions;
        private readonly int _screenHeight;
        private readonly int _speed;
        private readonly ITexture2D _texture;
        private int _screenWidth;

        public ParallaxingBackground(ITexture2D texture, int speed, int screenWidth, int screenHeight)
        {
            _texture = texture;
            _speed = speed;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;

            var numberOfTiles = (int) Math.Ceiling(_screenWidth/(float) _texture.Width) + 1;
            _positions = new int[numberOfTiles];

            for (var i = 0; i < _positions.Length; i ++)
            {
                _positions[i] = i*_texture.Width;
            }
        }

        public void Update(GameTime gameTime)
        {
            for (var i = 0; i < _positions.Length; i ++)
            {
                _positions[i] += _speed;
            }

            for (var i = 0; i < _positions.Length; i ++)
            {
                if (_speed <= 0)
                {
                    if (_positions[i] <= -_texture.Width)
                    {
                        var previous = i - 1;
                        if (previous < 0) previous = _positions.Length - 1;
                        _positions[i] = _positions[previous] + _texture.Width;
                    }
                }
                else if (_positions[i] >= _texture.Width*(_positions.Length - 1))
                {
                    var next = i + 1;
                    if (next == _positions.Length) next = 0;
                    _positions[i] = _positions[next] - _texture.Width;
                }
            }
        }

        public void Draw(ISpriteBatch batch)
        {
            foreach (var position in _positions)
            {
                batch.Draw(_texture, new Rectangle((int) position, 0, _texture.Width, _screenHeight), Color.White);
            }
        }
    }
}