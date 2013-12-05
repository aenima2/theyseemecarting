using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	// Player info
	public string playerName;

	// Cart handling
	public KeyCode forward;
	public KeyCode back;
	public KeyCode left;
	public KeyCode right;
	public KeyCode fire;

	// Menu handling
	public KeyCode menuUp;
	public KeyCode menuDown;
	public KeyCode menuLeft;
	public KeyCode menuRight;
	public KeyCode menuSelect;

	//public DelegateMenu delegateMenu;

	[System.NonSerialized] // Variable invisible in inspector
	public Cart cart;

	public CartSpawnLoader spawner;

	[System.NonSerialized]
	public List<Transform> cartSpawnLocations;

	[System.NonSerialized]
	public GameObject playerCharacter; // used for multi char select

	public List<GameObject> possibleCharacters; // used for multi char select
	public int characterIndex; // used for multi char select (change to static (i think))

	public int playerNumber; // Player number

	//private float nop; // Number of players



	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start ()
	{
		// Add bool if in menu (for control)
		// Show Selectcharacter menu
		// Change prefab depending on player selection
		// Call SpawnCart on select
	}
	
	void Update ()
	{
		MenuInput();
	}

	public Cart SpawnCart(int pn)
	{
		float nop;

		characterIndex = Random.Range (0, 3); // Set the cart to be spawned to random

		GameObject spawnLoc = GameObject.FindWithTag("CartSpawn").gameObject;
		cartSpawnLocations = spawnLoc.GetComponent<CartSpawnLoader>().cartSpawnLocations;

		cart = ((GameObject)Instantiate(possibleCharacters[characterIndex-1], cartSpawnLocations[pn].position, Quaternion.identity)).GetComponent<Cart>();
		cart.player = this; // Sets to player

		//cart = ((GameObject)Instantiate(prefabCart, cartSpawnLocations[pn].position, Quaternion.identity)).GetComponent<Cart>();
		//cart.player = this; // Sets to player

		GameManager gm = FindObjectOfType<GameManager>(); // Gathers how many players that should spawn
		// Failsafe to make sure there's a gamemanager in the scene
		if(gm == null)
		{
			Debug.LogError("Couldn't find a Game Manager in the scene");
		}
		nop = gm.numberOfPlayers; // Sets number of players to "nop"

		Camera cam = cart.transform.FindChild("CartCam").GetComponent<Camera>(); // Get the camera from the cart

		// If 2 players
		if (nop <= 2)
		{
			cam.rect = new Rect(0f, 0.5f - (pn / nop), 1f, 0.5f);
		}

		// If more than 2 players
		else if (nop > 2)
		{
			if(pn == 0) // Set correct Camera rect for player 4
			{
				cam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			}
			else if(pn == 1) // Set correct Camera rect for player 4
			{
				cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
			}
			else if(pn == 2) // Set correct Camera rect for player 4
			{
				cam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
			}
			else if(pn == 3) // Set correct Camera rect for player 4
			{
				cam.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
			}
		}

		//tank.tankColor = tankColor;
		//tank.SetColor(tankColor);

		return cart;
	}
	

	void MenuInput() // Add an in menu bool, so you change input depending on menu/game
	{
		CharacterSelect charSelect = FindObjectOfType<CharacterSelect>();

		if(Input.GetKeyDown(menuLeft))
		{
			charSelect.MenuLeft();
		}
		if(Input.GetKeyDown(menuRight))
		{
			charSelect.MenuRight();
		}
		/*if(Input.GetKeyDown(menuSelect))
		{
			delMenu.MenuSelect();
		}*/










		DelegateMenu delMenu = FindObjectOfType<DelegateMenu>();

		if(Input.GetKeyDown(menuUp))
		{
			delMenu.MenuUp();
		}
		if(Input.GetKeyDown(menuDown))
		{
			delMenu.MenuDown();
		}
		if(Input.GetKeyDown(menuSelect))
		{
			delMenu.MenuSelect();
		}

	}
}
