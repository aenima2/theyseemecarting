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

		ParticleFX particles = gameObject.GetComponent<ParticleFX>();
		particles.SpawnFX();
		Raycast ray = raycastHolder.GetComponentInChildren<Raycast>();
		ray.RayCast();
		Destroy (gameObject);

	}

}
