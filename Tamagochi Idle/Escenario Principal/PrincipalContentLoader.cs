using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Tamagochi_Idle.Escenario_Principal
{
    internal static class PrincipalContentLoader
    {   
        static public Dictionary<string, Texture2D> LoadTextures(ContentManager content)
        {
            Dictionary<string, Texture2D> texturas = new Dictionary<string, Texture2D>();

            texturas.Add("fondo", content.Load<Texture2D>("principal/fondo"));
            texturas.Add("fondo noche", content.Load<Texture2D>("principal/fondoNight"));
            texturas.Add("gato", content.Load<Texture2D>("principal/gatoCaminaDerecha"));
            texturas.Add("energia", content.Load<Texture2D>("principal/energySet"));
            texturas.Add("hambre", content.Load<Texture2D>("principal/Hambre"));
            texturas.Add("hacha", content.Load<Texture2D>("canya"));
            texturas.Add("hacha seleccionada", content.Load<Texture2D>("canyaBrillo"));
            texturas.Add("resultado", content.Load<Texture2D>("Resultado"));

            return texturas;
        }
        static public SpriteFont LoadSpriteFont(ContentManager content)
        {
            return content.Load<SpriteFont>("fuente");
        }
    }
}
