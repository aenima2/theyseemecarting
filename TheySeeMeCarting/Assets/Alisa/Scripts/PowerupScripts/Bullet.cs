using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float lifeSpan;

	void Start () {
	
	}

	void Update () {
		LifeSpan ();
	}



	void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "Player"){

			VehicleScript vehicle = other.gameObject.GetComponent<VehicleScript>();
			vehicle.CalcLife();

		}

		Destroy (gameObject);
	}

	void LifeSpan(){
		lifeSpan -= Time.deltaTime;
		
		if (lifeSpan <= 0f){
		
			Destroy(gameObject);
		}
	}
}
