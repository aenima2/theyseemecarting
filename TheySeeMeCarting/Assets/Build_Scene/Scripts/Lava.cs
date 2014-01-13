using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lava : MonoBehaviour {

	[HideInInspector]
	public List<Transform> vehicleSpawnLocations;

	public GameObject testVehiclePrefab;

	public VehicleScriptTEST vehicle;

	void OnTriggerEnter(Collider other)
	{
		Destroy (other.gameObject);
		SpawnVehicle();
	}

	void SpawnVehicle()
	{
		if(GameObject.FindWithTag("CartSpawn") != null)
		{
			GameObject spawnLoc = GameObject.FindWithTag("CartSpawn").gameObject;
			vehicleSpawnLocations = spawnLoc.GetComponent<VehicleSpawnLoader>().vehicleSpawnLocations;
			vehicle = ((GameObject)Instantiate(testVehiclePrefab, vehicleSpawnLocations[0].position, Quaternion.identity)).GetComponent<VehicleScriptTEST>();
		}
	}
}
