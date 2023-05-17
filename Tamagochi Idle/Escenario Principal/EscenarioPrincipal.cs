using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Tamagochi_Idle.Minijuegos.Serreria;

namespace Tamagochi_Idle.Escenario_Principal
{
    internal class EscenarioPrincipal
    {
        private Dictionary<string, Texture2D> texturas;
        public SpriteFont Fuente {get; set;}
        public Gato Gato {get; set;}
        private CanyaJuego canya;
        private EscenarioPrincipalManager manager;
        private bool jugar;
        private EscenarioSerreria serreria;
        public MensajeSalir Mensaje {get; set;}
        public bool getJugar()
        {
            return jugar;
        }
        public EscenarioPrincipal(ContentManager content)
        {
            jugar = false;
            Gato = new Gato();
            canya = new CanyaJuego();
            manager = new EscenarioPrincipalManager();
            LoadContent(content);
            Mensaje = new MensajeSalir(texturas, Fuente);
        }
        public void LoadContent(ContentManager content)
        {
            texturas = PrincipalContentLoader.LoadTextures(content);
            Fuente = PrincipalContentLoader.LoadSpriteFont(content);
        }

        public void Update(ContentManager content)
        {
            if(!jugar)
            {
                MostrarElementos(content);
                if(jugar)
                serreria = new EscenarioSerreria(content);
            }
            if (jugar)
            {
                jugar = serreria.Update(content, Gato);
            }
        }

        private void MostrarElementos(ContentManager content)
        {
            Gato.Update();
            canya.Update(texturas);
            manager.Update(canya, Gato, Mensaje, ref jugar);
            if (Mensaje.Mostrar)
            {
                Mensaje.Update();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!jugar)
            {
                if(!Gato.Durmiendo)
                    spriteBatch.Draw(texturas["fondo"], new Vector2(0f, 0f), Color.White);
                else
                    spriteBatch.Draw(texturas["fondo noche"], new Vector2(0f, 0f), Color.White);
                Gato.Draw(spriteBatch, texturas, Fuente);
                canya.Draw(texturas, spriteBatch, Gato);
            }
            if (jugar)
            {
                serreria.Draw(spriteBatch);
            }
            if (Mensaje.Mostrar)
            {
                Mensaje.Draw(spriteBatch, texturas, Fuente);
            }
        }
    }
}
