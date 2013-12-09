using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharSelect : MonoBehaviour { 

	public Color selectedColor; // Selected highlight color
	public Color notSelectedColor; // Standard de-selected color

	[System.NonSerialized] // Variable invisible in inspector
	public float previousDpadAxisX; // Previous D-pad X-axis input
	[System.NonSerialized] // Variable invisible in inspector
	public float previousDpadAxisY; // Previous D-pad Y-axis input

	public int rows; // Set number of row for the matrix
	public int cols; // Set number of cols for the matrix
	
	public GameObject[] charsPrefabs; // All the different character prefabs
	public GameObject[][] chars; // The game objects created to be showed on screen
	[System.NonSerialized] // Variable invisible in inspector
	public Vector2 currentChar = Vector2.zero; // The index of the current character

	[System.NonSerialized] // Don't display in inspector
	public bool hasSelected = false; // For if player has selected a character

	private bool startGameFailMsg = false; // Checks if all players have chosen a character

	//private Player player;


	void Start()
	{
		SpawnSelectableCharacters();
		Cart cart = FindObjectOfType<Cart>();
		cart.cartCam.enabled = false;
		chars[(int)currentChar.x][(int)currentChar.y].renderer.material.color = selectedColor; // Highlight the first character at start

		Player player = FindObjectOfType<Player>();
		player.inMenu = true;
	}
	
	void Update()
	{
		/*if(Input.GetButtonDown("Select1"))
		{
			SelectCharacter();
		}*/

		/*if(Input.GetButtonDown("DeSelect1"))
		{
			DeSelectCharacter();
		}*/

		/*if(hasSelected == false)
		{
			if(Input.GetAxis ("DPADHor1") != previousDpadAxisX)
			{
				ScrollHorizontally();
			}
			if(Input.GetAxis ("DPADVert1") != previousDpadAxisY)
			{
				ScrollVertically();
			}
		}*/

		/*if(Input.GetButtonDown("StartAll"))
		{
			TryStartGame();
		}*/
	}

	void OnGUI() {
		GameObject selectedChar = charsPrefabs[(int)(currentChar.x + cols * currentChar.y)];
		
		//Shows a label with the name of the selected character
		string labelChar = selectedChar.name;
		GUI.Label(new Rect((Screen.width - 100) / 2, 20, 100, 50), labelChar);


		// All players must select a character Msg
		if(startGameFailMsg == true)
		{
			Rect playersMustSelect = new Rect(0.3f, 0.2f, 0.4f, 0.2f);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter; // Centralizes the text
			GUI.Label (new Rect(NormalizeRect(playersMustSelect)), "All players must select a character"); // Displays message
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
				if (i == currentChar.x && j == currentChar.y)
				{
					chars[i][j].renderer.material.color = selectedColor;
				}
				else
				{
					chars[i][j].renderer.material.color = notSelectedColor;
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
	public void ScrollHorizontally()
	{
		SetColor(); // Calls for SetColor function to add the highlight color to the current character

		previousDpadAxisX = Input.GetAxis ("DPADHor1"); // Set the current D-pad X-axis as previous

		currentChar.x += (int)previousDpadAxisX;
		currentChar.x = Mathf.Clamp(currentChar.x, 0, rows - 1);
	}

	/*
	 * public void ScrollVertically
	 * Scrolls through objects in the cols by comparing the value of the previously selected char
	 * and adding/subtracting to it depending on if you press up or down.
	 * 
	 */
	public void ScrollVertically()
	{
		SetColor(); // Calls for SetColor function to add the highlight color to the current character

		previousDpadAxisY = Input.GetAxis ("DPADVert1"); // Set the current D-pad Y-axis as previous

		currentChar.y += (int)previousDpadAxisY;
		currentChar.y = Mathf.Clamp(currentChar.y, 0, cols - 1);
	}


	void SpawnSelectableCharacters()
	{
		chars = new GameObject[rows][];

		//for (int i = 0; i < charsPrefabs.Length; i++)
		//	Debug.Log("chars #" + i + "is: " + charsPrefabs[i].name);

		for (int i=0; i < rows; i++)
		{
			chars[i] = new GameObject[rows];
			for (int j = 0; j < cols; j++)
			{
				chars[i][j] = (GameObject) Instantiate (charsPrefabs[i * cols + j], new Vector2(i + i * 0.2f,j + j * 0.2f), Quaternion.identity);
			}
		}
	}

	/*
	 * public void SelectCharacter
	 * If player has selected, sets hasSelected bool to true
	 * 
	 */
	public void SelectCharacter()
	{
		hasSelected = true;

		Player player = FindObjectOfType<Player>();

		for (int i=0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				if (i == currentChar.x && j == currentChar.y)
				{
					player.playerCharacter = chars[i][j].gameObject;
					DontDestroyOnLoad(player.playerCharacter);
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
	public void DeSelectCharacter()
	{
		hasSelected = false;
	}

	/*
	 * public void TryStartGame
	 * Tries to start the game by checking if all players have chosen a character by comparing the hasSelected bools
	 * 
	 */
	public void TryStartGame()
	{
		if(hasSelected == true)
		{
			StartGame();
		}
		else
		{
			if(startGameFailMsg)
			{
				startGameFailMsg = false;
			}
			else
			{
				startGameFailMsg = true;
				StartCoroutine(Coroutine1(2f)); // Active 2 sec
			}
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
		Cart cart = FindObjectOfType<Cart>();
		cart.cartCam.enabled = true;
		//GameManager gm = FindObjectOfType<GameManager>();
		//player.SpawnCart(gm.pn);
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
