using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Tamagochi_Idle.Minijuegos.Serreria
{
    internal class SerreriaManager
    {
        public void Update(List<Particula> particulas, List<SerreriaGameObject> objetos, Corazon[] corazones, ref int vidas, Dictionary<string, Texture2D> texturas)
        {
            //Lógica de cortes
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                particulas.Add(new Particula(texturas));
                CortarTroncos(objetos);
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                Reset(objetos);
            }

            particulas.ForEach(n => n.Moverse());
            particulas.RemoveAll(n => n.ContadorDesaparecer == 17);

            ControlVidas(objetos, corazones, ref vidas);
            
            objetos.RemoveAll(n => n.ContadorDesaparecer == 20 || n.Posicion.Y >= 700);
        }
        public void CortarTroncos(List<SerreriaGameObject> objetos)
        {
            foreach (SerreriaGameObject objeto in objetos)
            {
                if (objeto.Hitbox.Contains(Mouse.GetState().X, Mouse.GetState().Y) && !objeto.SiendoCortado)
                {
                    objeto.SiendoCortado = true;
                    objeto.OriginarCorte(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
                }
                if (!objeto.Hitbox.Contains(Mouse.GetState().X, Mouse.GetState().Y) && objeto.SiendoCortado == true && !objeto.Cortado)
                {
                    objeto.SiendoCortado = false;
                    objeto.FinalizarCorte(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
                }
            }
        }
        public void Reset(List<SerreriaGameObject> objetos)
        {
            foreach (SerreriaGameObject objeto in objetos)
            {
                objeto.SiendoCortado = false;
            }
        }

        public void ControlVidas(List<SerreriaGameObject> objetos, Corazon[] corazones, ref int vidas)
        {
            int referenciaVidas = vidas;
            objetos.ForEach(n =>
            {
                if (n.Posicion.Y >= 700 && n is Tronquito && !n.Cortado)
                {
                    corazones[referenciaVidas - 1].Vivo = false;
                    referenciaVidas--;
                }
                if (n is Bomba && n.Cortado)
                    while (referenciaVidas > 0)
                    {
                        corazones[referenciaVidas - 1].Vivo = false;
                        referenciaVidas--;
                    }
            });
            vidas = referenciaVidas;
        }
    }
}
