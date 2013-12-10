using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public GameObject raycastHolder;


	void Start () {
	
	}

	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		Debug.Log(other.gameObject.name);	

		if (other.gameObject.tag == "Player"){

			ParticleFX particles = gameObject.GetComponent<ParticleFX>();
			particles.SpawnFX();

			Raycast ray = raycastHolder.GetComponentInChildren<Raycast>();
			ray.RayCast ();
			Destroy (gameObject);
		}
		
	}
}
