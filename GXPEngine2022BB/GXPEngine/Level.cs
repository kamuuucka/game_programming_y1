using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace GXPEngine
{
    internal class Level : GameObject
    {
        Player player;
        TiledLoader loader;
        string currentLevelName;

        bool respawn = false; //used for smart respawn

        public Level(string filename)
        {
            Console.WriteLine("Creating new level " + filename);
            currentLevelName = filename; //Basic respawning

            loader = new TiledLoader(filename);

            CreateLevel();
        }

        private void CreateLevel(bool includeImageLayers = true)
        {
            Console.WriteLine("Spawning level elements");

            loader.LoadImageLayers();
            loader.LoadTileLayers();
            loader.LoadObjectGroups();
        }
    }
}
