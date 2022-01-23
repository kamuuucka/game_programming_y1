using System;
using TiledMapParser;

namespace GXPEngine
{
    internal class Level : GameObject
    {
        TiledLoader loader;

        public Level(string filename)
        {

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
