  using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	// Player info
	public string playerName;
	public Material playerMat;
	
	[HideInInspector]
	public float previousDpadAxisX;
	[HideInInspector]
	public float previousDpadAxisY;
	[HideInInspector]
	public bool hasSelected = false;

	[HideInInspector]
	public Vector2 currentChar = Vector2.zero; // The index of the current character
	[HideInInspector]
	public GameObject curCharGO;

	[HideInInspector]
	public bool inMenu = false; // Menu handling
	
	public float direction; // Used to check if player is moving forward or back



	public CartSpawnLoader spawner;

	[HideInInspector]
	public List<Transform> cartSpawnLocations;

	[HideInInspector]
	public GameObject playerVehicle;

	public GameObject[] possibleCharacter; // used for multi char select
	public int characterIndex; // used for multi char select (change to static (i think))

	public float playerNumber; // Player number

	public Vehicle vehicle; // Vehicle script
	private CharSelect cs; // CharSelect script
	private GameManager gm; // GameManager script



	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start ()
	{
		gm = FindObjectOfType<GameManager>();
		cs = FindObjectOfType<CharSelect>();

		gm.nop++;
		//print("number of players: " + gm.nop);

		inMenu = true;

		Player1SelectAtStart();


	}

	void FixedUpdate()
	{
		if(inMenu == false)
			VehicleInput();
	}
	
	void Update()
	{
		if (inMenu == true)
			MenuInput();
	}


	public void Player1SelectAtStart()
	{
		if(inMenu == true)
		{
			if(playerNumber == 0)
			{
				curCharGO = cs.chars[(int)currentChar.x][(int)currentChar.y]; // Set curCharGO by getting the charPrefab from current coordinates
				
				CharPrefab charP = curCharGO.GetComponent<CharPrefab>(); // Get reference from CharPrefab script
				charP.Select (this); // Set curCharGO as selected
				
				curCharGO.renderer.material = playerMat; // Highlight the first character at start
			}
		}
	}


	public Vehicle SpawnVehicle(float pn)
	{
		// Spawn vehicle
		if(GameObject.FindWithTag("CartSpawn") != null)
		{
			GameObject spawnLoc = GameObject.FindWithTag("CartSpawn").gameObject;
			cartSpawnLocations = spawnLoc.GetComponent<CartSpawnLoader>().cartSpawnLocations;
			vehicle = ((GameObject)Instantiate(possibleCharacter[characterIndex]/*playerVehicle*/, cartSpawnLocations[(int)pn].position, Quaternion.identity)).GetComponent<Vehicle>();
		}

		Camera cam = vehicle.transform.FindChild("Camera").GetComponent<Camera>(); // Get the camera from the vehicle
		cam.enabled = true; // Enable the cam

		// If 1 player
		if (gm.nop == 1) // For testing purpose only
		{
			cam.rect = new Rect(0f, 0f, 1f, 1f);
		}

		// If 2 players
		if (gm.nop == 2) // (gm.nop <= 2)
		{
			cam.rect = new Rect(0f, 0.5f - (playerNumber / gm.nop), 1f, 0.5f);
		}

		// If more than 2 players
		else if (gm.nop > 2)
		{
			if(playerNumber == 0) // Set correct Camera rect for player 1
			{
				cam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			}
			else if(playerNumber == 1) // Set correct Camera rect for player 2
			{
				cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
			}
			else if(playerNumber == 2) // Set correct Camera rect for player 3
			{
				cam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
			}
			else if(playerNumber == 3) // Set correct Camera rect for player 4
			{
				cam.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
			}
		}

		return vehicle;
	}
	

	void MenuInput()
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
			cs.SelectCharacter(this);
		}
		if(Input.GetButtonDown("DeSelect" + playerNumber))
		{
			cs.DeSelectCharacter(this);
		}
		if(Input.GetButtonDown("StartAll"))
		{
			cs.TryStartGame();
		}
	}

	void VehicleInput()
	{
		// Vehicle navigation
		if(Input.GetAxis ("Forward" + playerNumber) != 0f)
		{
			//moveForw = true;
			direction = (Input.GetAxis ("Forward" + playerNumber));
			vehicle.MoveForward(this); // Forward
		}

		if(Input.GetAxis ("Back" + playerNumber) != 0f)
		{
			//moveForw = false;
			direction = (Input.GetAxis ("Forward" + playerNumber));
			vehicle.MoveBack(this); // Back
		}


		vehicle.VehicleRotation(this); // Rotate (was in update)

		// Button commands
		if(Input.GetButtonDown ("Jump" + playerNumber)) // Jump
		{
			vehicle.Jump();
		}
		if(Input.GetButtonDown ("Fire" + playerNumber)) // Fire
		{
			vehicle.Fire();
		}
		if (Input.GetAxis ("Shuffle" + playerNumber) > 0f) // Scroll through pickups (was in update)
		{
			vehicle.ShufflePickups();
		}
	}
}
