using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tamagochi_Idle.Escenario_Principal
{
    internal class Hambre:Vitalidad
    {
        public int Hambruna { get; set; }
        private const int gananciaHambruna = 1;
        private const int desgaste = 40;
        public int Precio { get; set;}

        public Hambre()
        {
            posicion = new Vector2(14f, 130f);
            CursorDentro = false;
        }

        public void Desgastar()
        {
            int diferencia = (int) DateTime.Now.Subtract(Tiempo).TotalMinutes;
            
            if(Cantidad < limiteCantidad)
            {
                while(Cantidad < limiteCantidad && diferencia >= desgaste)
                {
                    Cantidad++;
                    diferencia -= desgaste;
                    Tiempo = Tiempo.AddMinutes(desgaste);
                }
            }
        }

        public void GanarHambruna()
        {
            int diferencia = (int) DateTime.Now.Subtract(Tiempo).TotalHours;
            if(Hambruna < limiteCantidad)
            {
                while(Hambruna < limiteCantidad && diferencia >= gananciaHambruna)
                {
                    Hambruna++;
                    diferencia -= gananciaHambruna;
                    Tiempo = Tiempo.AddHours(gananciaHambruna);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D textura, bool durmiendo)
        {
            Rectangle fraccionSprite = new Rectangle(anchuraHambreSprite * Cantidad, 0, anchuraHambreSprite, anchuraHambreSprite);
            ComprobarCursor();
            //if cursorDentro scale the drawing
            if(CursorDentro && Cantidad > 0 && !durmiendo)
                spriteBatch.Draw(textura, posicion, fraccionSprite, Color.White, 0f, Vector2.Zero, 1.1f, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(textura, posicion, fraccionSprite, Color.White);
        }
    }
}