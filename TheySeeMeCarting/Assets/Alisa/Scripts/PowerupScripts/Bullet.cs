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

			VehicleTest vehicle = other.gameObject.GetComponent<VehicleTest>();
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
