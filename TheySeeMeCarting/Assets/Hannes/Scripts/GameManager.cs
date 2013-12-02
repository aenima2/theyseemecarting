using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public List<Player> players = new List<Player>();
	public List<Cart> carts = new List<Cart>();
	public List<GameObject> playerPrefabs = new List<GameObject>(); // This is where you put the playerPrefabs to create lists from, probably good to make this more generic

	//public CartSpawner cartSpawner;


	void Start ()
	{
		CreatePlayers();
	
	}

	private void CreatePlayers()
	{
		foreach(GameObject playerPrefab in playerPrefabs)
		{
			Player player = (Instantiate(playerPrefab) as GameObject).GetComponent<Player>();
			players.Add(player); // Adds a new player to the game

			Cart cart = player.spawner.SpawnCart(); // Accessing the spawning function from the Spawn initiate script
			carts.Add(cart); // Adds a new cart to the Game manager list
		}
	}


}
