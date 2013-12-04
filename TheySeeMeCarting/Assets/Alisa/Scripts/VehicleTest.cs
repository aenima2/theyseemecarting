using UnityEngine;
using System.Collections;

public class VehicleTest : MonoBehaviour {

	public int life;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (Input.GetKey (KeyCode.UpArrow)){
				transform.position += transform.forward * 10f * Time.deltaTime;
			}

	
		if (Input.GetKey (KeyCode.DownArrow)){
				transform.position -= transform.forward * 10f * Time.deltaTime;
			}

	}

	public void CalcLife(){
		life--;
		CheckGameOver ();

	}

	public void CheckGameOver(){
		if (life == 0){
			Debug.Log ("You have lost");
			Destroy (gameObject);
		}
	}
}
