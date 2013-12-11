using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject playerPrefab;
	private List<GameObject> playerPrefabs = new List<GameObject>(); // This is where you put the playerPrefabs to create lists from, probably good to make this more generic*/

	//[System.NonSerialized] // Variable invisible in inspector
	//public float numberOfPlayers; // Number of players (attached to class)
	
	public List<Player> players = new List<Player>();
	public List<Cart> carts = new List<Cart>();
	
	[HideInInspector]
	public int pn = 0;
	[HideInInspector]
	public int nop;

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start ()
	{
		SetNumberOfPlayers(1);
		CreatePlayers();
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
		foreach(GameObject playerPrefab in playerPrefabs)
		{
			Player player = (Instantiate(playerPrefab) as GameObject).GetComponent<Player>();

			if(pn == 0) // Set correct color for player 1
			{
				player.playerCol = Color.blue;
			}
			else if(pn == 1) // Set correct color for player 2
			{
				player.playerCol = Color.red;
			}

			//player.inMenu = true;
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
