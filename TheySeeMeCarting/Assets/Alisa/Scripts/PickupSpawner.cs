using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupSpawner : MonoBehaviour {

	public GameObject turretPrefab;
	
	public List<GameObject> pickupList;

	public float currentPickup;

	void Start () {
	
	}

	void Update () {
	
		ShufflePickups();

		if (Input.GetKeyDown (KeyCode.R)){
			SpawnPickup ();
		}

	}

//	void SpawnPickup(){
//
//		GameObject pickup = (GameObject)Instantiate(turretPrefab, transform.position, transform.localRotation);
//		Physics.IgnoreCollision (pickup.collider, collider);
//
//		pickup.rigidbody.AddRelativeForce(transform.forward * 10f, ForceMode.VelocityChange);
//
//
//	}
	
	void SpawnPickup(){

		int currentPickupInt = (int)currentPickup;
		
		GameObject pickup = (GameObject)Instantiate(pickupList[currentPickupInt], transform.position, transform.localRotation);
		Physics.IgnoreCollision (pickup.collider, collider);
		
		pickup.rigidbody.AddRelativeForce(transform.forward * 10f, ForceMode.VelocityChange);
		
		
	}

	void ShufflePickups(){

		if (Input.GetKeyDown (KeyCode.Y)){

			currentPickup -= 1f;
			currentPickup = Mathf.Clamp (currentPickup, 0f, 3f);
			Debug.Log (currentPickup);

		}

		if (Input.GetKeyDown (KeyCode.U)){

			currentPickup += 1f;
			currentPickup = Mathf.Clamp (currentPickup, 0f, 3f);
			Debug.Log (currentPickup);

		}


	}
	
}
