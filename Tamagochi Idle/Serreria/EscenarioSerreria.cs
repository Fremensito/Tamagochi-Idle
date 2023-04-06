using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using System;
using Microsoft.Xna.Framework;

namespace Tamagochi_Idle.Serreria
{
    internal class EscenarioSerreria
    {
        private SerreriaManager serreriaManager;

        Dictionary<string, Texture2D> texturas;
        Dictionary<string, SoundEffect> sonidos;

        private List<SerreriaGameObject> objetos;
        private List<Particula> particulas;

        private Random rd = new Random();
        private float velocidadMovimiento;
        private float spawnProc;
        private int probabilidadBomba;
        public EscenarioSerreria(ContentManager content)
        {
            serreriaManager = new SerreriaManager();

            texturas = SerreriaContentLoader.LoadTextures(content);
            sonidos = SerreriaContentLoader.LoadSoundEffects(content);

            objetos = new List<SerreriaGameObject>();
            particulas = new List<Particula>();

            spawnProc = 5;
            velocidadMovimiento = 4;
            probabilidadBomba = 10;
        }
        public void Update()
        {
            GenerarObjetos();
            serreriaManager.Update(particulas, objetos, texturas);
        }

        public void GenerarObjetos()
        {
            int posicionX = rd.Next(0, 750);
            int posicionY = -150;
            bool anyadir = true;

            //Se generan troncos y se aumenta la dificultad
            if (rd.Next(1, 1001) <= (int)spawnProc)
            {
                objetos.ForEach(n =>
                {
                    if (n.Hitbox.Intersects(new Rectangle(posicionX, posicionY, n.Hitbox.Width, n.Hitbox.Height)))
                        anyadir = false;
                });

                if (anyadir)
                {
                    if (rd.Next(1, 101) <= probabilidadBomba)
                        objetos.Add(new Bomba(posicionX, posicionY, texturas, sonidos));
                    else
                        objetos.Add(new Tronquito(posicionX, posicionY, texturas, sonidos));
                }
            }
            foreach (SerreriaGameObject objeto in objetos)
                objeto.Update(velocidadMovimiento);
            velocidadMovimiento += 0.0006f;
            spawnProc += 0.008f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (SerreriaGameObject objeto in objetos)
            {
                objeto.Draw(spriteBatch);
            }
            particulas.ForEach(n => n.Draw(spriteBatch));
        }
    }
}
