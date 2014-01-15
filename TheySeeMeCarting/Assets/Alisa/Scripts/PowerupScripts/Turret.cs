using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour {

	public GameObject spawnMaster;

	public Transform turretHead;

	public Transform target;

	public GameObject bulletPrefab;

	public float lifeSpan;

	public ParticleSystem destroyedFX;

	public float shootDelay;

	Vector3 vel;

	public float velDamp;

	public float speed;

	public float damp;

	
	void Update () {

		StartCoroutine (LifeSpan());

		if (Input.GetKeyDown (KeyCode.A)){
			SpawnBullet ();
		}

	}

	Vector3 BulletSpawnLoc()
	{
		return turretHead.position + turretHead.forward * 1.15f;
	}

	void SpawnBullet()
	{

		Vector3 bulletSpawnLoc = BulletSpawnLoc ();

		GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawnLoc, Quaternion.identity);

		Physics.IgnoreCollision (bullet.collider, collider);
		bullet.rigidbody.AddRelativeForce (turretHead.forward * 30f, ForceMode.VelocityChange);

	}

	void LocateTarget(){

		if (target != null){

		Quaternion rotate = Quaternion.LookRotation(target.position - turretHead.position);
		turretHead.rotation = Quaternion.Slerp (turretHead.rotation, rotate, Time.deltaTime * damp);

		}
	}

	void OnTriggerStay(Collider other)
	{

		if(other.gameObject != spawnMaster)
		{
			if (target == null)
			{
				target = other.transform;
			}

			float targetToTurret = Vector3.Distance (transform.position, target.transform.position);
			float otherToTurret = Vector3.Distance (transform.position, other.transform.position);

			if (targetToTurret > otherToTurret){

			target = other.transform;

			}

			LocateTarget ();
			Shoot ();

		}
	}

	void Shoot(){

		shootDelay += Time.deltaTime;
		if (shootDelay > 0.25f)
		{
			SpawnBullet ();
			shootDelay = 0.0f;
		}
	}
	

	void DestructFX()
	{
		ParticleSystem desFX = (ParticleSystem)Instantiate (destroyedFX, gameObject.transform.position, Quaternion.identity);
	}
	


	IEnumerator LifeSpan()
	{
		print ("turret lifespan start");
		yield return new WaitForSeconds(lifeSpan);
		DestructFX ();
		Destroy (gameObject);
		print ("turret lifespan end");
	}

}
