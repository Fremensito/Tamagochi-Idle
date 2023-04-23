using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;


namespace Tamagochi_Idle.Escenario_Principal
{
    internal class Energia
    {

        private Vector2 posicionBarra;

        private float posicionEnergiaY;
        private float posicionEnergiaX;
        public int Cantidad { get; set; }
        
        public Energia()
        {
            //leer el archvio Energia.txt
            string[] lineas = File.ReadAllLines("Energia.txt");
            Cantidad = int.Parse(lineas[0]);
            
            posicionEnergiaY = 16f;
            posicionEnergiaX = 23f;

            posicionBarra = new Vector2(14f, 7f);
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> texturas)
        {
            for(int i = 1; i <= Cantidad; i++)
            {
                if(i >= 1 && i < Cantidad)
                {
                    if (i == 1)
                    {
                        spriteBatch.Draw(texturas["energia extremos"], new Vector2(posicionEnergiaX, posicionEnergiaY), Color.White);
                        posicionEnergiaX += 21;
                    }
                    else
                    {
                        spriteBatch.Draw(texturas["energia intermedia"], new Vector2(posicionEnergiaX, posicionEnergiaY), Color.White);
                        posicionEnergiaX += 18;
                    }
                }
                else
                {
                    spriteBatch.Draw(texturas["energia extremos"], new Vector2(posicionEnergiaX, posicionEnergiaY), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
                    posicionEnergiaX = 23f;
                    posicionEnergiaY = 16f;
                }
            }
            spriteBatch.Draw(texturas["barra de energia"], posicionBarra, Color.White);
        }
    }
}
