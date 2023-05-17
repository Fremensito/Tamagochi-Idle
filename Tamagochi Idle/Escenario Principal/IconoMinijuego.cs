using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Tamagochi_Idle.Escenario_Principal
{
    internal abstract class IconoMinijuego
    {
        protected Vector2 posicion;
        public bool CursorDentro { get; set; }

        public void Update(Dictionary<string, Texture2D> texturas)
        {
            ComprobarCursor(texturas);
        }

        public  void Draw(Dictionary<string, Texture2D>texturas, SpriteBatch spriteBatch, Gato gato)
        {
            if (CursorDentro && !gato.Durmiendo)
                spriteBatch.Draw(texturas["hacha seleccionada"], posicion, Color.White);
            else
                spriteBatch.Draw(texturas["hacha"], posicion, Color.White);
        }

        public void ComprobarCursor(Dictionary<string, Texture2D> texturas)
        {
            Rectangle campoInfluencia = texturas["hacha"].Bounds;
            Point posicionCampoInfluencia = new Point((int)posicion.X, (int)posicion.Y);
            campoInfluencia.Location = posicionCampoInfluencia;
            CursorDentro = campoInfluencia.Contains(Mouse.GetState().Position);
        }
    }
}
