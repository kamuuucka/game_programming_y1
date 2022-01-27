using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Collections.Generic;				//Needed to use the List

public class MyGame : Game
{
	private string startLevel = "menu.tmx";
	private EasyDraw healthUI;
	private EasyDraw pointUI;
	private SoundChannel soundTrackGame;

	public MyGame() : base(768,768, false, false, 768, 768,true)		// Create a window that's 768x768, NOT fullscreen, with pixel art enabled
	{
		LoadLevel(startLevel);
	}

	void Update()
	{
		if (Input.GetKeyDown(Key.R))
		{
			Console.WriteLine("RELOADING");
            LoadLevel(startLevel);
		}
	}

	static void Main()
	{
		new MyGame().Start();
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														Creating of the UI
	//------------------------------------------------------------------------------------------------------------------------

	private void CreateUI()
    {
		healthUI = new EasyDraw(100, 20, false);
		pointUI = new EasyDraw(100, 20, false);
		healthUI.SetXY(0, height - 748);
		pointUI.SetXY(width - 100, height - 748);

		LateAddChild(healthUI);
		LateAddChild(pointUI);
    }

	public void ShowHealth(int health)
    {
		if (healthUI != null)
        {
			healthUI.Text("Health: " + health, true);
		}

	}

	public void ShowPoints(int points)
    {
		if(pointUI != null)
        {
			pointUI.Text("Points: " + points, true);
        }
    }

	//------------------------------------------------------------------------------------------------------------------------
	//														Setting Music
	//------------------------------------------------------------------------------------------------------------------------

	private void PlayMusic(string music)
	{
		soundTrackGame = new Sound(music, true, true).Play();
		soundTrackGame.Volume = 0.5f;
	}

	public void StopMusic()
    {
		soundTrackGame.Stop();
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														Level Management
	//------------------------------------------------------------------------------------------------------------------------
	private void DestroyAll()
	{
		List<GameObject> children = GetChildren();
		foreach (GameObject child in children)
		{
			child.LateDestroy();
		}
	}
	public void LoadLevel(string filename)
	{
		if (filename != null)
		{
			DestroyAll();
			LateAddChild(new LevelManager(filename));
			CreateUI();

            if (filename.Contains("map"))
            {
                PlayMusic("background.wav");
            }
            else
            {
                PlayMusic("menu_background.wav");
                if (healthUI != null && pointUI != null)
                {
                    healthUI.LateDestroy();
                    pointUI.SetXY(width / 2 - 70, height / 2 - 56);
					pointUI.SetScaleXY(2, 2);
                }
            }
        }
	}
}