using UnityEngine;
using System.Collections;

public class ParticleFX : MonoBehaviour {

	void Start () {

	
	}

	void Update () {

		ParticleSystem ps = gameObject.GetComponent<ParticleSystem>();

		if (!ps.isPlaying){

			Destroy ();

		}

	}

	void Destroy(){
		Destroy (gameObject);
	}
	


}

