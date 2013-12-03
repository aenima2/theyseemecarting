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

	public GameObject numberOfPlayer;

	void Start ()
	{
		// Start here tomorrow
		//GameObject gameManager = GameObject.FindWithTag("GM").gameObject;
		//numberOfPlayer = gameManager.GetComponent<GameManager>().numberOfPlayers;
	}
	
	void Update ()
	{
	
	}

	public Cart SpawnCart(int nop)
	{
		GameObject spawnLoc = GameObject.FindWithTag("CartSpawn").gameObject;
		cartSpawnLocations = spawnLoc.GetComponent<CartSpawnLoader>().cartSpawnLocations;

		cart = ((GameObject)Instantiate(prefabCart, cartSpawnLocations[nop].position, Quaternion.identity)).GetComponent<Cart>();
		cart.player = this; // Sets to player

		if (nop <= 2)
		{
		Camera cam = cart.transform.FindChild("CartCam").GetComponent<Camera>();
		print (nop);
		cam.rect = new Rect(0f, (.5f -(nop / 2f)), 1f, 0.5f);
		print (cam.rect);
		}
		else if (nop > 2)
		{
			Camera cam = cart.transform.FindChild("CartCam").GetComponent<Camera>();
			print (nop);
			cam.rect = new Rect(0f, (.5f -(nop / 2f)), 1f, 0.5f);
			print (cam.rect);
		}




		//tank.tankColor = tankColor;
		//tank.SetColor(tankColor);



		return cart;
	}
}
