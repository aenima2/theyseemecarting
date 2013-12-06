using UnityEngine;
using System.Collections;

public class DelegateMenuCopy : MonoBehaviour {

	private delegate void MenuDelegate();
	private MenuDelegate menuFunction;

	private GameManagerCopy gameManager;
	private Player player;

	// For GUI control
	public GUISkin skin;
	private int selection = 1;
	private int selectionMax = 4;
	


	void Start ()
	{
		gameManager = FindObjectOfType<GameManagerCopy>();
		player = FindObjectOfType<Player>();
		menuFunction = TitleScreen;
	}

	void Update()
	{
		//PlayerControl();
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
		Screen.showCursor = false;

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
		Rect p1 = new Rect(0.42f, 0.33f, 0.2f, 0.05f);
		Rect p2 = new Rect(0.42f, 0.4f, 0.2f, 0.05f);
		Rect p3 = new Rect(0.42f, 0.47f, 0.2f, 0.05f);
		Rect p4 = new Rect(0.42f, 0.54f, 0.2f, 0.05f);

		GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
		GUI.Label(NormalizeRect(msg), "Choose number of Players");

		if(GUI.Button(NormalizeRect(p1), "1 players"))
		{
			gameManager.SetNumberOfPlayers(1);
			gameManager.CreatePlayers();// <-- enable player input
			Application.LoadLevel("characterSelectNewCopy");
			//menuFunction = CharacterSelect;
		}
		
		if(GUI.Button(NormalizeRect(p2), "2 players"))
		{
			gameManager.SetNumberOfPlayers(2);
			gameManager.CreatePlayers();// <-- enable player input
			Application.LoadLevel("characterSelectNewCopy");
			//menuFunction = CharacterSelect;
		}
		
		if(GUI.Button(NormalizeRect(p3), "3 players"))
		{
			gameManager.SetNumberOfPlayers(3);
			gameManager.CreatePlayers();// <-- enable player input
			Application.LoadLevel("characterSelectNewCopy");
			//menuFunction = CharacterSelect;
		}
		
		if(GUI.Button(NormalizeRect(p4), "4 players"))
		{
			gameManager.SetNumberOfPlayers(4);
			gameManager.CreatePlayers();// <-- enable player input
			Application.LoadLevel("characterSelectNewCopy");
			//menuFunction = CharacterSelect;
		}
	}

	void CharacterSelect()
	{
		Rect msg = new Rect(0.32f, 0.1f, 0.4f, 0.1f);
		Rect p1 = new Rect(0.42f, 0.43f, 0.2f, 0.05f);
		Rect p2 = new Rect(0.42f, 0.5f, 0.2f, 0.05f);
		Rect p3 = new Rect(0.42f, 0.57f, 0.2f, 0.05f);
		Rect p4 = new Rect(0.42f, 0.64f, 0.2f, 0.05f);

		
		GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
		GUI.Label(NormalizeRect(msg), "Select you character");

		if(selection == 1)
		{
			// GUI color(
			GUI.Label(NormalizeRect(p1), "Cube<-");
			GUI.Label(NormalizeRect(p2), "Capsule");
			GUI.Label(NormalizeRect(p3), "Cylinder");
			GUI.Label(NormalizeRect(p4), "Sphere");
		}

		if(selection == 2)
		{
			// GUI color(
			GUI.Label(NormalizeRect(p1), "Cube");
			GUI.Label(NormalizeRect(p2), "Capsule<-");
			GUI.Label(NormalizeRect(p3), "Cylinder");
			GUI.Label(NormalizeRect(p4), "Sphere");
		}

		if(selection == 3)
		{
			// GUI color(
			GUI.Label(NormalizeRect(p1), "Cube");
			GUI.Label(NormalizeRect(p2), "Capsule");
			GUI.Label(NormalizeRect(p3), "Cylinder<-");
			GUI.Label(NormalizeRect(p4), "Sphere");
		}

		if(selection == 4)
		{
			// GUI color(
			GUI.Label(NormalizeRect(p1), "Cube");
			GUI.Label(NormalizeRect(p2), "Capsule");
			GUI.Label(NormalizeRect(p3), "Cylinder");
			GUI.Label(NormalizeRect(p4), "Sphere<-");
		}

		/*
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

		if(GUI.Button(NormalizeRect(p4), "4 players"))
		{
			//player.characterIndex = 2;
			Application.LoadLevel("testlevel");
		}*/
	}


	void PlayerControl()
	{
		if(Input.GetKeyDown(KeyCode.S))
		{
			selection += 1;
		}
		
		if(Input.GetKeyDown(KeyCode.W))
		{
			selection -= 1;
		}
		
		selection = Mathf.Clamp(selection, 1, selectionMax);
	}

	public void MenuUp()
	{
		selection -= 1;

		selection = Mathf.Clamp(selection, 1, selectionMax);
	}
	
	public void MenuDown()
	{
		selection += 1;

		selection = Mathf.Clamp(selection, 1, selectionMax);
	}

	public void MenuSelect()
	{
		if(selection == 1)
		{ 
			player.characterIndex = 0;
			//player.SpawnCart();
			print (player.characterIndex);
			Application.LoadLevel("testlevel");
		}
		if(selection == 2)
		{ 
			player.characterIndex = 1;
			print (player.characterIndex);
			Application.LoadLevel("testlevel");
		}
		if(selection == 3)
		{ 
			player.characterIndex = 2;
			print (player.characterIndex);
			Application.LoadLevel("testlevel");
		}
		if(selection == 4)
		{ 
			player.characterIndex = 3;
			print (player.characterIndex);
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

	void Test()
	{

	}

}
