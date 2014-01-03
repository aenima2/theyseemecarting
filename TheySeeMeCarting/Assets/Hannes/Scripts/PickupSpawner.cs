using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour {
	
	public GameObject pickupPrefab; // Object to spawn

	public bool timerActive = false; // Used for debug



	void Start()
	{
		SpawnPickup(); // Spawns pickups at the very start
	}


	/*
	 * void OnTriggerStay
	 * Checks object tag for player, if true activates Coroutine "SpawnTimer"
	 * 
	 */
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			StartCoroutine(SpawnTimer(3)); // Set wait time before re-spawn
		}
	}


	/*
	 * public void SpawnPickup
	 * Spawns desired pickup on itself.
	 * 
	 */
	public void SpawnPickup()
	{
		GameObject pickupGO = (GameObject)Instantiate(pickupPrefab, transform.position, Quaternion.identity);
		//print ("spawned");
		//timerActive = false;
	}


	/*
	 * private IEnumerator SpawnTimer
	 * Activates a wait timer after which it activates the SpawnPickup function
	 * 
	 */
	private IEnumerator SpawnTimer(float waitTime)
	{
		if(timerActive == false)
		{
			timerActive = true;
			//print ("start counter");
			yield return new WaitForSeconds(waitTime);
			SpawnPickup(); // When wait is over activate SpawnPickup function
			//print ("count complete");
			timerActive = false;
		}
	}
}
