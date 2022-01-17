using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

internal class SaveSpot : Sprite
{
    public SaveSpot(TiledObject obj = null) : base("wall.png")
    {
        collider.isTrigger = true;
        Console.WriteLine("SaveSpot");
    }
}
