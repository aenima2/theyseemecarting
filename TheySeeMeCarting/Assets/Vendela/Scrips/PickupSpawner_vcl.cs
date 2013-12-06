using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupSpawner_vcl : MonoBehaviour {
	

	public List<GameObject> pickupList;
	
	public float currentPickup;
	
	public int PlayerNum; 



		
		
	void Start () {
		
	}
	
	void Update () {
		
		ShufflePickups();
		
		if (Input.GetKeyDown (KeyCode.R)){
			
			SpawnPickup ();
		}
		
	}
	
	
	//Spawn pickups
	void SpawnPickup(){
		
		
		//if pickup list is empty, don't spawn.
		if (pickupList.Count == 0){
			return;
		}
		
		int currentPickupInt = (int)currentPickup;
		
		GameObject pickup = (GameObject)Instantiate(pickupList[currentPickupInt], transform.position, transform.localRotation);
		Physics.IgnoreCollision (pickup.collider, collider);
		
		pickup.rigidbody.AddRelativeForce(transform.forward * 10f, ForceMode.VelocityChange);
		
		//Remove spawned pickup from the list and reset currently chosen pickup to 0(first in list).
		pickupList.RemoveAt(currentPickupInt);
		currentPickup = 0f;
		
	}
	
	
	//Shuffle between pickups
	void ShufflePickups()
	{
		Vehicle vehicle = FindObjectOfType<Vehicle>();
		
		if (Input.GetAxis ("Shuffle" + vehicle.playerNum) < 0.5f){
			
			currentPickup -= 1f;
			currentPickup = Mathf.Clamp (currentPickup, 0f, pickupList.Count-1f);
			Debug.Log (currentPickup);
			
		}
		
		if (Input.GetAxis ("Shuffle" + vehicle.playerNum) > 0.5f){

			
			currentPickup += 1f;
			currentPickup = Mathf.Clamp (currentPickup, 0f, pickupList.Count-1f);
			Debug.Log (currentPickup);
			
		}
		
		
	}	
		
}