using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tamagochi_Idle.Pesca
{
    internal class SeccionMinijuego
    {
        private List<PezEstandar> pecesEstandar;
        private PezEstandar pezEstandar;
        private int limiteSuperior = 275;
        private int limiteInferior = 500;
        private ContentManager content;

        Random rd = new Random();
        private int probabilidadEstandar;

        public SeccionMinijuego()
        {
            pecesEstandar = new List<PezEstandar>();
            probabilidadEstandar = 10;
            pezEstandar = new PezEstandar();
        }

        public void LoadContent(ContentManager content)
        {
            pezEstandar.LoadContent(content);
        }
        public void Update(TimeSpan gameTime)
        {
            if(rd.Next(1, 1001) <= probabilidadEstandar)
            {
                pezEstandar.PosicionY = rd.Next(limiteSuperior, limiteInferior + 1);
                pecesEstandar.Add(new PezEstandar(pezEstandar.Sprite, (float)rd.Next(limiteSuperior, limiteInferior +1)));
            }
            for (int i = 0; i < pecesEstandar.Count; i++)
            {
                pecesEstandar[i].Update(gameTime);
            }
            pecesEstandar.RemoveAll(x => x.PosicionX > 1050f);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < pecesEstandar.Count; i++)
                pecesEstandar[i].Draw(_spriteBatch);
        }
    }
}
