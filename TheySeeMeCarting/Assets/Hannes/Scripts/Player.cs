using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	// Player info
	public string playerName;
	public Color playerCol;

	// Cart handling
	public KeyCode forward;
	public KeyCode back;
	public KeyCode left;
	public KeyCode right;
	public KeyCode fire;

	[HideInInspector]
	public float previousDpadAxisX;
	[HideInInspector]
	public float previousDpadAxisY;
	[HideInInspector]
	public bool hasSelected = false;

	[HideInInspector]
	public Vector2 currentChar = Vector2.zero; // The index of the current character

	// Menu handling
	public bool inMenu = false;

	//public DelegateMenu delegateMenu;

	[HideInInspector]
	public Cart cart;

	public Vehicle vehicle;

	public CartSpawnLoader spawner;

	[HideInInspector]
	public List<Transform> cartSpawnLocations;

	[HideInInspector]
	public GameObject playerCharacter;

	public List<GameObject> possibleCharacters; // used for multi char select
	public int characterIndex; // used for multi char select (change to static (i think))

	public int playerNumber; // Player number

	[HideInInspector]
	public int nop = 0; // Number of players

	private CharSelect cs;



	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start ()
	{
		cs = FindObjectOfType<CharSelect>();
		if(playerNumber == 0)
			cs.chars[(int)currentChar.x][(int)currentChar.y].renderer.material.color = Color.blue; // Highlight the first character at start (using the same color as player1, if their color changes, change this color to match it
		print ("start");
		// Add bool if in menu (for control)
		// Show Selectcharacter menu
		// Change prefab depending on player selection
		// Call SpawnCart on select
	}
	
	void Update ()
	{
		if (inMenu == true)
			MenuInput();
		else
			VehicleInput();
	}

	public Vehicle SpawnVehicle(int pn)
	{
		//float nop;

		characterIndex = Random.Range (0, 3); // Set the cart to be spawned to random

		GameObject spawnLoc = GameObject.FindWithTag("CartSpawn").gameObject;
		cartSpawnLocations = spawnLoc.GetComponent<CartSpawnLoader>().cartSpawnLocations;
		print ("found spawnloc");
		vehicle = ((GameObject)Instantiate(playerCharacter/*[characterIndex-1]*/, cartSpawnLocations[pn].position, Quaternion.identity)).GetComponent<Vehicle>();
		print ("spawned cart");

		//Camera cam = cart.transform.FindChild("CartCam").GetComponent<Camera>(); // Get the camera from the cart
		//cam.enabled = true;
		//print ("cam active");

		//cart.player = this; // Sets to player
		vehicle.player = this;

		//cart = ((GameObject)Instantiate(prefabCart, cartSpawnLocations[pn].position, Quaternion.identity)).GetComponent<Cart>();
		//cart.player = this; // Sets to player

		GameManager gm = FindObjectOfType<GameManager>(); // Gathers how many players that should spawn
		// Failsafe to make sure there's a gamemanager in the scene
		if(gm == null)
		{
			Debug.LogError("Couldn't find a Game Manager in the scene");
		}

		/*nop = gm.numberOfPlayers; // Sets number of players to "nop"

		//Camera cam = cart.transform.FindChild("CartCam").GetComponent<Camera>(); // Get the camera from the cart
		
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
				playerCol = Color.blue;
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
		}*/

		//tank.tankColor = tankColor;
		//tank.SetColor(tankColor);

		//return cart;
		return vehicle;
	}
	

	void MenuInput() // Add an in menu bool, so you change input depending on menu/game
	{
		// Menu navigation
		if(hasSelected == false)
		{
			if(Input.GetAxis("DPADHor" + playerNumber) != previousDpadAxisX)
			{
				cs.ScrollHorizontally(this);
			}
			if(Input.GetAxis("DPADVert" + playerNumber) != previousDpadAxisY)
			{
				cs.ScrollVertically(this);
			}
		}

		// Button commands
		if(Input.GetButtonDown("Select" + playerNumber))
		{
			print ("select");
			cs.SelectCharacter(this);
		}
		if(Input.GetButtonDown("DeSelect" + playerNumber))
		{
			cs.DeSelectCharacter(this);
			print ("deselect");
		}
		if(Input.GetButtonDown("StartAll"))
		{
			cs.TryStartGame();
		}
	}

	void VehicleInput()
	{
		print ("in vehicle");
	}
}
