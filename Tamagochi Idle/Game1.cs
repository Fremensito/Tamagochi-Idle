using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Reflection.Metadata.Ecma335;
using Tamagochi_Idle.Pesca;
using Tamagochi_Idle.Escenario_Principal;
using System.Collections.Generic;
using Tamagochi_Idle.Serreria;

namespace Tamagochi_Idle
{
    public class Game1 : Game
    {
        EscenarioPrincipal escenarioPrincipal;
        EscenarioPesca escenarioPesca;
        Transition transicion;

        private int width = 900;
        private int height = 700;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SerreriaManager serreriaManager;

        private bool test = true;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 60);

            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges();

            //escenarioPrincipal = new EscenarioPrincipal();
            //transicion = new Transition();
            //escenarioPesca = new EscenarioPesca();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            /*escenarioPrincipal.LoadContent(Content);
            escenarioPesca.LoadContent(Content);
            transicion.LoadContent(Content);*/
            serreriaManager = new SerreriaManager();
        }

        protected override void Update(GameTime gameTime)
        {
            //escenarioPrincipal.Update(gameTime.ElapsedGameTime);

            /*if (escenarioPrincipal.CanyaJuego.CursorDentro && Mouse.GetState().LeftButton == ButtonState.Pressed && escenarioPrincipal.Activo)
            {
                transicion.Activa = true;
                escenarioPesca.Activo = true;
            }
            transicion.Update();

            if (transicion.IndiceColumna == 7)
            {
                escenarioPrincipal.Activo = false;
            }
            escenarioPesca.Update(gameTime.ElapsedGameTime);

            base.Update(gameTime);*/
            serreriaManager.Update(Content);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            /*escenarioPesca.Draw(_spriteBatch);
            escenarioPrincipal.Draw(_spriteBatch);
            transicion.Draw(_spriteBatch);*/
            serreriaManager.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}