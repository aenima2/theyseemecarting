using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupSpawnLoader : MonoBehaviour {


	public List<Transform> pickupSpawnLocations;



	void Awake ()
	{
		LoadSpawnLocations();
	}
	
	void Update ()
	{
		
	}


	public List<Transform> LoadSpawnLocations()
	{
		Transform[] tempSpawnLocs = GetComponentsInChildren<Transform>(); // Recieves all the spawnlocations from the Holder gameobject
		pickupSpawnLocations.AddRange(tempSpawnLocs); // Counts the spawn locations and adds cartSpawnLocations to the list 
		pickupSpawnLocations.Remove(transform); // Removes the Holder gamobject from the list
		return pickupSpawnLocations;
	}
}
