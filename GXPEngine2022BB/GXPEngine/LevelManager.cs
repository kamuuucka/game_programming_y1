using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace GXPEngine
{
    internal class LevelManager : GameObject
    {
        Player player;
        TiledLoader loader;
        string currentLevelName;

        public LevelManager(string filename)
        {
            Console.WriteLine("Creating new level object");
            currentLevelName = filename;
            loader = new TiledLoader(filename);

            CreateLevel();
        }
        private void CreateLevel(bool includeImageLayers = true)
        {
            Console.WriteLine("Spawning level objects");
        }
    }
}
