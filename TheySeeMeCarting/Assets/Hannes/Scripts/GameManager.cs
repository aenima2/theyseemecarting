using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject playerPrefab;
	private List<GameObject> playerPrefabs = new List<GameObject>(); // This is where you put the playerPrefabs to create lists from, probably good to make this more generic*/

	[System.NonSerialized] // Variable invisible in inspector
	public float numberOfPlayers; // Number of players (attached to class)
	
	public List<Player> players = new List<Player>();
	public List<Cart> carts = new List<Cart>();

	[System.NonSerialized]
	public int pn = 0;

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
		SetNumberOfPlayers(1);
		CreatePlayers();
	}

	void Start ()
	{
		//Activate here when full menu is made
		//CreatePlayers();
	}
	
	public void SetNumberOfPlayers(float n)
	{
		for(int i=0; i < n; i++)
		{
			playerPrefabs.Add(playerPrefab); // Add set number of playerPrefabs to the playerPrefab list
		}
	}

	public void CreatePlayers()
	{
		//int pn = 0;

		foreach(GameObject playerPrefab in playerPrefabs)
		{
			Player player = (Instantiate(playerPrefab) as GameObject).GetComponent<Player>();

			if(pn == 0) // Set correct Camera rect for player 4
			{
				player.playerCol = Color.blue;
			}
			else if(pn == 1) // Set correct Camera rect for player 4
			{
				player.playerCol = Color.red;
			}
			/*
			else if(pn == 2) // Set correct Camera rect for player 4
			{
			}
			else if(pn == 3) // Set correct Camera rect for player 4
			{
			}*/

			player.playerNumber = pn;
			players.Add(player); // Adds a new player to the game



			/*Cart cart = player.SpawnCart(pn); // Accessing the spawning function from the Spawn initiate script
			carts.Add(cart); // Adds a new cart to the Game manager list*/
			pn++;
		}
	}



	/*private void CreateCarts()
	{
		int pn = 0;
		
		foreach(GameObject playerPrefab in players)
		{
			Player player = FindObjectOfType<Player>();


			
			Cart cart = player.SpawnCart(pn); // Accessing the spawning function from the Spawn initiate script
			carts.Add(cart); // Adds a new cart to the Game manager list
			pn++;
		}
	}*/
}
