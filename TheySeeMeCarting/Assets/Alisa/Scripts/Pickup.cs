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

		if (other.gameObject.tag == "Player"){

			PickupSpawner colPlayer = other.gameObject.GetComponent<PickupSpawner>();

			if (colPlayer.pickupList.GetRange())

			colPlayer.pickupList.Add (pickup);

			Destroy (gameObject);

		}

	}
}
