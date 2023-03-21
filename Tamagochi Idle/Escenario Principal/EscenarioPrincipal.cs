using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tamagochi_Idle.Escenario_Principal
{
    internal class EscenarioPrincipal
    {
        private Texture2D fondo;

        private Gato gatito;
        public bool Activo { get; set; }
        public CanyaJuego CanyaJuego { get; set; }

        public EscenarioPrincipal()
        {
            CanyaJuego = new CanyaJuego();
            gatito = new Gato();
            Activo = true;
        }
        public void LoadContent(ContentManager content)
        {
            fondo = content.Load<Texture2D>("fondo");
            CanyaJuego.LoadContent(content);
            gatito.LoadContent(content);
        }

        public void Update(TimeSpan gameTime)
        {
            if (Activo)
            {
                CanyaJuego.Update();
                gatito.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (Activo)
            {
                _spriteBatch.Draw(fondo, new Vector2(0, 0), Color.White);
                gatito.Draw(_spriteBatch);
                CanyaJuego.Draw(_spriteBatch);
            }
        }
    }
}
