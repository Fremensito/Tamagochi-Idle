using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;


namespace Tamagochi_Idle.Serreria
{
    internal class SerreriaManager
    {
        private Corte[] cortes;
        private int contador = 0;
        private Tronquito tronquito;
        private bool test = true;
        private bool cortando = false;
        Random rd = new Random();
        private float velocidadTronco;
        private float spawnProc;
        private List<Tronquito> tronquitos;
        private int longitudAIterar;

        public SerreriaManager(ContentManager content)
        {
            cortes = new Corte[30];
            tronquito = new Tronquito(400, -150, content);
            spawnProc = 5;
            velocidadTronco = 4;
            tronquitos = new List<Tronquito>();
        }

        public void Update(ContentManager content)
        {
            if (rd.Next(1, 1001) <= (int)spawnProc)
                tronquitos.Add(new Tronquito(rd.Next(0, 750), -150, content));
            foreach (Tronquito tronquito in tronquitos)
                tronquito.Update(velocidadTronco);

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (test)
                {
                    for (int i = 0; i < cortes.Length; i++)
                    {
                        cortes[i] = new Corte(Mouse.GetState().X, Mouse.GetState().Y, content);
                    }
                    test = false;
                }
                if (contador == 0)
                {
                    cortes[0].DejarRastro();
                }
   
                cortes[0].Update();
                foreach(Tronquito tronquito in tronquitos)
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

                if (contador == 1)
                {
                    Vector2 unitario = cortes[0].Rastro - cortes[0].Posicion;
                    unitario.Normalize();
                    float distancia = Vector2.Distance(cortes[0].Rastro, cortes[0].Posicion);
                    for (int i = 1; i < cortes.Length; i++)
                    {
                        cortes[i].Posicion = Vector2.Multiply(unitario, (i * distancia) / 29) + cortes[0].Posicion;
                    }
                    contador = -1;
                }
                contador++;
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                test = true;
                for (int i = 0; i < cortes.Length; i++)
                {
                    cortes[i] = null;
                }
                contador = 0;

                foreach(Tronquito tronquito in tronquitos)
                {
                    tronquito.SiendoCortado = false;
                }
            }

            longitudAIterar = tronquitos.Count;
            for(int i = 0; i < longitudAIterar; i++)
            {
                if (tronquitos[i].ContadorDesaparecer == 20 || tronquitos[i].Posicion.Y >= 750)
                {
                    tronquitos.RemoveAt(i);
                    longitudAIterar--;
                }
            }

            velocidadTronco += 0.0006f;
            spawnProc += 0.008f;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tronquito tronquito in tronquitos)
            {
                tronquito.Draw(spriteBatch);
            }
            foreach (Corte corte in cortes)
            {
                if (corte != null)
                    corte.Draw(spriteBatch);
            }
        }
    }
}
