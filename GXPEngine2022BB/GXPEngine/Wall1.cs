using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

internal class Wall1 : Player
{
    Player player;
    public Wall1(TiledObject obj) : base(obj)
    {
        this.x = player.x + 64;
    }
}
