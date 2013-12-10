
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
			
			if (currentPlayer.cart == null) {
				continue;
			}
			
			GUI.color = currentPlayer.cart.renderer.material.color;
			
			
			int health = currentPlayer.cart.life;
			GUI.Box (r, players[i].name  + "\n" + "Health: " + health );
			r.y += r.height; 

		}
		
	}
	


	
	void Start () {
		
	}
	
	
	void Update () {
		
		
		
	}	
	
} 