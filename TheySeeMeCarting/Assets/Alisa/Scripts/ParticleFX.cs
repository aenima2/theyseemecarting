using UnityEngine;
using System.Collections;

public class ParticleFX : MonoBehaviour {

	public ParticleSystem particlesSystem;
	
	void Start () {
	
	}

	void Update () {
	
	}

	public void SpawnFX(){
		ParticleSystem particleFX = (ParticleSystem)Instantiate(particlesSystem, transform.position, Quaternion.identity);
	}

}

