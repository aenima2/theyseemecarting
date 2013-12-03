using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


	void Start () {
	
	}

	void Update () {
	
	}

	void OnCollisionEnter(Collision other){

		Debug.Log (other.gameObject.name);

		Enemy enemy = other.gameObject.GetComponent<Enemy>();

		if (other.gameObject.tag == "Enemy"){
			enemy.CalcLife();
		}
	}
}
