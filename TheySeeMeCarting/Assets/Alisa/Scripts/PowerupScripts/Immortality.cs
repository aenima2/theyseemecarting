using UnityEngine;
using System.Collections;

public class Immortality : MonoBehaviour {

	public float lifeSpan;

	public Vehicle spawner;
	
	void Start () {
		StartCoroutine (LifeSpan());
	}

	void Update () {
	
	}

	IEnumerator LifeSpan(){
		yield return new WaitForSeconds(lifeSpan);
		spawner.isImmortal = false;
		spawner.setColor ();
		Destroy (gameObject);
	}
}
