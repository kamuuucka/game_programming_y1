using GXPEngine;

/// <summary>
/// Wall blocking the player. Makes sure that player can't go back and leave the game screen
/// </summary>

internal class Wall : Sprite
{ 
    private float mapHeight = 0;
    private Player playerToFollow;
    
    public Wall(Player player, float mapHeight) : base("wall1.png")
    {
        playerToFollow = player;
        this.mapHeight = mapHeight;
        WallRespawn();
        collider.isTrigger = true;
    }

    /// <summary>
    /// Wall stays always at the bottom of the screen.
    /// Allows player to move down few lines down the screen before blocking him.
    /// </summary>
    private void FollowPlayer()
    {
        if (Input.GetKeyUp(Key.W))
        {
            if (y > playerToFollow.y + 180)
            {
                Move(0, -64f);
            }
        }
    }
    /// <summary>
    /// Makes sure, that the wall respawns at the bottom of the screen
    /// </summary>
    public void WallRespawn()
    {
        SetXY(0, mapHeight);
    }

    void Update()
    {       
        FollowPlayer();
        if (playerToFollow.isDead)
        {
            WallRespawn();
        }
    }

    
}
