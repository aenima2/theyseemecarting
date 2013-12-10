using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharSelect : MonoBehaviour { 

	public Color notSelectedColor; // Standard de-selected color

	[HideInInspector] // Variable invisible in inspector
	public float previousDpadAxisX; // Previous D-pad X-axis input
	[HideInInspector] // Variable invisible in inspector
	public float previousDpadAxisY; // Previous D-pad Y-axis input

	public int rows; // Set number of row for the matrix
	public int cols; // Set number of cols for the matrix
	
	public GameObject[] charPrefabs; // All the different character prefabs
	public GameObject[][] chars; // The game objects created to be showed on screen

	private bool startGameFailMsg = false; // Checks if all players have chosen a character

	[HideInInspector]
	public bool activateP2 = false;
	[HideInInspector]
	public bool activateP3 = false;
	[HideInInspector]
	public bool activateP4 = false;

	private Player player;
	private GameManager gm;
	

	void Start()
	{
		SpawnSelectableCharacters();
		//Cart cart = FindObjectOfType<Cart>();
		player = FindObjectOfType<Player>();
		gm = FindObjectOfType<GameManager>();

		//cart.cartCam.enabled = false;
	}
	
	void Update()
	{

	}

	void OnGUI()
	{
		// Checks which character is selected at the moment and display it in the window
		// Needs to be reworked due to problem with multiple players
		if(player != null)
		{
			GameObject selectedChar = charPrefabs[(int)(player.currentChar.x + cols * player.currentChar.y)];
			//Shows a label with the name of the selected character
			string labelChar = selectedChar.name;
			GUI.Label(new Rect((Screen.width - 100) / 2, 20, 100, 50), labelChar);
		}
		


		// Activate player 2 gui
		if(activateP2 == true)
		{
		Rect player2msg = new Rect(0.15f, 0.85f, 0.4f, 0.2f);
		GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
		GUI.Label (new Rect(NormalizeRect(player2msg)), "Player 2"); // Displays message
		}
		else
		{
		Rect activateP2msg = new Rect(0.15f, 0.85f, 0.4f, 0.2f);
		GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
		GUI.Label (new Rect(NormalizeRect(activateP2msg)), "Press start to join"); // Displays message
		}
		// Activate player 3 gui
		if(activateP3 == true)
		{
			Rect player2msg = new Rect(0.4f, 0.85f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(player2msg)), "Player 3"); // Displays message
		}
		else
		{
			Rect activateP2msg = new Rect(0.4f, 0.85f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(activateP2msg)), "Press start to join"); // Displays message
		}
		// Activate player 4 gui
		if(activateP4 == true)
		{
			Rect player2msg = new Rect(0.65f, 0.85f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(player2msg)), "Player 4"); // Displays message
		}
		else
		{
			Rect activateP2msg = new Rect(0.65f, 0.85f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(activateP2msg)), "Press start to join"); // Displays message
		}



		// All players must select a character Msg
		if(startGameFailMsg == true)
		{
			Rect playersMustSelect = new Rect(0.3f, 0.2f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(playersMustSelect)), "All players must select a character"); // Displays message
		}
	}

	void SpawnSelectableCharacters()
	{
		chars = new GameObject[rows][];
		
		//for (int i = 0; i < charPrefabs.Length; i++)
		//	Debug.Log("chars #" + i + "is: " + charPrefabs[i].name);
		
		for (int i=0; i < rows; i++)
		{
			chars[i] = new GameObject[rows];
			for (int j = 0; j < cols; j++)
			{
				chars[i][j] = (GameObject) Instantiate (charPrefabs[i * cols + j], new Vector2(i + i * 0.2f,j + j * 0.2f), Quaternion.identity);
			}
		}
	}

	/*
	 * void SetColor
	 * Highlights the selected color by comparing current character to the values of y and x
	 * 
	 */
	public void SetColor()
	{
		for (int i=0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				CharPrefab charP = chars[i][j].GetComponent<CharPrefab>(); // Get reference from CharPrefab script

				if (i == player.currentChar.x && j == player.currentChar.y)
				{
					charP.Select(player);
					if(chars[i][j].renderer.material.color == notSelectedColor) // If a player already highlighted a character, don't highlight again
						chars[i][j].renderer.material.color = player.playerCol;
				}
				else
				{
					charP.DeSelect(player);
					if(charP.players.Count < 1)
					{
						chars[i][j].renderer.material.color = notSelectedColor;
					}
				}
			}
		}
	}

	/*
	 * public void ScrollHorizontally
	 * Scrolls through objects in the rows by comparing the value of the previously selected char
	 * and adding/subtracting to it depending on if you press left or right.
	 * 
	 */
	public void ScrollHorizontally(Player p)
	{
		player = p;

		SetColor(); // Calls for SetColor function to add the highlight color to the current character

		player.previousDpadAxisX = Input.GetAxis ("DPADHor" + player.playerNumber); // Set the current D-pad X-axis as previous

		player.currentChar.x += (int)player.previousDpadAxisX;
		player.currentChar.x = Mathf.Clamp(player.currentChar.x, 0, rows - 1);
	}

	/*
	 * public void ScrollVertically
	 * Scrolls through objects in the cols by comparing the value of the previously selected char
	 * and adding/subtracting to it depending on if you press up or down.
	 * 
	 */
	public void ScrollVertically(Player p)
	{
		player = p;

		SetColor(); // Calls for SetColor function to add the highlight color to the current character

		previousDpadAxisY = Input.GetAxis ("DPADVert" + player.playerNumber); // Set the current D-pad Y-axis as previous

		player.currentChar.y += (int)previousDpadAxisY;
		player.currentChar.y = Mathf.Clamp(player.currentChar.y, 0, cols - 1);
	}
	
	/*
	 * public void SelectCharacter
	 * If player has selected, sets hasSelected bool to true
	 * 
	 */
	public void SelectCharacter(Player p)
	{

		player = p;

		player.hasSelected = true;
		for (int i=0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				if (i == player.currentChar.x && j == player.currentChar.y)
				{
					player.playerVehicle = chars[i][j].gameObject;
					DontDestroyOnLoad(player.playerVehicle);
				}
			}
		}
		//currentChar = player.possibleCharacters;
	}

	/*
	 * public void SelectCharacter
	 * If player de-selects a character, sets to hasSelected bool to false
	 * 
	 */
	public void DeSelectCharacter(Player p)
	{
		player = p;

		player.hasSelected = false;
	}

	/*
	 * public void TryStartGame
	 * Tries to start the game by checking if all players have chosen a character by comparing the hasSelected bools
	 * 
	 */
	public void TryStartGame()
	{
		bool startGame = true;

		for (int i = 0; i < gm.players.Count; i++)
		{
			if(gm.players[i].hasSelected == false)
				startGame = false;
		}

		if(startGame == true)
		{
			StartGame();
		}
		else
		{
			startGameFailMsg = true;
			StartCoroutine(Coroutine1(2f)); // Active 2 sec
		}
	}

	/*
	 * void StartGame
	 * Start game, loads next level and set player inMenu-controls to false
	 * 
	 */
	void StartGame()
	{
		Application.LoadLevel("testlevel");
		Player player = FindObjectOfType<Player>();
		player.inMenu = false;
		//Cart cart = FindObjectOfType<Cart>();
		//cart.cartCam.enabled = true;
		GameManager gm = FindObjectOfType<GameManager>();
		player.SpawnVehicle(gm.pn);
	}
	
	/*
	 * IEnumerator Coroutine1
	 * Adds wait time for the Start game fail message
	 * 
	 */
	IEnumerator Coroutine1(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		startGameFailMsg = false;
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
