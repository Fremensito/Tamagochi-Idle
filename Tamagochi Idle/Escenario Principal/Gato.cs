using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tamagochi_Idle.Escenario_Principal
{
    internal class Gato
    {
        //Posicion del gato
        private float posicionX = 306f;
        private float posicionY = 503f;

        //Bloque de variables necesario para caminar
        private int filaCaminar;
        private int columnaCaminar;
        private int anchuraCaminar;
        private int alturaCaminar;
        private double contadorNecesarioCaminar;
        private double contadorCaminar;
        private bool caminando;
        private bool sentidoDerecha;
        private float limiteDerecha = 750f;
        private float limiteIzquierda = 0f;

        //Randomización de la acción del caminar
        private int probabilidadIzquierda = 3;
        private int probabilidadDerecha = 6;
        private int probabilidadCaminar = 4;

        public Energia Energia{get; set;}

        public Hambre Hambre{get; set;}
        public int Oro  {get; set;}
        public bool Vivo {get; set;}
        public bool Durmiendo{get; set;}
        Random rd;
        public Gato()
        {
            posicionX = 306f;
            posicionY = 503f;

            probabilidadIzquierda = 3;
            probabilidadDerecha = 6;
            probabilidadCaminar = 4;
            rd = new Random();

            filaCaminar = 0;
            columnaCaminar = 0;
            anchuraCaminar = 150;
            alturaCaminar = 150;
            caminando = false;
            sentidoDerecha = true;
            contadorNecesarioCaminar = 10;
            contadorCaminar = 0;

            Energia = new Energia();
            Hambre = new Hambre();
        }
        public void Update()
        {
            if(!Durmiendo)
            {
                contadorCaminar++;
                if(contadorCaminar > contadorNecesarioCaminar)
                {
                    if (!caminando)
                        EligirSentido();
                    if (caminando)
                        Caminar();
                    RestringirMovimiento();
                    contadorCaminar = 0;
                }
                Energia.Desgastar();
            }
            else
            {
                Energia.Recuperar();
                if(Energia.Cantidad == Energia.getLimiteCantidad())
                    Durmiendo = false;
            }
            Hambre.Desgastar();
        }

        public void Draw(SpriteBatch _spriteBatch, Dictionary<string, Texture2D> texturas, SpriteFont fuente)
        {
            if(!Durmiendo)
            {
                Rectangle frameCaminar = new Rectangle(anchuraCaminar * columnaCaminar, alturaCaminar * filaCaminar, anchuraCaminar, alturaCaminar);
                if(sentidoDerecha)
                    _spriteBatch.Draw(texturas["gato"], new Vector2(posicionX, posicionY), frameCaminar, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                else
                    _spriteBatch.Draw(texturas["gato"], new Vector2(posicionX, posicionY), frameCaminar, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
            }
            if(Hambre.CursorDentro && !Durmiendo && Hambre.Cantidad > 0)
                _spriteBatch.DrawString(fuente, "Oro: " + (Oro - Hambre.Precio), new Vector2(20, 300), Color.Red);
            else
                _spriteBatch.DrawString(fuente, "Oro: " + Oro, new Vector2(20, 300), Color.DarkGoldenrod);
            Energia.Draw(_spriteBatch, texturas["energia"], Durmiendo);
            Hambre.Draw(_spriteBatch, texturas["hambre"], Durmiendo);
        }

        public void EligirSentido()
        {
            if (rd.Next(0, 101) <= probabilidadIzquierda)
            {
                sentidoDerecha = false;
            }
            if (rd.Next(0, 101) > probabilidadIzquierda && rd.Next(0, 101) <= probabilidadDerecha)
            {
                sentidoDerecha = true;
            }
            caminando = rd.Next(0, 101) <= probabilidadCaminar;
        }

        public void Caminar()
        {
            columnaCaminar++;

            if (columnaCaminar == 2)
            {
                columnaCaminar = 0;
                caminando = false;
            }
            if (sentidoDerecha)
                posicionX += 10f;
            else
                posicionX -= 10f;
        }
        public void RestringirMovimiento()
        {
            if (posicionX < limiteIzquierda)
            {
                columnaCaminar = -1;
                sentidoDerecha = true;
                Caminar();
            }

            if (posicionX > limiteDerecha)
            {
                columnaCaminar = -1;
                sentidoDerecha = false;
                Caminar();
            }
        }
    }
}
