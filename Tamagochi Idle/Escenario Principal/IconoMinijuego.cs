using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Tamagochi_Idle
{
    internal abstract class IconoMinijuego
    {
        protected Texture2D normal;
        protected Texture2D seleccionado;

        protected Vector2 posicion;

        public bool CursorDentro { get; set; }

        public abstract void LoadContent(ContentManager content);

        public void Update()
        {
            ComprobarCursor();
        }

        public  void Draw(SpriteBatch _spriteBatch)
        {
            if (CursorDentro)
                _spriteBatch.Draw(seleccionado, posicion, Color.White);
            else
                _spriteBatch.Draw(normal, posicion, Color.White);
        }

        public void ComprobarCursor()
        {
            Rectangle campoInfluencia = normal.Bounds;
            Point posicionCampoInfluencia = new Point((int)posicion.X, (int)posicion.Y);
            campoInfluencia.Location = posicionCampoInfluencia;
            CursorDentro = campoInfluencia.Contains(Mouse.GetState().Position);
        }
    }
}
