using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tamagochi_Idle.Pesca
{
    internal abstract class Pez
    {
        public Texture2D Sprite { get; set; }
        public float PosicionX { get; set; }
        public float PosicionY { get; set; }

        protected float velocidad;
        public abstract void LoadContent(ContentManager content);

        public void Update(TimeSpan gameTime)
        {
            Moverse(gameTime);
        }
        protected void Moverse(TimeSpan gameTime)
        {
            PosicionX += velocidad * (float)gameTime.TotalSeconds;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Sprite, new Vector2(PosicionX, PosicionY), Color.White);
        }
    }
}
