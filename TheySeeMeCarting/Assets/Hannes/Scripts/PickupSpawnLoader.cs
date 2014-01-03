using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupSpawnLoader : MonoBehaviour {
	
	public List<Transform> pickupSpawnLocations;



	void Start()
	{
		LoadSpawnLocations();
	}


	/*
	 * public List<Transform> LoadSpawnLocations
	 * Set up spawn locations by getting the components from a parent object and adding them to a list and returning the content
	 * Also removes the parent object.
	 * 
	 */
	public List<Transform> LoadSpawnLocations()
	{
		Transform[] tempSpawnLocs = GetComponentsInChildren<Transform>(); // Recieves all the spawnlocations from the Holder gameobject
		pickupSpawnLocations.AddRange(tempSpawnLocs); // Counts the spawn locations and adds cartSpawnLocations to the list
		pickupSpawnLocations.Remove(transform); // Removes the Holder gamobject from the list
		return pickupSpawnLocations;
	}
}
