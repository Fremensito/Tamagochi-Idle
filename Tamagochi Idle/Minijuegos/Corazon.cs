using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace Tamagochi_Idle.Minijuegos
{
    internal class Corazon
    {
        private Texture2D corazonVivo;
        private Texture2D corazonMuerto;
        private Vector2 posicion;
        
        public bool Vivo { get; set; }
        public Corazon(Dictionary<string, Texture2D> texturas, float posicionX, float posicionY)
        {
            corazonVivo = texturas["corazon vivo"];
            corazonMuerto = texturas["corazon muerto"];
            posicion = new Vector2(posicionX, posicionY);

            Vivo = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(Vivo)
                spriteBatch.Draw(corazonVivo, posicion, Color.White);
            else
                spriteBatch.Draw(corazonMuerto, posicion, Color.White);
        }
    }
}
