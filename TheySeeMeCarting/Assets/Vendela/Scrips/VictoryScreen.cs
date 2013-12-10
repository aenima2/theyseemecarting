using UnityEngine;
using System.Collections;


public class VictoryScreen : MonoBehaviour {
	
	public int vic;
	public bool isVictory;
	
	
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
		if(vic <= 0 && !isVictory){
			Debug.Log ("You won");
			
			
			
			isVictory = true;
			
		}
		
	}
}
