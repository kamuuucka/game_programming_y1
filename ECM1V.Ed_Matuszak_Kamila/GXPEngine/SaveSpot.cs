using System;
using GXPEngine;
using TiledMapParser;

/// <summary>
/// Repostioning player. Makes sure, that after player jumps off the log, he will stay in the grid
/// When marked as isEnd it means that save spot is now a finish line
/// </summary>
internal class SaveSpot : Sprite
{
    private bool isEnd = false;
    public SaveSpot(TiledObject obj = null) : base("wall1.png")
    {
        if (obj != null)
        {
            collider.isTrigger = true;
            isEnd = obj.GetBoolProperty("isEnd", false);
        }
    }

    public bool GetIsEnd()
    {
        return isEnd;
    }
}
