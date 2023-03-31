﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tamagochi_Idle.Serreria
{
    internal class Corte
    {
        public Texture2D Sprite { get; set; }
        public float PosicionX { get; set; }
        public float PosicionY { get; set; }
        public Vector2 Posicion { get; set; }
        public Vector2 Rastro { get; set; }
        public Rectangle Hitbox { get; set; }
        public Corte(float posicionX, float posicionY, ContentManager content)
        {
            PosicionX = posicionX;
            PosicionY = posicionY;
            LoadContent(content);
            Posicion = new Vector2(posicionX, posicionY);
        }

        public void LoadContent(ContentManager content)
        {
            Sprite = content.Load<Texture2D>("corte");
        }

        public void Update()
        {
            Posicion = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            Hitbox = new Rectangle((int)Posicion.X, (int)Posicion.Y, Sprite.Width, Sprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Posicion, Color.White);
        }

        public void DejarRastro()
        {
            Rastro = Posicion;
        }
    }
}