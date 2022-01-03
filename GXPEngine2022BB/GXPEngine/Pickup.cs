using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;


    internal class Pickup : Sprite
    {
        public Pickup(TiledObject obj = null) : base("circle.png")
        {
            this.width = 32;
            this.height = 32;
            SetOrigin(this.width/ 2, this.height/2);   
            collider.isTrigger = true;
            Console.WriteLine("Coin spawned");
        }

        public void Grab()
        {
            LateDestroy();
            x -= 1000;
        }

    }

