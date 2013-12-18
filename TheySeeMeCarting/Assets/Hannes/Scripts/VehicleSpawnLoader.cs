using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VehicleSpawnLoader : MonoBehaviour {

	// VARIABLES

	public List<Transform> vehicleSpawnLocations;



	// FUNCTIONS

	void Awake ()
	{
		LoadSpawnLocations();
		//SpawnCarts();
	}


	/*
	 * public List<Transform> LoadSpawnLocations
	 * Saves all the spawn locations in a list and then removing the Holder object
	 * 
	 */
	public List<Transform> LoadSpawnLocations()
	{
		Transform[] tempSpawnLocs = GetComponentsInChildren<Transform>(); // Recieves all the spawnlocations from the Holder gameobject
		vehicleSpawnLocations.AddRange(tempSpawnLocs); // Counts the spawn locations and adds cartSpawnLocations to the list 
		vehicleSpawnLocations.Remove(transform); // Removes the Holder gamobject from the list
		return vehicleSpawnLocations;
	}
	

	/*public void SpawnCarts()
	{
		Player player = FindObjectOfType<Player>();
		GameManager gm = FindObjectOfType<GameManager>();

		player.SpawnVehicle(gm.pn);
	}*/


	// Moved to player
	/*public Cart SpawnCart()
	{	
		int randomLoc = Random.Range(1, cartSpawnLocations.Count); // Randomizes where to spawn new cart
		
		cart = ((GameObject)Instantiate(prefabCart, cartSpawnLocations[randomLoc].position, Quaternion.identity)).GetComponent<Cart>();
		print (cart+", "+cart.GetComponent<Player>());
		cart.GetComponent<Player>().spawner = this;*/

		/*
		 * Put information about the cart here
		Rect cameraRect = cart.cartCamera.rect;
		cart.tankCamera.rect = cameraRect;
		cart.SetColor(tankColor);*/
		
		/*return cart;
	}*/
}
