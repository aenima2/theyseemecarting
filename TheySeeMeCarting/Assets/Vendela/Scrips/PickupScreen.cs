
using UnityEngine;
using System.Collections;

public class PickupScreen : MonoBehaviour {
	
	/*
	public Rect myRect;
	
	public Rect r;
	
	public int fontSize;
	
	public GameObject[] players;

	string currentPickup;
	
	
	void OnGUI (){
		
		GUI.skin.box.fontSize = fontSize;
		
		r = myRect;
		
		r.x *=Screen.width;
		r.y *=Screen.height;
		
		r.width *=Screen.width;
		r.height *=Screen.height;	
		
		for(int i = 0; i< players.Length; i++){

			Player currentPlayer = players[i].GetComponent<Player>();

			if (currentPlayer.vehicle != null){

			PickupSpawner_vcl pickupSpawner = currentPlayer.vehicle.GetComponent<PickupSpawner_vcl>();

			int pickupNum = pickupSpawner.pickupList.Count;

			if (pickupSpawner.pickupList.Count > 0){

			int currentP = (int)pickupSpawner.currentPickup;
			currentPickup = pickupSpawner.pickupList[currentP].name;

			}else{
				currentPickup = "No pickups!";
			}


			if (currentPlayer.vehicle == null) {
				continue;
			}
			
			GUI.color = currentPlayer.vehicle.renderer.material.color;
			
			
			int life = currentPlayer.vehicle.life;
			GUI.Box (r, players[i].name  + "\n" + "Life: " + life + "\n" + pickupNum + " Pickups" + "\n" + "Current Pickup:"+ "\n" + currentPickup);
			r.y += r.height + 10f; 


			}


		}
		
	}
	
	*/

	
	void Start () {
		
	}
	
	
	void Update () {
		
		
		
	}	
	
} 