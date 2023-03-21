using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tamagochi_Idle
{
    internal class CanyaJuego:IconoMinijuego
    {
        public CanyaJuego()
        {
            posicion = new Vector2(780, 20);
        }
        public override void LoadContent(ContentManager content)
        {
            normal = content.Load<Texture2D>("canya");
            seleccionado = content.Load<Texture2D>("canyaBrillo");
        }
    }
}
