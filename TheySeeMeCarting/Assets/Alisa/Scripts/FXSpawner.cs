using UnityEngine;
using System.Collections;

public class FXSpawner : MonoBehaviour {

	public ParticleSystem particles;

	void Start () {
	
	}
	

	void Update () {
	
	}

	public void SpawnFX(){
		ParticleSystem particleFX = (ParticleSystem)Instantiate(particles, transform.position, Quaternion.identity);
	}
}
