using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public GameObject raycastHolder;

	public ParticleSystem particles;


	void Start () {
	
	}

	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		Debug.Log(other.gameObject.name);	

		if (other.gameObject.tag == "Player"){

			FXSpawner fxSpawner = gameObject.GetComponent<FXSpawner>();
			fxSpawner.SpawnFX();

			Raycast ray = raycastHolder.GetComponentInChildren<Raycast>();
			ray.RayCast ();
			Destroy (gameObject);
		}
		
	}

}
