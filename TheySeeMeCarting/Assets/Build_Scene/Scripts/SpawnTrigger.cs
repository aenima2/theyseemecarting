using UnityEngine;
using System.Collections;

public class SpawnTrigger : MonoBehaviour {

	private VehicleScript vehicle;


	void Start()
	{
		vehicle = FindObjectOfType<VehicleScript>();
	}

	void OnTriggerEnter(Collider other)
	{

	}
}
