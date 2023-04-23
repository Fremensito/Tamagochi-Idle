using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Tamagochi_Idle.Minijuegos.Serreria
{
    internal class Tronquito : SerreriaGameObject
    {
        public Tronquito(float posicionX, float posicionY, Dictionary<string, Texture2D> texturas, Dictionary<string, SoundEffect> sonidos)
            : base(posicionX, posicionY)
        {
            texturaCompacto = texturas["tronco"];
            texturaCortado = texturas["tronco cortado"];
            sonidoCorte = sonidos["corte"];
        }
    }
}
