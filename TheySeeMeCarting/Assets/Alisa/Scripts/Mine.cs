using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {


	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter(Collider other){ // other is the collider that entered the trigger 
		Debug.Log(other.gameObject.name);	

		if (other.gameObject.tag == "Player"){
			Vehicle colPlayer = other.gameObject.GetComponent<Vehicle>();

			colPlayer.CalcLife ();
			Destroy (gameObject.rigidbody);
		}
		
	}
}
