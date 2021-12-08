using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;							// System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game
{
    private EasyDraw background;
	private EasyDraw floor;
	private AnimationSprite player;

	private float speed = 5f;
	public MyGame() : base(800, 600, false)		// Create a window that's 800x600 and NOT fullscreen
	{
		// Draw some things on a canvas:
		//EasyDraw canvas = new EasyDraw(800, 600);
		//canvas.Clear(Color.MediumPurple);
		//canvas.Fill(Color.Yellow);
		//canvas.Ellipse(width / 2, height / 2, 200, 200);
		//canvas.Fill(50);
		//canvas.TextSize(32);
		//canvas.TextAlign(CenterMode.Center, CenterMode.Center);
		//canvas.Text("Welcome!", width / 2, height / 2);

		// Add the canvas to the engine to display it:
		//AddChild(canvas);
		//Console.WriteLine("MyGame initialized");

		background = new EasyDraw(width, height);
		background.Clear(Color.DarkCyan);
		background.Fill(Color.DarkCyan);

		floor = new EasyDraw(width, 80);
		floor.Clear(Color.DarkGreen);
		floor.Fill(Color.DarkGreen);
		floor.SetXY(0, height - 80);

		player = new AnimationSprite("dog_sheet.png", 6,2);
		player.SetXY(width / 2, height - 150);
		player.SetScaleXY(1.5f, 1.5f);

		AddChild(background);
		AddChild(floor);
		AddChild(player);
	}

	private void CharacterMovement()
    {
		bool isMoving = false;

		if (Input.GetKey(Key.A))
		{
			player.Move(-speed, 0);
			player.Mirror(true, false);
			isMoving = true;
		}
		else if (Input.GetKey(Key.D))
        {
			player.Move(speed, 0);
			player.Mirror(false, false);
			isMoving = true;
        }
        else
        {
			isMoving = false;
        }

		if (isMoving)
        {
			player.SetCycle(0, 5);
        }
        else
        {
			player.SetCycle(6, 4);
        }

		player.Animate(0.1f);


	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		CharacterMovement();
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}