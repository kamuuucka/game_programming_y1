using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;

public class MyGame : Game
{
	//string startLevel = "map_demo1.tmx";
	string startLevel = 
		"map1.tmx";
		//"menu.tmx";
	string nextLevel = null;
	EasyDraw healthUI;


	public MyGame() : base(768,768, false, false, 768, 768,true)		// Create a window that's 768x768, NOT fullscreen, with pixel art enabled
	{

		LoadLevel(startLevel);
	
		
	}

	private void CreateUI()
    {
		healthUI = new EasyDraw(100, 20, false);
		healthUI.SetXY(0, height - 748);

		LateAddChild(healthUI);
    }

	public void ShowHealth(int health)
    {
		if (healthUI != null)
        {
			Console.WriteLine(" HEALTH: " + health);
			healthUI.Text("Health: " + health, true);
		}

	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{

        //Hot reload
        if (Input.GetKeyDown(Key.R))
        {
			Console.WriteLine("RELOADING");
			LoadLevel(startLevel);
        }

	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}

	void DestroyAll()
    {
		List<GameObject> children = GetChildren();
		foreach (GameObject child in children)
        {
			child.LateDestroy();
        }
    }

	public void LoadLevel(string filename)
    {
		DestroyAll();
		LateAddChild(new LevelManager(filename));
		CreateUI();
    }
}