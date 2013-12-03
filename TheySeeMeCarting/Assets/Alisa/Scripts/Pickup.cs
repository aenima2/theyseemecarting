using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public GameObject[] pickups;

	public GameObject pickup;

	void Start () {

		int rand = Random.Range (0, 2);

		pickup = pickups[rand];
	}

	void Update () {
	
	}

	void onTriggerEnter(Collider other){

		if (other.gameObject.tag == "Player"){

			PickupSpawner colPlayer = other.gameObject.GetComponent<PickupSpawner>();

			colPlayer.pickupList.Add (pickup);

		}

	}
}
