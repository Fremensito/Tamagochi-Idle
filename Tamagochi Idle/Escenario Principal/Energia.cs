﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace Tamagochi_Idle.Escenario_Principal
{
    internal class Energia: Vitalidad
    {
        private const int recuperacion = 40;
        private const int desgaste = 1;
        public Energia()
        {  
            posicion = new Vector2(14f, -30f);
        }

        public void Recuperar()
        {
            int diferencia = (int) DateTime.Now.Subtract(Tiempo).TotalMinutes;
            if(Cantidad < limiteCantidad)
            {
                while(Cantidad < limiteCantidad && diferencia >= recuperacion)
                {
                    Cantidad++;
                    diferencia -= recuperacion;
                    Tiempo = Tiempo.AddMinutes(recuperacion);
                }
            }
        }

        public void Desgastar()
        {
            int diferencia = (int) DateTime.Now.Subtract(Tiempo).TotalHours;
            if(Cantidad > 0)
            {
                while(Cantidad > 0 && diferencia >= desgaste)
                {
                    Cantidad--;
                    diferencia -= desgaste;
                    Tiempo = Tiempo.AddHours(desgaste);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D textura, bool durmiendo)
        {
            Rectangle fraccionSprite = new Rectangle(anchuraHambreSprite * Cantidad, 0, anchuraHambreSprite, anchuraHambreSprite);
            ComprobarCursor();
            //if cursorDentro scale the drawing
            if(CursorDentro && Cantidad < limiteCantidad && !durmiendo)
                spriteBatch.Draw(textura, posicion, fraccionSprite, Color.White, 0f, Vector2.Zero, 1.1f, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(textura, posicion, fraccionSprite, Color.White);
        }
    }
}
