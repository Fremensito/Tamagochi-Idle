using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;


namespace Tamagochi_Idle.Minijuegos.Serreria
{
    internal class SerreriaGameObject
    {
        public bool Cortado { get; set; }
        protected Vector2 origenCorte;
        protected Texture2D texturaCompacto;
        protected Texture2D texturaCortado;
        protected SoundEffect sonidoCorte;

        public Rectangle Hitbox { get; set; }
        public float PosicionX { get; set; }
        public float PosicionY { get; set; }
        public Vector2 Posicion;
        private float velocidadMovimiento;
        public bool SiendoCortado { get; set; }
        public int ContadorDesaparecer { get; set;}
        public bool DarPunto { get; set; }
        public SerreriaGameObject(float posicionX, float posicionY)
        {
            Cortado = false;
            PosicionX = posicionX;
            PosicionY = posicionY;
            Posicion = new Vector2(posicionX, posicionY);
            SiendoCortado = false;
            ContadorDesaparecer = 0;
            DarPunto = false;
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

        public virtual void FinalizarCorte(Vector2 finalCorte)
        {
            float distancia = Vector2.Distance(finalCorte, origenCorte);
            if (distancia >= texturaCompacto.Width - 30)
            {
                Cortado = true;
                DarPunto = true;
                sonidoCorte.Play();
            }
        }

        public void Caer()
        {
            Posicion.Y += velocidadMovimiento;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Cortado)
                spriteBatch.Draw(texturaCortado, Posicion, Color.White);
            else
                spriteBatch.Draw(texturaCompacto, Posicion, Color.White);
        }
    }
}

