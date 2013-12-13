using UnityEngine;
using System.Collections;


public class VictoryScreen : MonoBehaviour {
	
	public int vic;
	public bool isVictory;

	public GameObject[] players;
	
	
	void Start () {
		
	}
	
	void OnGUI () {
		if(isVictory){
			// make a victory screen
			GUI.Box(new Rect(10,10,Screen.width,Screen.height), "Victory");
			
			
		}
		
	}
	// how victory is decided
	void Update () {

		checkWin ();

		if(vic <= 0 && !isVictory){
			Debug.Log ("You won");

			for (int i = 0; i < players.Length; i++) {
				
				Player currentPlayer = players[i].GetComponent<Player>();
				
				if(currentPlayer.vehicle != null){
					Debug.Log (currentPlayer.name);
					
				}
				
			}
			isVictory = true;
			
		}
		
	}
	//checking who is the winner
	void checkWin(){

		for (int i = 0; i < players.Length; i++) {

			Player currentPlayer = players[i].GetComponent<Player>();

			if(currentPlayer.vehicle == null){
				vic--;

			}
			
				}
	}
}
