using UnityEngine;
using System.Collections;

public class VehicleTest : MonoBehaviour {

	public int life;

	public bool isImmortal;
	
	void Start () {

	}

	void Update () {

	}

	public void CalcLife(){

		if (isImmortal == true){
			return;
		}


		life--;
		CheckGameOver ();

	}

	public void CheckGameOver(){
		if (life == 0){
			Debug.Log ("You have lost");
			GameOver ();
		}
	}

	public void GameOver(){
		Destroy (gameObject);
	}

	public void setColor(){
		MeshRenderer playerColor = gameObject.GetComponent<MeshRenderer>();

		if (isImmortal){
			playerColor.material.color = Color.green;
		}

		if (!isImmortal){
			playerColor.material.color = Color.blue;
		}
	}
}
