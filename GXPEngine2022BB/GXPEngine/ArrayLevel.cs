using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    internal class ArrayLevel : GameObject
    {
        const int TILE = 1;
        const int PLAYER = 2;
        //TODO: enemy, coin, moving platform, etc

        int[,,] levels =
        {
            //Level 1
            {
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,1,1,1,1,2,1,1,1,1,1,1 }
            },

            //Level 2
            {
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,0,0,0,0 },
                {1,1,1,1,1,2,1,1,1,1,1,1 }
            }

        };

        public ArrayLevel(int index)       //index is the number of item on the tile grid
        {
            int tileSize = 64;
            Player player = null;
            for (int row = 0; row < levels.GetLength(1); row++)
            {
                for (int col = 0; col < levels.GetLength(2); col++)
                {
                    int tileType = levels[index, row, col];
                    switch (tileType)
                    {
                        case TILE:
                            Tile tile = new Tile();
                            tile.x = col * tileSize;
                            tile.y = row * tileSize;
                            AddChild(tile);
                            break;
                        case PLAYER:
                            player = new Player();
                            player.x = col * tileSize + tileSize / 2;
                            player.y = row * tileSize + tileSize / 2;
                            AddChild(player);
                            break;
                    }
                }
            }
        }
    }
}
