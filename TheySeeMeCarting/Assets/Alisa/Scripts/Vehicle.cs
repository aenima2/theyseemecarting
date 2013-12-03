using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int life;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CalcLife(){
		life--;
		CheckGameOver ();

	}

	public void CheckGameOver(){
		if (life == 0){
			Debug.Log ("You have lost");
		}
	}
}
