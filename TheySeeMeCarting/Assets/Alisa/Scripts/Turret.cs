using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public Transform turretHead;

	public Transform enemy;

	public GameObject bulletPrefab;

	public float lifeSpan;

	public ParticleSystem destroyedFX;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		StartCoroutine (LifeSpan());

		if (Input.GetKeyDown (KeyCode.A)){
			SpawnBullet ();
		}

		LocateEnemy ();

	}

	Vector3 BulletSpawnLoc(){
		return turretHead.position + turretHead.forward * 1.15f;
	}

	void SpawnBullet(){

		Vector3 bulletSpawnLoc = BulletSpawnLoc ();

		GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawnLoc, Quaternion.identity);

		Physics.IgnoreCollision (bullet.collider, collider);
		bullet.rigidbody.AddRelativeForce (turretHead.forward * 15f, ForceMode.VelocityChange);

	}

	void LocateEnemy(){

		turretHead.LookAt (enemy);
	}
	

	void DestructFX(){
	ParticleSystem desFX = (ParticleSystem)Instantiate (destroyedFX, gameObject.transform.position, Quaternion.identity);
	}

	IEnumerator LifeSpan(){
		yield return new WaitForSeconds(lifeSpan);
		DestructFX ();
		Destroy (gameObject);

	}


}
