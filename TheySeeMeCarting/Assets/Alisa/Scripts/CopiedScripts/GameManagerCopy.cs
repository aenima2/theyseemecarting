using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerCopy : MonoBehaviour {

	public GameObject playerPrefab;
	private List<GameObject> playerPrefabs = new List<GameObject>(); // This is where you put the playerPrefabs to create lists from, probably good to make this more generic*/

	[System.NonSerialized] // Variable invisible in inspector
	public float numberOfPlayers; // Number of players (attached to class)
	
	public List<Player> players = new List<Player>();
	public List<Cart> carts = new List<Cart>();
	
	int pn = 0;

	public float playerNum = 1f;

	public float playerIDGP1;
	public float playerIDGP2;
	
	public bool joinedGP1 = false;
	public bool joinedGP2 = false;

	public int whichGP;


	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start ()
	{

	}

	void Update() 
	{
		if (Input.GetButtonDown ("360_StartButton")){

			JoinGameGP1 ();

		}

//		if (Input.GetButtonDown ("360_BackButton")){
//
//			LeaveGame ();
//
//		}

		if (Input.GetButtonDown ("360_StartButton2")){

			JoinGameGP2 ();
			
		}
		
//		if (Input.GetButtonDown ("360_BackButton2")){
//
//			whichGP = 2;
//			LeaveGame ();
//			
//		}


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
			player.playerNumber = pn;
			players.Add(player); // Adds a new player to the game



			/*Cart cart = player.SpawnCart(pn); // Accessing the spawning function from the Spawn initiate script
			carts.Add(cart); // Adds a new cart to the Game manager list*/
			pn++;
		}
	}

	public void JoinGameGP1()
	{

		if (!joinedGP1){

			playerNum++;
			joinedGP1 = true;
			playerIDGP1 = playerNum;

		}

	}


	public void JoinGameGP2()
	{
		
		if (!joinedGP2){
			
			playerNum++;
			joinedGP2 = true;
			playerIDGP2 = playerNum;
			
		}
		
	}

//	public void LeaveGame()
//	{
//		if (whichGP == 1){
//		if (joinedGP1){
//			playerNum--;
//			joinedGP1=false;
//			playerIDGP1 = 0f;
//		}
//
//		}
//
//		else if (whichGP == 2){
//
//		if (joinedGP2){
//			playerNum--;
//			joinedGP2=false;
//			playerIDGP2 = 0f;
//		}
//
//		}
//
//	}






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
