using System;
using Microsoft.Xna.Framework.Input;
using System.IO;


namespace Tamagochi_Idle.Escenario_Principal
{
    internal class EscenarioPrincipalManager
    {
        //propiedad que toma el tiempo del sistema
        public TimeSpan Tiempo { get; set; }

        public EscenarioPrincipalManager()
        {
            //Cargar el tiempo del archivo y transformarlo en un TimeSpan
            string path = "Tiempo.txt";
            string tiempo = File.ReadAllText(path);
            Tiempo = TimeSpan.Parse(tiempo);
        }
        public void Update(CanyaJuego canya, Gato gato, MensajeSalir mensaje, ref bool jugar)
        {
            jugar = false;
            if(canya.CursorDentro && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                //Si el cursor esta dentro de la canya y se presiona el boton izquierdo del mouse
                gato.Energia.Cantidad--;
                jugar = true;
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                //Muestra el mensaje para poder salir
                mensaje.Mostrar = true;
            }
            if (mensaje.Salir)
            {
                GuardarYSalir(gato);
            }
        }
        public void GuardarYSalir(Gato gato)
        {
            //Tomar el tiempo del sistema y guardarlo en un archivo
            Tiempo = DateTime.Now.TimeOfDay;
            string path = "Tiempo.txt";
            File.WriteAllText(path, Tiempo.ToString());
            
            //Guardar la energia del gato en un archivo
            path = "Energia.txt";
            File.WriteAllText(path, gato.Energia.Cantidad.ToString());

            Environment.Exit(0);
        }
    }
}
