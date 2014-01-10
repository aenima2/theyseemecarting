using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public GameObject[] pickups;

	public GameObject pickup;
	
	//private PickupSpawner spawner;

	void Start()
	{
		//spawner = FindObjectOfType<PickupSpawner>();
		int rand = Random.Range (0, pickups.Length);
		pickup = pickups[rand];
	}


	void OnTriggerEnter(Collider other){

		Debug.Log ("Collision detected ");

		//If Collider is a Player
		if (other.gameObject.tag == "Player"){

			//PickupSpawner_vcl colPlayer = other.gameObject.GetComponent<PickupSpawner_vcl>();
			PickupResponseScript colPlayer = other.gameObject.GetComponent<PickupResponseScript>();
			FXSpawner fxSpawner = gameObject.GetComponent<FXSpawner>();
			fxSpawner.SpawnFX();

			int i = colPlayer.pickupList.Count;

			if (i > 2){
				colPlayer.pickupList.RemoveAt(0);
			}

			colPlayer.pickupList.Add (pickup);

			//Destroy Pickup
			Destroy (gameObject);
		}
	}
}
