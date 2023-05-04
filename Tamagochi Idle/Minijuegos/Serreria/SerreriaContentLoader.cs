using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Tamagochi_Idle.Minijuegos.Serreria
{
    internal static class SerreriaContentLoader
    {
        private static Dictionary<string, Texture2D>  texturas;

        static public Dictionary<string, Texture2D> getTexturas(){
            return texturas;
        }
        static public Dictionary<string, Texture2D> getTexturas(ContentManager content){
            if(texturas == null)
                LoadTextures(content);
            return texturas;
        }
        static private void LoadTextures(ContentManager content)
        {
            texturas = new Dictionary<string, Texture2D>();

            texturas.Add("tronco", content.Load<Texture2D>("serreria/tronco"));
            texturas.Add("tronco cortado vertical", content.Load<Texture2D>("serreria/troncoPartido"));
            texturas.Add("tronco cortado diagonal", content.Load<Texture2D>("serreria/diagonalCutWood"));
            texturas.Add("tronco cortado horizontal", content.Load<Texture2D>("serreria/horizontalCutWood"));
            texturas.Add("bomba", content.Load<Texture2D>("serreria/bomb"));
            texturas.Add("explosion", content.Load<Texture2D>("serreria/explosion"));
            texturas.Add("particula 1", content.Load<Texture2D>("serreria/woodParticle1"));
            texturas.Add("particula 2", content.Load<Texture2D>("serreria/woodParticle2"));
            texturas.Add("particula 3", content.Load<Texture2D>("serreria/woodParticle3"));
            texturas.Add("particula 4", content.Load<Texture2D>("serreria/woodParticle4"));
            texturas.Add("corazon vivo", content.Load<Texture2D>("HeartA"));
            texturas.Add("corazon muerto", content.Load<Texture2D>("HeartADead"));
            texturas.Add("resultado", content.Load<Texture2D>("Resultado"));
        }

        static public Dictionary<string, SoundEffect> LoadSoundEffects(ContentManager content){
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
