using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;							// System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game
{
    private Sprite background;
	private Player player;
	private Enemy[] enemies = new Enemy[5];
	public MyGame() : base(768, 768, false)		// Create a window that's 800x600 and NOT fullscreen
	{

		background = new Sprite("background.png");
		background.SetXY(0, 0);

		player = new Player(768,768);

		for (int i = 0; i < enemies.Length; i++)
        {
			enemies[i] = new Enemy(player, 770 + (150 * i), 256);
			Console.WriteLine("ENEMY " + i + ": " + (770 + (150 * i)) + ":" + 256);
        }

		AddChild(background);
		AddChild(player);
		for(int i = 0;i < enemies.Length; i++)
        {
			AddChild(enemies[i]);
			Console.WriteLine(enemies[i] + " added");
        }
	}

	

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		player.CharacterMovement();
		for(int i = 0;i < enemies.Length; i++)
        {
			enemies[i].EnemyMovement();
        }
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}