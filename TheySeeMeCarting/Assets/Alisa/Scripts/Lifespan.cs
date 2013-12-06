using UnityEngine;
using System.Collections;

public class Lifespan : MonoBehaviour {

	public float lifespan;
	
	void Start () {

		StartCoroutine (LifeSpan ());
	
	}

	void Update () {
	
	}

	IEnumerator LifeSpan(){
		yield return new WaitForSeconds(lifespan);

		Destroy (gameObject);
	}
}
