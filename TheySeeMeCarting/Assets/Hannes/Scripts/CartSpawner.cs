using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CartSpawner : MonoBehaviour {

	private Transform lastLocation; // might not be needed

	public GameObject[] carts; // might not be needed

	public List<Transform> cartSpawnLocations;

	public GameObject prefabCart;

	[System.NonSerialized]
	public Cart cart;

	[System.NonSerialized]
	public Player player;

	//[System.NonSerialized]
	//public GameManager gm;


	void Awake ()
	{
		LoadSpawnLocations();
	}

	void Start ()
	{
	
	}
	
	void Update ()
	{
	
	}

	public List<Transform> LoadSpawnLocations()
	{
		Transform[] tempSpawnLocs = GetComponentsInChildren<Transform>(); // Recieves all the spawnlocations from the Holder gameobject
		cartSpawnLocations.AddRange(tempSpawnLocs); // Counts the spawn locations and adds cartSpawnLocations to the list 
		cartSpawnLocations.Remove(transform); // Removes the Holder gamobject from the list
		return cartSpawnLocations;
	}

	public Cart SpawnCart()
	{	
		int randomLoc = Random.Range(1, cartSpawnLocations.Count); // Randomizes where to spawn new cart
		
		cart = ((GameObject)Instantiate(prefabCart, cartSpawnLocations[randomLoc].position, Quaternion.identity)).GetComponent<Cart>();
		cart.GetComponent<Player>().spawner = this;

		/*
		 * Put information about the cart here
		Rect cameraRect = cart.cartCamera.rect;
		cart.tankCamera.rect = cameraRect;
		cart.SetColor(tankColor);*/
		
		return cart;
	}
}
