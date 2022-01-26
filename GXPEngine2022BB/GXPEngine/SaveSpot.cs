using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

internal class SaveSpot : Sprite
{
    private bool isEnd = false;
    public SaveSpot(TiledObject obj = null) : base("wall1.png")
    {
        collider.isTrigger = true;
        Console.WriteLine("SaveSpot");
        isEnd = obj.GetBoolProperty("isEnd", false);
    }

    public bool GetIsEnd()
    {
        return isEnd;
    }
}
