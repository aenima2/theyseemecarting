using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupResponseScript : MonoBehaviour {

	public List<GameObject> pickupList;
	public float currentPickup;
	public int PlayerNum;
	public float previousDpadAxisX;

	private Vector3 curPosition;
	
	private Player player;
	

	void Start()
	{
		player = FindObjectOfType<Player>();
		curPosition = gameObject.transform.position;
	}

	void Update()
	{
		ShufflePickups();

		if (Input.GetKeyDown (KeyCode.R))
			SpawnPickup();

		curPosition = gameObject.transform.position;
	}
	
	
	//Spawn pickups
	public void SpawnPickup(){
		
		//if pickup list is empty, don't spawn.
		if (pickupList.Count == 0)
			return;
		
		int currentPickupInt = (int)currentPickup;
		
		GameObject pickup = (GameObject)Instantiate(pickupList[currentPickupInt], transform.position, transform.localRotation);
		Debug.Log ("Spawned");
		
		if (pickup.collider != null)
			Physics.IgnoreCollision (pickup.collider, collider);
		
		if (pickup.gameObject.name.Contains ("Immortality"))
		{	
			Immortality immo = pickup.GetComponent<Immortality>();
			VehicleScript player = gameObject.GetComponent<VehicleScript>();
			immo.spawner = player;

			player.isImmortal = true;
			
			setPlayerMat();
		}
		
		if (pickup.gameObject.name.Contains ("Replicant"))
		{
			MeshFilter pickupMesh = pickup.GetComponent<MeshFilter>();
			pickupMesh.mesh = gameObject.GetComponent<MeshFilter>().mesh;
			
			Transform pickupTransform = pickup.GetComponent<Transform>();
			pickupTransform.localScale = transform.localScale;
			
			MeshRenderer pickupMat = pickup.GetComponent<MeshRenderer>();
			pickupMat.material = gameObject.GetComponent<MeshRenderer>().material;
		}
		
		if (pickup.gameObject.name.Contains ("Turret"))
		{
			pickup.transform.position = new Vector3(curPosition.x, (curPosition.y + 1f), curPosition.z);
			pickup.transform.parent = gameObject.transform;
			Turret t = pickup.gameObject.GetComponentInChildren<Turret>();
			t.spawnMaster = gameObject;
		}
		
		if (pickup.rigidbody != null)
		{
			Vector3 throwAngle = new Vector3(0f, 7f, 40f);
			pickup.rigidbody.AddRelativeForce(throwAngle, ForceMode.VelocityChange);
		}
		
		//Remove spawned pickup from the list and reset currently chosen pickup to 0(first in list).
		pickupList.RemoveAt(currentPickupInt);
		currentPickup = 0f;
		
	}


	//Shuffle between pickups
	public void ShufflePickups()
	{
		if (Input.GetAxis ("Shuffle0") != previousDpadAxisX)
		{	
			previousDpadAxisX = Input.GetAxis ("Shuffle0");
			currentPickup += previousDpadAxisX;
			currentPickup = Mathf.Clamp (currentPickup, 0f, pickupList.Count-1f);
		}
	}


	void setPlayerMat(){
		
		MeshRenderer playerMat = gameObject.GetComponent<MeshRenderer>();
		playerMat.material.color = Color.green;
	}
}
