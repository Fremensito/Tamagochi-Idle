using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tamagochi_Idle.Escenario_Principal
{
    internal class Vitalidad
    {
        protected Vector2 posicion;
        protected const int anchuraHambreSprite = 150;
        public DateTime Tiempo { get; set; }
        protected const int limiteCantidad = 7;
        public int Cantidad { get; set; }
        public bool CursorDentro;
        public int getLimiteCantidad()
        {
            return limiteCantidad;
        }

        protected void ComprobarCursor()
        {
            Rectangle campoInfluencia = new Rectangle((int)posicion.X, (int)posicion.Y, anchuraHambreSprite, anchuraHambreSprite);
            CursorDentro = campoInfluencia.Contains(Mouse.GetState().Position);
        }
    }
}