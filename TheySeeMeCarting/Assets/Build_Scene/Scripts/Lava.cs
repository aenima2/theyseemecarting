using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lava : MonoBehaviour {

	[HideInInspector]
	public List<Transform> vehicleSpawnLocations;

	public GameObject testVehiclePrefab;

	private Player player;

	public int currentPlayer;


	public VehicleScript vehicle;

	public VehicleScriptTEST vehicleTEST;

	void Start()
	{
		player = FindObjectOfType<Player>();
	}

	void OnTriggerEnter(Collider other)
	{
		other.GetComponent<VehicleScript>().CalcLife();
		other.transform.position = new Vector3(40f, 3f, 40f);

		//Destroy (other.gameObject.transform.parent.gameObject);
	}
}
