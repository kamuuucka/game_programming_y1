using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    internal class Tile : Sprite
    {
        public Tile() : base("colors.png")
        {
            DrawTile();
        }

        private void DrawTile()
        {
            this.width = 64;
            this.height = 64;
        }
    }
}
