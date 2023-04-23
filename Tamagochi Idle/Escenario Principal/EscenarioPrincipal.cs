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
        private SpriteFont fuente;
        private Gato gato;
        private CanyaJuego canya;
        private EscenarioPrincipalManager manager;
        private bool jugar;
        private bool contentLoaded;
        private EscenarioSerreria serreria;
        private MensajeSalir mensaje;
        public EscenarioPrincipal(ContentManager content)
        {
            jugar = false;
            gato = new Gato();
            canya = new CanyaJuego();
            manager = new EscenarioPrincipalManager();
            contentLoaded = LoadContent(content);
            mensaje = new MensajeSalir(texturas, fuente);
        }
        public bool LoadContent(ContentManager content)
        {
            texturas = PrincipalContentLoader.LoadTextures(content);
            fuente = PrincipalContentLoader.LoadSpriteFont(content);
            return true;
        }

        public void Update(ContentManager content)
        {
            MostrarElementos (content);
            MostrarMiniJuego (content);
        }

        private void MostrarElementos(ContentManager content)
        {
            if (!jugar)
            {
                if(!contentLoaded)
                {
                    contentLoaded = LoadContent(content);
                }
                gato.Update();
                canya.Update(texturas);
                manager.Update(canya, gato, mensaje, ref jugar);
            }
            if(mensaje.Mostrar)
            {
                mensaje.Update();
            }
        }

        private void MostrarMiniJuego(ContentManager content)
        {
            if(jugar == true && contentLoaded)
            {
                content.Unload();
                contentLoaded = false;
                serreria = new EscenarioSerreria(content);
            }
            if(jugar)
            {
                jugar = serreria.Update(content);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {   
            if (!jugar && contentLoaded)
            {
                spriteBatch.Draw(texturas["fondo"], new Vector2(0f, 0f), Color.White);
                gato.Draw(spriteBatch, texturas);
                canya.Draw(texturas, spriteBatch);
            }
            if(jugar)
            {
                serreria.Draw(spriteBatch);
            }
            if(mensaje.Mostrar)
            {
                mensaje.Draw(spriteBatch, texturas, fuente);
            }
        }
    }
}
