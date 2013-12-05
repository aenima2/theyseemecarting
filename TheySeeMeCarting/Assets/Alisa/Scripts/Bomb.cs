using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float lifeSpan;

	public ParticleSystem explodeFX;

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

		ParticleSystem exlodeFX = (ParticleSystem)Instantiate(explodeFX, transform.position, Quaternion.identity);
		Raycast ray = raycastHolder.GetComponentInChildren<Raycast>();
		ray.RayCast();
	}

}
