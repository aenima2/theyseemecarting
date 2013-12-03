using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public List<Player> players = new List<Player>();

	//GameObject[] players = new GameObject[]<Player>();

	//private Player[] players = playerList.ToArray();

	public List<Cart> carts = new List<Cart>();
	private List<GameObject> playerPrefabs = new List<GameObject>(); // This is where you put the playerPrefabs to create lists from, probably good to make this more generic*/

	public GameObject playerPrefab;

	public int numberOfPlayers;
	

	//public CartSpawner cartSpawner;


	void Start ()
	{
		SetNumberOfPlayers(4);
		CreatePlayers();
	}
	
	public void SetNumberOfPlayers(int n)
	{
		for(int i=0; i < n; i++)
		{
			playerPrefabs.Add(playerPrefab); // Add set number of playerPrefabs to the playerPrefab list
		}
	}

	private void CreatePlayers()
	{
		int nop = 0;

		foreach(GameObject playerPrefab in playerPrefabs)
		{
			Player player = (Instantiate(playerPrefab) as GameObject).GetComponent<Player>();
			player.playerNumber = nop;
			players.Add(player); // Adds a new player to the game

			Cart cart = player.SpawnCart(nop); // Accessing the spawning function from the Spawn initiate script
			carts.Add(cart); // Adds a new cart to the Game manager list
			nop++;
		}
	}
	


}
