using System;
using GXPEngine;

//Wall that is following the player, so he can't go back too much and escape from the screen

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

    //Wall is following the player with each step
    private void FollowPlayer()
    {
        if (Input.GetKeyUp(Key.W))
        {
            //If walls Y is higher than players Y + 180 it will move higher. Otherwise it will stay at the bottom of the scene.
            //This stops the wall from going right after the player and allows him to move back on the screen.
            if (y > playerToFollow.y + 180)  //+ 116 if you want to make the wall higher and visible
            {
                Move(0, -64f);
            }
        }
    }

    //Makes sure, that wall respawns on the bottom of the screen
    public void WallRespawn()
    {
        //SetXY(0, mapHeight - 64); //This allows to make the wall visible and one block higher
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
