using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Tamagochi_Idle.Escenario_Principal;
using System.IO;


namespace Tamagochi_Idle
{
    public class Game1 : Game
    {
        private EscenarioPrincipal escenarioPrincipal;
        private int width = 900;
        private int height = 700;
        private DateTime inicioPartida;
        private enum datos {ENERGIA = 1, TIEMPOENERGIA = 2, HAMBRE = 4, TIEMPOHAMBRE = 5, ORO = 7, DURMIENDO = 9, VIVO = 11, INICIOPARTIDA = 12};
        private int precio = 5;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
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
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            escenarioPrincipal = new EscenarioPrincipal(Content);

            if(!File.Exists("partida.txt"))
            {   
                using (StreamWriter sw = File.CreateText("partida.txt"))
                {
                    sw.WriteLine("Energia;" + escenarioPrincipal.Gato.Energia.getLimiteCantidad());
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine("Hambre;0");
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine("Oro;0");
                    sw.WriteLine("Durmiendo;false");
                    sw.WriteLine("Vivo;true");
                    sw.WriteLine(DateTime.Now);
                }
            }

            string partida = File.ReadAllText("partida.txt");
            escenarioPrincipal.Gato.Energia.Cantidad = Int32.Parse(partida.Split(new char[]{';','\n'})[(int)datos.ENERGIA]);
            escenarioPrincipal.Gato.Energia.Tiempo = DateTime.Parse(partida.Split(new char[]{';','\n'})[(int)datos.TIEMPOENERGIA]);
            escenarioPrincipal.Gato.Hambre.Cantidad = Int32.Parse(partida.Split(new char[]{';','\n'})[(int)datos.HAMBRE]);
            escenarioPrincipal.Gato.Hambre.Tiempo = DateTime.Parse(partida.Split(new char[]{';','\n'})[(int)datos.TIEMPOHAMBRE]);
            escenarioPrincipal.Gato.Oro = Int32.Parse(partida.Split(new char[]{';','\n'})[(int)datos.ORO]);
            escenarioPrincipal.Gato.Durmiendo = Boolean.Parse(partida.Split(new char[]{';','\n'})[(int)datos.DURMIENDO]);
            escenarioPrincipal.Gato.Vivo = Boolean.Parse(partida.Split(new char[]{';','\n'})[(int)datos.VIVO]);
            inicioPartida = DateTime.Parse(partida.Split(new char[]{';','\n'})[(int)datos.INICIOPARTIDA]);
            escenarioPrincipal.Gato.Hambre.Precio = precio + precio*(int) DateTime.Now.Subtract(inicioPartida).TotalDays;
        }

        private void SaveAndExit(){
            using (StreamWriter sw = File.CreateText("partida.txt"))
            {
                sw.WriteLine("Energia;"+ escenarioPrincipal.Gato.Energia.Cantidad);
                sw.WriteLine(escenarioPrincipal.Gato.Energia.Tiempo);
                sw.WriteLine("Hambre;"+ escenarioPrincipal.Gato.Hambre.Cantidad);
                sw.WriteLine(escenarioPrincipal.Gato.Hambre.Tiempo);
                sw.WriteLine("Oro;"+ escenarioPrincipal.Gato.Oro);
                sw.WriteLine("Durmiendo;"+ escenarioPrincipal.Gato.Durmiendo);
                sw.WriteLine("Vivo;"+ escenarioPrincipal.Gato.Vivo);
                sw.WriteLine(inicioPartida);
            }
            Exit();
        }
        protected override void Update(GameTime gameTime)
        {
            escenarioPrincipal.Update(Content);
            if(escenarioPrincipal.Mensaje.Salir)
                SaveAndExit();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            escenarioPrincipal.Draw(_spriteBatch);
            if(!escenarioPrincipal.getJugar())
                _spriteBatch.DrawString(escenarioPrincipal.Fuente, "Dias: " + (int) DateTime.Now.Subtract(inicioPartida).TotalDays, 
                    new Vector2(20, 400), Color.DarkGoldenrod);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
