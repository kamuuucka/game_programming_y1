using GXPEngine;
using TiledMapParser;


internal class MovingObject : Sprite
{
    //private bool goesLeft;
    private bool isLeft = true;
    private float startX;
    private float speed;

    public MovingObject(string sprite, float speed) : base(sprite)
    {
        this.speed = speed;
        ObjectSpawn();
        //goesLeft = obj.GetBoolProperty("goesLeft", true);
    }

    protected bool goesLeft(bool goesLeft)
    {
        isLeft = goesLeft;
        return isLeft;
    }

    private void ObjectSpawn()
    {
        if (isLeft)
        {
            startX = 905f;
        }
        else
        {
            startX = -128f;
            Mirror(true, false);
        }
    }
    protected void ObjectMovement()
    {
        if (isLeft)
        {
            Move(-speed, 0);

            if (x < 0 - width)
            {
                x = startX;
            }
        }
        else
        {
            Move(speed, 0);
            if (x > 777 + width)
            {
                x = startX;
            }
        }
    }

    void Update()
    {
    
    }
}

