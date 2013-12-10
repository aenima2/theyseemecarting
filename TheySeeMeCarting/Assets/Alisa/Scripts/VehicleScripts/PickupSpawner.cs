using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupSpawner : MonoBehaviour {

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
			VehicleTest player = gameObject.GetComponent<VehicleTest>();

			immo.spawner = player;


			player.isImmortal = true;

			setPlayerMat ();
		}

		if (pickup.gameObject.name.Contains ("Replicant")){
			//Debug.Log ("Its a clone!");

			MeshFilter pickupMesh = pickup.GetComponent<MeshFilter>();
		
			pickupMesh.mesh = gameObject.GetComponent<MeshFilter>().mesh;
			pickupMesh.GetComponentsInChildren<MeshFilter>();

			Transform pickupTransform = pickup.GetComponent<Transform>();
			pickupTransform.localScale = transform.localScale;

			MeshRenderer pickupMat = pickup.GetComponent<MeshRenderer>();
			pickupMat.material = gameObject.GetComponent<MeshRenderer>().material;
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
	void ShufflePickups(){

		if (Input.GetKeyDown (KeyCode.Y)){

			currentPickup -= 1f;
			currentPickup = Mathf.Clamp (currentPickup, 0f, pickupList.Count-1f);
			Debug.Log (currentPickup);

		}

		if (Input.GetKeyDown (KeyCode.U)){

			currentPickup += 1f;
			currentPickup = Mathf.Clamp (currentPickup, 0f, pickupList.Count-1f);
			Debug.Log (currentPickup);

		}


	}

	void setPlayerMat(){

		MeshRenderer playerMat = gameObject.GetComponent<MeshRenderer>();
		playerMat.material.color = Color.green;
	}
	
}
