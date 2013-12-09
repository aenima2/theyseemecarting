using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public GameObject[] pickups;

	public GameObject pickup;

	void Start () {

		int rand = Random.Range (0, pickups.Length);
		pickup = pickups[rand];
	}

	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		Debug.Log ("Collision detected");


		//If Collider is a Player
		if (other.gameObject.tag == "Player"){

			PickupSpawner_vcl colPlayer = other.gameObject.GetComponent<PickupSpawner_vcl>();
			ParticleFX particles = gameObject.GetComponent<ParticleFX>();
			particles.SpawnFX();

			int i = colPlayer.pickupList.Count;

			Debug.Log (i);

			if (i > 2){
				colPlayer.pickupList.RemoveAt(0);
			}

			colPlayer.pickupList.Add (pickup);

			//Destroy Pickup
			Destroy (gameObject);
		}

		}

	}
