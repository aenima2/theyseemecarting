using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupSpawner_vcl : MonoBehaviour {
	

	public List<GameObject> pickupList;
	
	public float currentPickup;
	
	public int PlayerNum; 

	public float previousDpadAxisX;
		
	void Start () {
		
	}
	
	void Update () {
		
		ShufflePickups();
		
		if (Input.GetKeyDown (KeyCode.R)){
			
			SpawnPickup ();
		}
		
	}
	
	
	//Spawn pickups
	public void SpawnPickup(){
		
		
		//if pickup list is empty, don't spawn.
		if (pickupList.Count == 0){
			return;
		}
		
		int currentPickupInt = (int)currentPickup;
		
		GameObject pickup = (GameObject)Instantiate(pickupList[currentPickupInt], transform.position, transform.localRotation);

		if (pickup.collider != null){
			Physics.IgnoreCollision (pickup.collider, collider);
		}

		if (pickup.gameObject.name.Contains ("Immortality")){
			
			Immortality immo = pickup.GetComponent<Immortality>();
			Vehicle player = gameObject.GetComponent<Vehicle>();
			
			immo.spawner = player;
			
			
			player.isImmortal = true;
			
			setPlayerMat ();
		}

		if (pickup.gameObject.name.Contains ("Replicant")){
			//Debug.Log ("Its a clone!");
			
			MeshFilter pickupMesh = pickup.GetComponent<MeshFilter>();
			pickupMesh.mesh = gameObject.GetComponent<MeshFilter>().mesh;
			
			Transform pickupTransform = pickup.GetComponent<Transform>();
			pickupTransform.localScale = transform.localScale;
			
			MeshRenderer pickupMat = pickup.GetComponent<MeshRenderer>();
			pickupMat.material = gameObject.GetComponent<MeshRenderer>().material;
		}

		if (pickup.gameObject.name.Contains ("Turret")){
			Turret t = pickup.gameObject.GetComponent<Turret>();
			t.spawnMaster = gameObject;
		}
		
		if (pickup.rigidbody != null){
			
			Vector3 throwAngle = new Vector3(0f, 7f, 8f);
			pickup.rigidbody.AddRelativeForce(throwAngle, ForceMode.VelocityChange);
		}
		
		//Remove spawned pickup from the list and reset currently chosen pickup to 0(first in list).
		pickupList.RemoveAt(currentPickupInt);
		currentPickup = 0f;
		
	}
	
	
	//Shuffle between pickups
	public void ShufflePickups()
	{
		Vehicle vehicle = gameObject.GetComponent<Vehicle>();

		if (Input.GetAxis ("DPADHor" + vehicle.playerNum) != previousDpadAxisX){

			previousDpadAxisX = Input.GetAxis ("DPADHor" + vehicle.playerNum);
			currentPickup += previousDpadAxisX;
			currentPickup = Mathf.Clamp (currentPickup, 0f, pickupList.Count-1f);
			
		}
		
	}

	void setPlayerMat(){
		
		MeshRenderer playerMat = gameObject.GetComponent<MeshRenderer>();
		playerMat.material.color = Color.green;
	}
		
}