using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Tamagochi_Idle.Minijuegos.Serreria
{
    internal static class SerreriaContentLoader
    {
        static public Dictionary<string, Texture2D> LoadTextures(ContentManager content)
        {
            Dictionary<string, Texture2D> texturas = new Dictionary<string, Texture2D>();

            texturas.Add("tronco", content.Load<Texture2D>("serreria/tronco"));
            texturas.Add("tronco cortado", content.Load<Texture2D>("serreria/troncoPartido"));
            texturas.Add("bomba", content.Load<Texture2D>("serreria/bomb"));
            texturas.Add("explosion", content.Load<Texture2D>("serreria/explosion"));
            texturas.Add("particula 1", content.Load<Texture2D>("serreria/woodParticle1"));
            texturas.Add("particula 2", content.Load<Texture2D>("serreria/woodParticle2"));
            texturas.Add("particula 3", content.Load<Texture2D>("serreria/woodParticle3"));
            texturas.Add("particula 4", content.Load<Texture2D>("serreria/woodParticle4"));
            texturas.Add("corazon vivo", content.Load<Texture2D>("HeartA"));
            texturas.Add("corazon muerto", content.Load<Texture2D>("HeartADead"));
            texturas.Add("resultado", content.Load<Texture2D>("Resultado"));

            return texturas;
        }

        static public Dictionary<string, SoundEffect> LoadSoundEffects(ContentManager content)
        {
            Dictionary<string, SoundEffect> sonidos = new Dictionary<string, SoundEffect>();

            sonidos.Add("corte", content.Load<SoundEffect>("serreria/cutSound"));
            sonidos.Add("explosion", content.Load<SoundEffect>("serreria/explosionSound"));

            return sonidos;
        }

        static public SpriteFont LoadSpriteFont(ContentManager content)
        {
            return content.Load<SpriteFont>("fuente");
        }
    }
}
