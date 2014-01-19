using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public string mainMenuSceneName;
	public Font pauseMenuFont;

	private bool pauseEnabled = false;


	void Start()
	{
		Screen.showCursor = false; // Hide mouse cursor
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			// Check if game is already paused
			if(pauseEnabled != true)
			{
				PauseGame();
			}
			// If game already paused, unpause
			else
			{
				UnPauseGame();
			}
		}
	}


	private bool showOptionsMenu = false; //
	private bool showGraphicsMenu = false;

	void OnGUI()
	{
		GUI.skin.box.font = pauseMenuFont;
		GUI.skin.button.font = pauseMenuFont;

		if(pauseEnabled == true)
		{
			// Make a background box
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 200), "Pause Menu");
				

			//Make Resume button
			if(GUI.Button(new Rect(Screen.width / 2 - 100 , Screen.height / 2 - 50, 250, 50), "Resume"))
				UnPauseGame();

			//Make Options button
			if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 , 250, 50), "Options"))
			{
				if(showOptionsMenu != true)
					showOptionsMenu = true;
				else
					showOptionsMenu = false;
			}

			//Create the Graphics settings buttons, these won't show automatically, they will be called when
			//the user clicks on the "Change Graphics Quality" Button, and then dissapear when they click
			//on it again....
			if(showOptionsMenu == true)
			{
				if(GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height /2 ,250,50), "Sound"))
					print ("sound");

				if(GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height /2 + 50,250,50), "Graphics"))
				{
					{
						if(showGraphicsMenu != true)
							showGraphicsMenu = true;
						else
							showGraphicsMenu = false;
					}
				}

				if(GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height /2 + 100,250,50), "Tutorial"))
					print ("tutorial");

				if(Input.GetKeyDown(KeyCode.Escape))
					showOptionsMenu = false;
			}

			if(showGraphicsMenu == true){
				if(GUI.Button(new Rect(Screen.width / 2 + 400, Screen.height / 2 , 250, 50), "Fastest"))
					QualitySettings.currentLevel = QualityLevel.Fastest;

				if(GUI.Button(new Rect(Screen.width / 2 + 400, Screen.height / 2 + 50, 250, 50), "Fast"))
					QualitySettings.currentLevel = QualityLevel.Fast;

				if(GUI.Button(new Rect(Screen.width / 2 + 400, Screen.height / 2 + 100, 250, 50), "Simple"))
					QualitySettings.currentLevel = QualityLevel.Simple;

				if(GUI.Button(new Rect(Screen.width / 2 + 400, Screen.height / 2 + 150, 250, 50), "Good"))
					QualitySettings.currentLevel = QualityLevel.Good;

				if(GUI.Button(new Rect(Screen.width / 2 + 400, Screen.height / 2 + 200, 250, 50), "Beautiful"))
					QualitySettings.currentLevel = QualityLevel.Beautiful;

				if(GUI.Button(new Rect(Screen.width / 2 + 400, Screen.height / 2 + 250, 250, 50), "Fantastic"))
					QualitySettings.currentLevel = QualityLevel.Fantastic;
				
				if(Input.GetKeyDown("escape")){
					showGraphicsMenu = false;
				}
			}


			//Make Quit battle button
			if (GUI.Button(new Rect(Screen.width /2 - 100, Screen.height / 2 + 50, 250, 50), "Quit Battle"))
				Application.LoadLevel(mainMenuSceneName);
		}
	}


	public void PauseGame()
	{
		pauseEnabled = true;
		Time.timeScale = 0;
		AudioListener.volume = 0;
		Screen.showCursor = true;	
	}
	
	
	public void UnPauseGame()
	{
		pauseEnabled = false;
		Time.timeScale = 1;
		AudioListener.volume = 1;
		Screen.showCursor = false;	
	}
}
