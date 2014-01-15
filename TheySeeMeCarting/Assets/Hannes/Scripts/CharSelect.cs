using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharSelect : MonoBehaviour { 

	public Material notSelectedMat;

	[HideInInspector] // Variable invisible in inspector
	public float previousDpadAxisX; // Previous D-pad X-axis input
	[HideInInspector] // Variable invisible in inspector
	public float previousDpadAxisY; // Previous D-pad Y-axis input

	public int rows; // Set number of row for the matrix
	public int cols; // Set number of cols for the matrix
	
	public GameObject[] charPrefabs; // All the different character prefabs
	//[HideInInspector]
	//public int charPrefabIndex;
	public GameObject[][] chars; // The game objects created to be showed on screen

	[HideInInspector]
	public bool activateP2 = false;
	[HideInInspector]
	public bool activateP3 = false;
	[HideInInspector]
	public bool activateP4 = false;
	
	private Player player;
	private GameManager gm;
	private GUIManager GUIMan;



	void Start()
	{
		SpawnSelectableCharacters();
		player = FindObjectOfType<Player>();
		gm = FindObjectOfType<GameManager>();
		GUIMan = FindObjectOfType<GUIManager>();
	}


	/*
	 * void SpawnSelectableCharacters
	 * 
	 */
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
				chars[i][j] = (GameObject) Instantiate (charPrefabs[i * cols + j], new Vector2(i + i * 0.2f,j + j * 0.4f), Quaternion.identity);
				chars[i][j].renderer.material = notSelectedMat;
				//print ("start color: " + chars[i][j].renderer.material);
				//print ("not selected mat: " + notSelectedMat);
				//print ("start color: " + chars[i][j].renderer.material);
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

					if(chars[i][j].renderer.sharedMaterial == notSelectedMat) // If a character prefab is colored with the notSelected color, highlight it
					{
						chars[i][j].renderer.sharedMaterial = player.playerMat; // Match the color of the character with the player color
					}

					else
					{
						//chars[i][j].renderer.material.color = Color.black;
						//print ("merge colors");
					}
				}
				else
				{
					charP.DeSelect(player);
					if(charP.players.Count < 1)
					{
						chars[i][j].renderer.material = notSelectedMat;
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

		//player.previousDpadAxisX = Input.GetAxis("DPADHor" + player.playerNumber); // Set the current D-pad X-axis as previous
		player.previousDpadAxisX = Input.GetAxis("Horizontal" + player.playerNumber); // Set the current left-stick X-axis as previous

		player.currentChar.x += (int)player.previousDpadAxisX;
		player.currentChar.x = Mathf.Clamp(player.currentChar.x, 0, rows - 1);

		SetColor(); // Calls for SetColor function to add the highlight color to the current character
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

		//previousDpadAxisY = Input.GetAxis ("DPADVert" + player.playerNumber); // Set the current D-pad Y-axis as previous
		previousDpadAxisY = Input.GetAxis ("Vertical" + player.playerNumber); // Set the current left-stick Y-axis as previous

		player.currentChar.y -= (int)previousDpadAxisY;
		player.currentChar.y = Mathf.Clamp(player.currentChar.y, 0, cols - 1);

		SetColor(); // Calls for SetColor function to add the highlight color to the current character
	}

	
	/*
	 * public void SelectCharacter
	 * If player has selected, sets hasSelected bool to true
	 * sets the correct characterIndex so that the right character will spawn
	 * 
	 */
	public void SelectCharacter(Player p)
	{
		player = p;
		player.hasSelected = true;

		player.characterIndex = (int)(player.currentChar.x * 2 + player.currentChar.y); 
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
			GUIMan.startGameFailMsg = true;
			StartCoroutine(GUIMan.Coroutine1(2f)); // Active 2 sec
		}
	}


	/*
	 * void StartGame
	 * Start game, loads next level and set player inMenu-controls to false
	 * 
	 */
	void StartGame()
	{
		//Application.LoadLevel("testlevel");
		//Application.LoadLevel("_Build_01");
		Application.LoadLevel("Prototype");
	}
}
