using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public Transform turretHead;

	public Transform enemy;

	public GameObject bulletPrefab;

	public float lifeSpan;

	public ParticleSystem destroyedFX;

	public float shootDelay;

	Vector3 vel;

	public float velDamp;

	public float speed;

	
	void Start () {
	
	}

	void FixedUpdate(){

		//rigidbody.velocity += Physics.gravity * Time.deltaTime;

		//vel *= Mathf.Pow(velDamp, Time.deltaTime);
		//rigidbody.velocity = vel * Time.deltaTime * speed;
	}

	void Update () {
	

		LocateEnemy ();

		StartCoroutine (LifeSpan());

		Shoot();

		if (Input.GetKeyDown (KeyCode.A)){
			SpawnBullet ();
		}

	}

	Vector3 BulletSpawnLoc(){
		return turretHead.position + turretHead.forward * 1.15f;
	}

	void SpawnBullet(){

		Vector3 bulletSpawnLoc = BulletSpawnLoc ();

		GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawnLoc, Quaternion.identity);

		Physics.IgnoreCollision (bullet.collider, collider);
		bullet.rigidbody.AddRelativeForce (turretHead.forward * 30f, ForceMode.VelocityChange);

	}

	void LocateEnemy(){

		turretHead.LookAt (enemy);


	}

	void Shoot(){

		shootDelay += Time.deltaTime;
		if (shootDelay>0.2f){
		SpawnBullet ();
			shootDelay = 0.0f;
		}
	}
	

	void DestructFX(){
	ParticleSystem desFX = (ParticleSystem)Instantiate (destroyedFX, gameObject.transform.position, Quaternion.identity);
	}

	IEnumerator LifeSpan(){
		yield return new WaitForSeconds(lifeSpan);
		DestructFX ();
		Destroy (gameObject);

	}

//	void OnCollisionEnter(Collision other){
//
//		if(other.gameObject.tag == "Arena"){
//			rigidbody.drag = 3f;
//		}
//	}
}
