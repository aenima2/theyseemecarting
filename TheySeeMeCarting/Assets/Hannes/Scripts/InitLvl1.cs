using UnityEngine;
using System.Collections;

public class InitLvl1 : MonoBehaviour {


	void Start ()
	{
		Initialize();
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
}
