using Microsoft.Xna.Framework.Input;
using System;

namespace Tamagochi_Idle.Escenario_Principal
{
    internal class EscenarioPrincipalManager
    {
        private bool keyAvailable;
        public void Update(CanyaJuego canya, Gato gato, MensajeSalir mensaje, ref bool jugar)
        {
            jugar = false;

            if(Mouse.GetState().LeftButton == ButtonState.Released)
            {
                keyAvailable = true;
            }

            Jugar(canya, gato, ref jugar);

            Alimentar(gato);

            Acostar(gato);
            
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                //Muestra el mensaje para poder salir
                mensaje.Mostrar = true;
            }
        }

        private void Jugar(CanyaJuego canya, Gato gato, ref bool jugar)
        {
            if(canya.CursorDentro && Mouse.GetState().LeftButton == ButtonState.Pressed 
                && gato.Energia.Cantidad > 0 && !gato.Durmiendo)
            {
                //Si el cursor esta dentro de la canya y se presiona el boton izquierdo del mouse
                gato.Energia.Cantidad--;
                if(gato.Hambre.Cantidad < gato.Hambre.getLimiteCantidad())
                {
                    gato.Hambre.Cantidad++;
                }
                jugar = true;
            }
        }

        private void Alimentar(Gato gato)
        {
            if(gato.Hambre.CursorDentro && gato.Oro >= gato.Hambre.Precio && gato.Hambre.Cantidad > 0
                && Mouse.GetState().LeftButton == ButtonState.Pressed && !gato.Durmiendo && keyAvailable)
            {
                keyAvailable = false;
                gato.Hambre.Hambruna = 0;
                gato.Hambre.Cantidad--;
                gato.Hambre.Tiempo = DateTime.Now;
                gato.Oro -= gato.Hambre.Precio;
            }

        }

        private void Acostar(Gato gato)
        {
            if(gato.Energia.Cantidad < gato.Energia.getLimiteCantidad() && gato.Energia.CursorDentro 
                && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    gato.Durmiendo = true;
                    gato.Energia.Tiempo = DateTime.Now;
                }
        }
    }
}
