using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tamagochi_Idle.Minijuegos.Pesca
{
    internal class Borde
    {
        private Texture2D sprite;
        private int fila;
        private int columna;
        private int anchura;
        private int altura;
        private Vector2 posicion;
        private double tiempoNecesario;
        private double tiempoTranscurrido;

        public Borde(Vector2 posicion)
        {
            anchura = 900;
            altura = 75;
            this.posicion = posicion;
            fila = 0;
            columna = 0;
            tiempoTranscurrido = 0;
            tiempoNecesario = 100;
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("bordeInferiorPesca");
        }

        public void Update(TimeSpan tiempoFrame)
        {
            tiempoTranscurrido += tiempoFrame.TotalMilliseconds;
            if (tiempoTranscurrido > tiempoNecesario)
            {
                tiempoTranscurrido = 0;
                fila++;
            }
            if (fila == 3)
            {
                fila = 0;
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            Rectangle frame = new Rectangle(anchura * columna, altura * fila, anchura, altura);
            _spriteBatch.Draw(sprite, posicion, frame, Color.White);
        }
    }
}
