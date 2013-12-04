using UnityEngine;
using System.Collections;

public class DelegateMenu : MonoBehaviour {

	private delegate void MenuDelegate();
	private MenuDelegate menuFunction;

	private GameManager gameManager;

	void Start ()
	{
		gameManager = FindObjectOfType<GameManager>();
		menuFunction = TitleScreen;
	}


	void OnGUI()
	{
		menuFunction();
	}


	/*
	 * void TitleScreen
	 * If any button is pressed down, instantiates the Main Menu by setting the Menu delegate to MainMenu instead
	 * 
	 */
	void TitleScreen()
	{
		if(Input.anyKeyDown)
		{
			menuFunction = MainMenu;
		}

		Rect pressAnyKey = new Rect(0.3f, 0.2f, 0.4f, 0.2f);

		GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
		GUI.Label (new Rect(NormalizeRect(pressAnyKey)), "Press any key to continue"); // Displays message
	}

	/*
	 * void MainMenu
	 * Uses the GUI-function to draw to buttons, one to move on to Number of player selection, the other to quit
	 * 
	 */
	void MainMenu()
	{
		Rect battleButton = new Rect(0.3f, 0.2f, 0.4f, 0.2f);
		Rect quitButton = new Rect(0.3f, 0.5f, 0.4f, 0.2f);

		if(GUI.Button(new Rect(NormalizeRect(battleButton)), "Battle"))
		{
			menuFunction = GameSelect;
		}

		if(GUI.Button(new Rect(NormalizeRect(quitButton)), "Quit"))
		{
			Application.Quit();
		}
	}


	/*
	 * void GameSelect
	 * Sends information to the GameManager of the number of players, by calling the static float with the same name
	 * 
	 */
	void GameSelect()
	{

		Rect msg = new Rect(0.32f, 0.1f, 0.4f, 0.1f);
		Rect p2 = new Rect(0.42f, 0.4f, 0.2f, 0.05f);
		Rect p3 = new Rect(0.42f, 0.47f, 0.2f, 0.05f);
		Rect p4 = new Rect(0.42f, 0.54f, 0.2f, 0.05f);

		GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
		GUI.Label(NormalizeRect(msg), "Choose number of Players");
		
		if(GUI.Button(NormalizeRect(p2), "2 players"))
		{
			gameManager.numberOfPlayers = 2;
			gameManager.CreatePlayers();// <-- enable player input
			menuFunction = CharacterSelect;
		}
		
		if(GUI.Button(NormalizeRect(p3), "3 players"))
		{
			gameManager.numberOfPlayers = 3;
			menuFunction = CharacterSelect;
		}
		
		if(GUI.Button(NormalizeRect(p4), "4 players"))
		{
			gameManager.numberOfPlayers = 4;
			menuFunction = CharacterSelect;
		}
	}

	void CharacterSelect()
	{
		Rect msg = new Rect(0.32f, 0.1f, 0.4f, 0.1f);
		Rect p2 = new Rect(0.42f, 0.5f, 0.2f, 0.05f);
		Rect p3 = new Rect(0.42f, 0.57f, 0.2f, 0.05f);
		Rect p4 = new Rect(0.42f, 0.64f, 0.2f, 0.05f);
		
		GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
		GUI.Label(NormalizeRect(msg), "Choose number of Players");
		
		if(GUI.Button(NormalizeRect(p2), "2 players"))
		{
			//player.characterIndex = 0;
			Application.LoadLevel("testlevel");
		}
		
		if(GUI.Button(NormalizeRect(p3), "3 players"))
		{
			//player.characterIndex = 1;
			Application.LoadLevel("testlevel");
		}
		
		if(GUI.Button(NormalizeRect(p4), "4 players"))
		{
			//player.characterIndex = 2;
			Application.LoadLevel("testlevel");
		}
	}


	/*
	 * private Rect NormalizeRect
	 * Normalizes the Rect in GUI so it stays on screen even when screen width and height changes
	 * 
	 */
	private Rect NormalizeRect(Rect r)
	{
		r.x *= Screen.width;		
		r.y *= Screen.height;
		
		r.width *= Screen.width;
		r.height *= Screen.height;
		
		return r;
	}

}
