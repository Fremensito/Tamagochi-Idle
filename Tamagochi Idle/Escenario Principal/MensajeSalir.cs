using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tamagochi_Idle.Escenario_Principal
{
    class MensajeSalir
    {
        public bool Mostrar { get; set; }
        public bool Salir { get; set; }
        private Rectangle si;
        private Rectangle no;

        public MensajeSalir(Dictionary<string, Texture2D> texturas, SpriteFont fuente){
            Mostrar = false;
            Salir = false;
            si = new Rectangle(300, 360, 100, 50);
            no = new Rectangle(500, 360, 100, 50);
        }

        public void Update(){
            if (si.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Salir = true;
            }
            if (no.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Mostrar = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> texturas, SpriteFont fuente){
            spriteBatch.Draw(texturas["resultado"], new Vector2(180, 180), Color.White);
            spriteBatch.DrawString(fuente, "Guardar y salir", new Vector2(330, 252), Color.SaddleBrown);

            if (si.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                spriteBatch.DrawString(fuente, "SI", new Vector2(340, 360), Color.Yellow);
            }
            else
                spriteBatch.DrawString(fuente, "SI", new Vector2(340, 360), Color.SaddleBrown);
            if (no.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                spriteBatch.DrawString(fuente, "NO", new Vector2(510, 360), Color.Yellow);
            }
            else
             spriteBatch.DrawString(fuente, "NO", new Vector2(510, 360), Color.SaddleBrown);
        }
    }
}