using System;
using TiledMapParser;

/// <summary>
/// Create level from Tiled
/// </summary>
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
            loader.LoadImageLayers();
            loader.LoadTileLayers();
            loader.LoadObjectGroups();
        }
    }
}
