using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Win8ShooterGame
{
    public class ParallaxingBackground
    {
        private Texture2D _texture;
        private int[] _positions;
        private int _speed;
        private int _screenWidth;
        private int _screenHeight;

        public void Initialize(Texture2D texture, int speed, int screenWidth, int screenHeight)
        {
            _texture = texture;
            _speed = speed;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;

            var numberOfTiles = (int) Math.Ceiling(_screenWidth/(float) _texture.Width) + 1;
            _positions = new int[numberOfTiles];

            for (var i = 0; i < _positions.Length; i ++)
            {
                _positions[i] = i * _texture.Width;
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

        public void Draw(SpriteBatch batch)
        {
            foreach (var position in _positions)
            {
                batch.Draw(_texture, new Rectangle((int)position, 0, _texture.Width, _screenHeight), Color.White);
            }
        }
    }
}
