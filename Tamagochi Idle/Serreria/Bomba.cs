using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Tamagochi_Idle.Serreria
{
    internal class Bomba : SerreriaGameObject
    {
        public Bomba(float posicionX, float posicionY, Dictionary<string, Texture2D> texturas, Dictionary<string, SoundEffect> sonidos) 
            : base(posicionX, posicionY)
        {
            texturaCompacto = texturas["bomba"];
            texturaCortado = texturas["explosion"];
            sonidoCorte = sonidos["explosion"];
        }
    }
}
