
using UnityEngine;
using System.Collections;

public class PickupScreen : MonoBehaviour {
	
	
	public Rect myRect;
	
	public Rect r;
	
	public int fontSize;
	
	public GameObject[] players;
	
	
	void OnGUI (){
		
		GUI.skin.box.fontSize = fontSize;
		
		r = myRect;
		
		r.x *=Screen.width;
		r.y *=Screen.height;
		
		r.width *=Screen.width;
		r.height *=Screen.height;	
		
		for(int i = 0; i< players.Length; i++){
			
			Player currentPlayer = players[i].GetComponent<Player>();
			//TITTA NÄRMARE PÅ: PickupSpawner_vcl Pickup = GetComponent<PickupSpawner_vcl>();
			
			if (currentPlayer.vehicle == null) {
				continue;
			}
			
			//GUI.color = currentPlayer.vehicle.renderer.material.color;
			
			
			int life = currentPlayer.vehicle.life;
			//TITTA NÄRMARE PÅ: float pickup = Pickup.pickupList;
			GUI.Box (r, players[i].name  + "\n" + "Life: " + life + "\n" + "Pickup: ");
			r.y += r.height; 

		}
		
	}
	


	
	void Start () {
		
	}
	
	
	void Update () {
		
		
		
	}	
	
} 