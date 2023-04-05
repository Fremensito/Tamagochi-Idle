using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Tamagochi_Idle.Pesca;

namespace Tamagochi_Idle.Serreria
{
    internal class SerreriaManager
    {
        private Corte[] cortes;
        private int tamanyoCortes;
        private bool generarCortes;
        private Random rd = new Random();
        private float velocidadTronco;
        private float spawnProc;
        private List<Tronquito> tronquitos;

        public SerreriaManager()
        {
            tamanyoCortes = 8;
            cortes = new Corte[tamanyoCortes];
            generarCortes = true;
            spawnProc = 5;
            velocidadTronco = 4;
            tronquitos = new List<Tronquito>();
        }

        public void Update(ContentManager content)
        {
            AumentarDificultad(content);

            //Lógica de cortes
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (generarCortes)
                {
                    GenerarCortes(content);
                    generarCortes = false;
                }
                GenerarRastro();
                HacerRotar();
                CortarTroncos();
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                Reset();
            }

            tronquitos.RemoveAll(n => n.ContadorDesaparecer == 20 || n.Posicion.Y >= 700);
        }

        public void AumentarDificultad(ContentManager content)
        {
            //Se generan troncos y se aumenta la dificultad
            if (rd.Next(1, 1001) <= (int)spawnProc)
                tronquitos.Add(new Tronquito(rd.Next(0, 750), -150, content));
            foreach (Tronquito tronquito in tronquitos)
                tronquito.Update(velocidadTronco);
            velocidadTronco += 0.0006f;
            spawnProc += 0.008f;
        }

        public void GenerarCortes(ContentManager content)
        {
            for (int i = 0; i < cortes.Length; i++)
            {
                cortes[i] = new Corte(Mouse.GetState().X, Mouse.GetState().Y, content);
            }
        }
        public void GenerarRastro()
        {
            cortes[0].Update();
            cortes[0].DejarRastro();
            for (int i = 1; i < tamanyoCortes; i++)
            {
                cortes[i].DejarRastro();
                cortes[i].Posicion = cortes[i - 1].Rastro;
            }
        }
        public void CortarTroncos()
        {
            foreach (Tronquito tronquito in tronquitos)
            {
                if (cortes[0].Hitbox.Intersects(tronquito.Hitbox) && !tronquito.SiendoCortado)
                {
                    tronquito.SiendoCortado = true;
                    tronquito.OriginarCorte(cortes[0].Posicion);
                }
                if (!cortes[0].Hitbox.Intersects(tronquito.Hitbox) && tronquito.SiendoCortado == true && !tronquito.Cortado)
                {
                    tronquito.SiendoCortado = false;
                    tronquito.FinalizarCorte(cortes[0].Posicion);
                }
            }
        }

        public void HacerRotar()
        {
            foreach(Corte corte in cortes)
            {
                if(Vector2.Distance(cortes[cortes.Length - 1].Posicion, cortes[0].Posicion) != 0) 
                corte.Rotar(
                        Math.Atan2(
                            Vector2.Subtract(cortes[cortes.Length - 1].Posicion, cortes[0].Posicion).Y
                            , Vector2.Subtract(cortes[cortes.Length - 1].Posicion, cortes[0].Posicion).X));
            }
        }
        public void Reset()
        {
            generarCortes = true;

            for (int i = 0; i < cortes.Length; i++)
            {
                cortes[i] = null;
            }

            foreach (Tronquito tronquito in tronquitos)
            {
                tronquito.SiendoCortado = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tronquito tronquito in tronquitos)
            {
                tronquito.Draw(spriteBatch);
            }
            if (cortes[0] != null)
            {
                cortes[0].Draw(spriteBatch);
            }
        }
    }
}
