using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tamagochi_Idle.Minijuegos.Pesca
{
    internal class EscenarioPesca
    {
        public bool Activo { get; set; }

        private Texture2D fondo;
        private Borde bordeSuperior;
        private Borde bordeInferior;
        private SeccionMinijuego seccionMinijuego;

        public EscenarioPesca()
        {
            Activo = false;
            bordeSuperior = new Borde(new Vector2(0, 225));
            bordeInferior = new Borde(new Vector2(0, 625));
            seccionMinijuego = new SeccionMinijuego();
        }

        public void LoadContent(ContentManager content)
        {
            fondo = content.Load<Texture2D>("Pesca");
            bordeSuperior.LoadContent(content);
            bordeInferior.LoadContent(content);
            seccionMinijuego.LoadContent(content);
        }

        public void Update(TimeSpan tiempoFrame)
        {
            if (Activo)
            {
                bordeSuperior.Update(tiempoFrame);
                bordeInferior.Update(tiempoFrame);
                seccionMinijuego.Update(tiempoFrame);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (Activo)
            {
                _spriteBatch.Draw(fondo, new Vector2(0, 0), Color.White);
                bordeSuperior.Draw(_spriteBatch);
                bordeInferior.Draw(_spriteBatch);
                seccionMinijuego.Draw(_spriteBatch);
            }
        }
    }
}
