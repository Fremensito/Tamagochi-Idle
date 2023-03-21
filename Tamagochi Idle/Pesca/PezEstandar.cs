using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tamagochi_Idle.Pesca
{
    internal class PezEstandar:Pez
    {
        public PezEstandar()
        {

        }
        public PezEstandar(Texture2D sprite, float posicionY)
        {
            velocidad = 100f;
            PosicionX = -150f;
            PosicionY = posicionY;
            Sprite = sprite;
        }
        public override void LoadContent(ContentManager content)
        {
            Sprite = content.Load<Texture2D>("carpa");
        }
    }
}
