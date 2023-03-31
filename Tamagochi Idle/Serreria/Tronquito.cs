using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tamagochi_Idle.Serreria
{
    internal class Tronquito
    {
        public bool Cortado { get; set; }
        private Vector2 origenCorte;
        private Texture2D tronco;
        private Texture2D troncoPartido;
        public Rectangle Hitbox { get; set; }
        public float PosicionX { get; set; }
        public float PosicionY { get; set; }
        public Vector2 Posicion;
        public float velocidadTronquito;
        public Boolean SiendoCortado { get; set; }
        public int ContadorDesaparecer;

        public Tronquito(float posicionX, float posicionY, ContentManager content)
        {
            Cortado = false;
            tronco = content.Load<Texture2D>("tronco");
            troncoPartido = content.Load<Texture2D>("troncoPartido");
            PosicionX = posicionX;
            PosicionY = posicionY;
            Posicion = new Vector2(posicionX, posicionY);
            SiendoCortado = false;
            ContadorDesaparecer = 0;
        }

        public void Update(float velocidadTronquito)
        {
            this.velocidadTronquito = velocidadTronquito;
            Caer();
            Hitbox = new Rectangle((int)Posicion.X, (int)Posicion.Y, tronco.Width, tronco.Height);

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
            if (distancia >= tronco.Width - 40)
                Cortado = true;
        }

        public void Caer()
        {
            Posicion.Y += velocidadTronquito;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Cortado)
                spriteBatch.Draw(troncoPartido, Posicion, Color.White);
            else
                spriteBatch.Draw(tronco, Posicion, Color.White);
        }
    }
}
