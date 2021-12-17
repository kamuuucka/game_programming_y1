using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    internal class Pickup : Sprite
    {
        public Pickup() : base("circle.png")
        {
            this.width = 32;
            this.height = 32;
            SetOrigin(this.width/ 2, this.height/2);   
            collider.isTrigger = true;
        }

        public void Grab()
        {
            LateDestroy();
            x -= 1000;
        }
    }
}
