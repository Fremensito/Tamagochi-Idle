using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using System;
using Microsoft.Xna.Framework;
using System.Threading;

namespace Tamagochi_Idle.Minijuegos.Serreria
{
    internal class EscenarioSerreria
    {
        private SerreriaManager serreriaManager;

        private Dictionary<string, Texture2D> texturas;
        private Dictionary<string, SoundEffect> sonidos;
        private SpriteFont fuente;

        private List<SerreriaGameObject> objetos;
        private List<Particula> particulas;
        private Corazon[] corazones;

        private Random rd = new Random();
        private float velocidadMovimiento;
        private float spawnProc;
        private int probabilidadBomba;

        private int vidas;
        private int troncos;
        private Resultado resultado;
        public EscenarioSerreria(ContentManager content)
        {
            serreriaManager = new SerreriaManager();

            texturas = SerreriaContentLoader.getTexturas(content);
            sonidos = SerreriaContentLoader.LoadSoundEffects(content);
            fuente = SerreriaContentLoader.LoadSpriteFont(content);

            objetos = new List<SerreriaGameObject>();
            particulas = new List<Particula>();

            corazones = new Corazon[3];
            corazones[0] = new Corazon(texturas, 20f, 10f);
            corazones[1] = new Corazon(texturas, 80f, 10f);
            corazones[2] = new Corazon(texturas, 140f, 10f);

            spawnProc = 5f;
            velocidadMovimiento = 4f;
            probabilidadBomba = 10;

            vidas = 3;
            troncos = 0;
        }
        public bool Update(ContentManager content)
        {
            bool jugar = true;
            if(vidas != 0)
            {
                GenerarObjetos();
                RecibirPuntos();
                AumentarDificultad();
            }
            else
            {
                if(resultado == null)
                    resultado = new Resultado(texturas, fuente);
                else
                {
                    resultado.Update();
                    if (resultado.Fin)
                    {
                        jugar = false;
                    }
                }
            }
            serreriaManager.Update(particulas, objetos, corazones, ref vidas, texturas);
            return jugar;
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
        }
        public void RecibirPuntos()
        {
            objetos.ForEach(n =>
            {
                if(n is Tronquito && n.DarPunto)
                {
                    n.DarPunto = false;
                    troncos++;
                }
            });
        }
        public void AumentarDificultad()
        {
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
            foreach(Corazon corazon in corazones)
                corazon.Draw(spriteBatch);
            spriteBatch.DrawString(fuente, "Score: " + troncos, new Vector2(20, 620), Color.SaddleBrown);
            if(resultado != null)
                resultado.Draw(spriteBatch, troncos);
        }
    }
}
