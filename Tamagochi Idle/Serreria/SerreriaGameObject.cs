using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;


namespace Tamagochi_Idle.Serreria
{
    internal class SerreriaGameObject
    {
        public bool Cortado { get; set; }
        protected Vector2 origenCorte;
        public Texture2D texturaCompacto { get; set; }
        public Texture2D texturaCortado { get; set; }
        protected SoundEffect sonidoCorte;

        public Rectangle Hitbox { get; set; }
        public float PosicionX { get; set; }
        public float PosicionY { get; set; }
        public Vector2 Posicion;
        public float velocidadMovimiento;
        public bool SiendoCortado { get; set; }

        public int ContadorDesaparecer;

        public SerreriaGameObject(float posicionX, float posicionY)
        {
            Cortado = false;
            PosicionX = posicionX;
            PosicionY = posicionY;
            Posicion = new Vector2(posicionX, posicionY);
            SiendoCortado = false;
            ContadorDesaparecer = 0;
        }

        public void Update(float velocidadMovimiento)
        {
            this.velocidadMovimiento = velocidadMovimiento;
            Caer();
            Hitbox = new Rectangle((int)Posicion.X, (int)Posicion.Y, texturaCompacto.Width, texturaCompacto.Height);

            if (Cortado)
                ContadorDesaparecer++;
        }

        public void OriginarCorte(Vector2 origenCorte)
        {
            this.origenCorte = origenCorte;
        }

        public void FinalizarCorte(Vector2 finalCorte)
        {
            float distancia = Vector2.Distance(finalCorte, origenCorte);
            if (distancia >= texturaCompacto.Width - 60)
            {
                Cortado = true;
                sonidoCorte.Play();
            }
        }

        public void Caer()
        {
            Posicion.Y += velocidadMovimiento;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Cortado)
                spriteBatch.Draw(texturaCortado, Posicion, Color.White);
            else
                spriteBatch.Draw(texturaCompacto, Posicion, Color.White);
        }

        public void Unload()
        {
            texturaCompacto.Dispose();
            texturaCortado.Dispose();
            sonidoCorte.Dispose();
        }
    }
}

