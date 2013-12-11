using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float lifeSpan;

	public GameObject raycastHolder;

	void Start () {

		StartCoroutine(LifeSpan ());
	
	}

	void Update () {

	
	}

	IEnumerator LifeSpan(){
		yield return new WaitForSeconds(lifeSpan);
		Explode ();
	}

	void Explode(){

		FXSpawner fxSpawner = gameObject.GetComponent<FXSpawner>();
		fxSpawner.SpawnFX();

		Raycast ray = raycastHolder.GetComponentInChildren<Raycast>();
		ray.RayCast();
		Destroy (gameObject);

	}

}
