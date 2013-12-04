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

		VehicleTest vehicle = other.gameObject.GetComponent<VehicleTest>();

		if (other.gameObject.tag == "Enemy"){
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
