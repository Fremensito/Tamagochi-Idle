using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tamagochi_Idle.Escenario_Principal
{
    internal class Gato
    {
        //Posicion del gato
        private float posicionX = 306f;
        private float posicionY = 503f;

        //Bloque de los parámetros necesarios para el caminar del gato
        private float velocidadCaminar = 400f;
        private Texture2D caminar; //Lo que va a dibujar el SpriteBatch
        private Texture2D caminarDerecha;
        private Texture2D caminarIzquierda;
        private int filaCaminar;
        private int columnaCaminar;
        private int anchuraCaminar;
        private int alturaCaminar;
        private double tiempoNecesarioCaminar;
        private double tiempoTranscurrido;
        private bool caminando;
        private bool sentidoDerecha;

        //Randomización de la acción del caminar
        private int probabilidadIzquierda = 3;
        private int probabilidadDerecha = 6;
        private int probabilidadCaminar = 4;
        private int probabilidad;

        private float limiteDerecha = 750f;
        private float limiteIzquierda = 0f;

        Random rd;
        public Gato()
        {

            filaCaminar = 0;
            columnaCaminar = 0;
            anchuraCaminar = 150;
            alturaCaminar = 150;
            tiempoNecesarioCaminar = 200;
            tiempoTranscurrido = 0;
            rd = new Random();
            caminando = false;
            sentidoDerecha = true;
        }

        public void LoadContent(ContentManager content)
        {
            caminarDerecha = content.Load<Texture2D>("gatoCaminaDerecha");
            caminarIzquierda = content.Load<Texture2D>("gatoCaminaIzquierda");
            caminar = caminarDerecha;
        }

        public void Update(TimeSpan gameTime)
        {
            tiempoTranscurrido += gameTime.TotalMilliseconds;
            if(tiempoTranscurrido > tiempoNecesarioCaminar)
            {
                probabilidad = rd.Next(0, 101);
                if (!caminando)
                {
                    if (probabilidad <= probabilidadIzquierda)
                    {
                        caminar = caminarIzquierda;
                        sentidoDerecha = false;
                    }
                    if (probabilidad > probabilidadIzquierda && probabilidad <= probabilidadDerecha)
                    {
                        caminar = caminarDerecha;
                        sentidoDerecha = true;
                    }
                    caminando = rd.Next(0, 101) <= probabilidadCaminar;
                }
                if (caminando)
                    Caminar(gameTime);
                if (posicionX < limiteIzquierda)
                {
                    columnaCaminar = -1;
                    sentidoDerecha = true;
                    caminar = caminarDerecha;
                    Caminar(gameTime);
                }

                if(posicionX > limiteDerecha)
                {
                    columnaCaminar = -1;
                    sentidoDerecha = false;
                    caminar = caminarIzquierda;
                    Caminar(gameTime);
                }
                tiempoTranscurrido = 0;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            Rectangle frameCaminar = new Rectangle(anchuraCaminar * columnaCaminar, alturaCaminar * filaCaminar, anchuraCaminar, alturaCaminar);
            _spriteBatch.Draw(caminar, new Vector2(posicionX, posicionY), frameCaminar, Color.White);
        }

        public void Caminar(TimeSpan gameTime)
        {
    
            {
                columnaCaminar++;

                if (columnaCaminar == 2)
                {
                    columnaCaminar = 0;
                    caminando = false;
                }
                if (sentidoDerecha)
                    CaminarDerecha(gameTime);
                else
                    CaminarIzquierda(gameTime);
            }
        }
        public void CaminarIzquierda(TimeSpan gameTime)
        {
            posicionX -= (float)gameTime.TotalSeconds * velocidadCaminar;
        }
        public void CaminarDerecha(TimeSpan gameTime)
        {
            posicionX += (float)gameTime.TotalSeconds * velocidadCaminar;
        }
    }
}
