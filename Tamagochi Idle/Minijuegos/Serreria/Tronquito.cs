using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Tamagochi_Idle.Minijuegos.Serreria
{
    internal class Tronquito : SerreriaGameObject
    {
        enum TIPOCORTE { VERTICAL, DIAGONALD, DIAGONALY, HORIZONTAL, NONE};

        private TIPOCORTE tipoCorte;
        public Tronquito(float posicionX, float posicionY, Dictionary<string, Texture2D> texturas, Dictionary<string, SoundEffect> sonidos)
            : base(posicionX, posicionY)
        {
            texturaCompacto = texturas["tronco"];
            sonidoCorte = sonidos["corte"];
        }

        public override void FinalizarCorte(Vector2 finalCorte)
        {
            float distancia = Vector2.Distance(finalCorte, origenCorte);
            if (distancia >= texturaCompacto.Width - 40)
            {
                sonidoCorte.Play();
                Cortado = true;
                DarPunto = true;
                double angulo = Math.Atan2(finalCorte.Y - origenCorte.Y, finalCorte.X - origenCorte.X)*180/Math.PI;
                Console.WriteLine(angulo);
                ComprobarCorteVertical(angulo);
                ComprobarCorteDiagonal(angulo);
                ComprobarCorteHorizontal(angulo);
            }
        }

        private void ComprobarCorteVertical(double angulo)
        {
            if((angulo >= 70 && angulo <= 110) || (angulo >= -110 && angulo <= -70))
            {
                tipoCorte = TIPOCORTE.VERTICAL;
                texturaCortado = SerreriaContentLoader.getTexturas()["tronco cortado vertical"];
            }
        }

        private void ComprobarCorteDiagonal(double angulo)
        {
            if((angulo < -20 && angulo > -70) || (angulo < 160 && angulo > 110))
            {
                tipoCorte = TIPOCORTE.DIAGONALD;
                texturaCortado = SerreriaContentLoader.getTexturas()["tronco cortado diagonal"];
            }
            if((angulo < -110 && angulo > -160) || (angulo < 70 && angulo > 20))
            {
                tipoCorte = TIPOCORTE.DIAGONALY;
                texturaCortado = SerreriaContentLoader.getTexturas()["tronco cortado diagonal"];
            }
        }


        private void ComprobarCorteHorizontal(double angulo)
        {
            if((angulo >= 0 && angulo <= 20) || (angulo >= -180 && angulo <= -160)
                || (angulo >= 160 && angulo <= 180) || (angulo >= -20 && angulo <= 0))
                {
                    tipoCorte = TIPOCORTE.HORIZONTAL;
                    texturaCortado = SerreriaContentLoader.getTexturas()["tronco cortado horizontal"];
                }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Cortado)
            {
                switch(tipoCorte)
                {
                    case TIPOCORTE.VERTICAL:
                        spriteBatch.Draw(texturaCortado, Posicion, Color.White);
                        break;
                    case TIPOCORTE.DIAGONALY:
                        spriteBatch.Draw(texturaCortado, Posicion, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                        break;
                    case TIPOCORTE.DIAGONALD:
                        spriteBatch.Draw(texturaCortado, Posicion, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
                        break;
                    case TIPOCORTE.HORIZONTAL:
                        spriteBatch.Draw(texturaCortado, Posicion, null, Color.White);
                        break;
                }
            }
            else
            {
                spriteBatch.Draw(texturaCompacto, Posicion, Color.White);
            }
        }
    }
}
