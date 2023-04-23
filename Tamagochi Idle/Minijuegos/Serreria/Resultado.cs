using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tamagochi_Idle.Minijuegos.Serreria
{
    class Resultado
    {
        private Texture2D textura;
        private SpriteFont fuente;
        private byte contadorAparicion;
        private Rectangle continuar;
        public bool Fin{get; set;}
        public Resultado(Dictionary<string, Texture2D> texturas, SpriteFont fuente)
        {
            textura = texturas["resultado"];
            this.fuente = fuente;
            contadorAparicion = 0;
            continuar = new Rectangle(315, 360, 260, 40);
            Fin = false;
        }

        public void Update(){
            if(contadorAparicion == 60){
                if(continuar.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Pressed){
                    Fin = true;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, int troncos)
        {
            if(contadorAparicion < 60)
            {
                contadorAparicion++;
            }
            if(contadorAparicion == 60){
                spriteBatch.Draw(textura, new Vector2(180, 180), Color.White);
                spriteBatch.DrawString(fuente, "Score: " + troncos + " = " + troncos/3 + " Oro", new Vector2(300, 252), Color.SaddleBrown);
                //si el ratón está dentro del rectángulo salir, se pinta de otro color
                if (continuar.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                {
                    spriteBatch.DrawString(fuente, "CONTINUAR", new Vector2(330, 360), Color.Yellow);
                }
                else
                    spriteBatch.DrawString(fuente, "CONTINUAR", new Vector2(330, 360), Color.SaddleBrown);
            }
        }
    }
}