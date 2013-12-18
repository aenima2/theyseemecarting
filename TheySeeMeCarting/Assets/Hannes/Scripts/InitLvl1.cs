using UnityEngine;
using System.Collections;

public class InitLvl1 : MonoBehaviour {

	private Player player;

	void Start ()
	{
		Initialize();
		player = FindObjectOfType<Player>();
		StartCoroutine(ActivateVehicle(1)); // Holds vehicle control activation
	}


	void Initialize()
	{
		//GameManager gm = FindObjectOfType<GameManager>();
		Player[] players = FindObjectsOfType<Player>();


		foreach(Player p in players)
		{
			p.SpawnVehicle(p.playerNumber);
			p.inMenu = false;
			p.vehicle = FindObjectOfType<Vehicle>();
		}
	}


	/*
	 * IEnumerator Coroutine1
	 * Adds wait time for the vehicle controls to activate
	 * 
	 */
	public IEnumerator ActivateVehicle(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		player.vehicleActive = true;
	}
}
