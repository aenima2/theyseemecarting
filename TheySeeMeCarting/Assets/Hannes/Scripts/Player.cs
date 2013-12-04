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

	[System.NonSerialized] // Variable invisible in inspector
	public Cart cart;

	public CartSpawnLoader spawner;

	public List<Transform> cartSpawnLocations;
	
	public GameObject prefabCart;

	public float CamX;
	public float CamP;
	
	public int playerNumber;

	private float nop;
	

	void Start ()
	{
		GameManager gameManager = FindObjectOfType<GameManager>();
		if(gameManager == null)
		{
			Debug.LogError("Couldn't find a Game Manager in the scene");
		}
	}
	
	void Update ()
	{

	}


	public void PlayerAmount()
	{


		GameManager gm = FindObjectOfType<GameManager>();
		nop = gm.numberOfPlayers;

		//return nop;
	}

	public Cart SpawnCart(int pn)
	{
		GameObject spawnLoc = GameObject.FindWithTag("CartSpawn").gameObject;
		cartSpawnLocations = spawnLoc.GetComponent<CartSpawnLoader>().cartSpawnLocations;


		cart = ((GameObject)Instantiate(prefabCart, cartSpawnLocations[pn].position, Quaternion.identity)).GetComponent<Cart>();
		cart.player = this; // Sets to player

		// Gathers how many players that should spawn
		GameManager gm = FindObjectOfType<GameManager>(); 
		nop = gm.numberOfPlayers;

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
}
