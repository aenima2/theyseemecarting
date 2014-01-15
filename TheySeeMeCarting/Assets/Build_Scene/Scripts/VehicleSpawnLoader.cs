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
}
