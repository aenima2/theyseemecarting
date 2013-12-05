using UnityEngine;
using System.Collections;

public class ExplosionCollider : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}

	void OnCollisionEnter(Collision other){


		if (other.gameObject.name.Contains ("Player")){

			Debug.Log ("Player collision");
			VehicleTest player = gameObject.GetComponent<VehicleTest>();
			player.CalcLife();
		}

	}

}
