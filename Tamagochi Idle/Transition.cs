using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.ComponentModel.Design;

namespace Tamagochi_Idle
{
    internal class Transition
    {
        private Texture2D animacion;

        public int IndiceColumna { get; set; }
        private int indiceFila;

        private int altura;
        private int anchura;

        private bool adelante;
        public bool Activa { get; set; }

        public Transition()
        {
            altura = 700;
            anchura = 900;
            adelante = true;
            IndiceColumna = -1;
            indiceFila = 0;
            Activa = false;
        }

        public void LoadContent(ContentManager content)
        {
            animacion = content.Load<Texture2D>("transicion");
        }

        public void Update()
        {
            if (Activa && adelante)
            {
                IndiceColumna++;
            }
            if(IndiceColumna == 8)
            {
                adelante = false;
            }
            if (!adelante && Activa)
            {
                IndiceColumna--;
            }
            if (IndiceColumna == -1)
            {
                adelante = true;
                Activa = false;
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            if (Activa)
            {
                Rectangle frame = new Rectangle(anchura * IndiceColumna, altura * indiceFila, anchura, altura);
                _spriteBatch.Draw(animacion, new Vector2(0, 0), frame, Color.White);
            }
        }
    }
}
