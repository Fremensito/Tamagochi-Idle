using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Tamagochi_Idle.Minijuegos.Serreria
{
    internal class Particula
    {
        private Texture2D textura;
        private int direccion;
        private Vector2 posicion;
        public byte ContadorDesaparecer = 0;
        public Particula(Dictionary<string, Texture2D> texturas)
        {
            switch (new Random().Next(1, 5))
            {
                case 1: textura = texturas["particula 1"]; break;
                case 2: textura = texturas["particula 2"]; break;
                case 3: textura = texturas["particula 3"]; break;
                case 4: textura = texturas["particula 4"]; break;
            }

            posicion = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            direccion = new Random().Next(1, 9);
        }
        public void Moverse()
        {
            ContadorDesaparecer++;
            switch (direccion)
            {
                case 1: posicion.X -= 2; posicion.Y -= 2; break;
                case 2: posicion.Y -= 2; break;
                case 3: posicion.X += 2; posicion.Y -= 2; break;
                case 4: posicion.X += 2; break;
                case 5: posicion.X += 2; posicion.Y += 2; break;
                case 6: posicion.Y += 2; break;
                case 7: posicion.X -= 2; posicion.Y += 2; break;
                case 8: posicion.X -= 2; break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Sprite, Posicion, null, Color.White, (float)Rotacion, new Vector2(0f,0f), 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(textura, posicion, Color.White);
        }
    }
}
