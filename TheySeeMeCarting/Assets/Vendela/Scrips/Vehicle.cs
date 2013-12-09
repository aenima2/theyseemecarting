using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {


	public int playerNum;

	public float speed;
	public float speedRotation;
	
	public Vector3 gravityVel = Vector3.zero;


	//public float boostSpeed2;
	

	public float acc;
	public float accBack;
	
	Vector3 vel;
	
	public float velDamp;

	void Start(){

		rigidbody.centerOfMass = new Vector3 (0f,-0.5f,0f);

	}
		
	
	void OnGUI(){
		Rect r = new Rect(32,32,512,32);
		GUI.Box (r,"Forward1 = " + Input.GetAxis ("Forward1"));

		r.y += r.height;

		GUI.Box (r,"Forward2 = " + Input.GetAxis ("Forward2"));
	
	}

	void FixedUpdate(){

		if (transform.position.y > 1.768831){
		vel += Physics.gravity * Time.fixedDeltaTime;
		}
	}
	
	void Update ()
	{

		if(Input.GetButtonDown ("Fire" + playerNum))
		{
			PickupSpawner spawner = gameObject.GetComponent<PickupSpawner>();
			spawner.SpawnPickup();
			//Fire();
		}

		if(Input.GetButtonDown ("Jump" + playerNum))
		{
			Jump();
		}

		vel *= Mathf.Pow(velDamp, Time.deltaTime);
		rigidbody.velocity = vel * Time.deltaTime * speed;

		MoveForward();

		MoveBack();

		// D-pad test
		if (Input.GetAxis ("Shuffle" + playerNum) > 0f){


			PickupSpawner_vcl pickupSpawner = gameObject.GetComponent<PickupSpawner_vcl>();
			pickupSpawner.ShufflePickups();
			Debug.Log ("shuffle");
			
		}


		//rigidbody.velocity = (vel * Time.deltaTime * speedBack);
		//vel -= transform.forward * acc * Input.GetAxis ("Back" + playerNum);

		//Debug.Log(Input.GetAxis ("Horizontal" + playerNum));
	
		/*//boost
		if (Input.GetKeyDown (boostInput) ) {
			boostSpeed2 = 5f;
			
		}
		
		if (Input.GetKeyUp (boostInput) ) {
			boostSpeed2 = 1f;
			
		} */
		
		transform.Rotate(0f, speedRotation * Time.deltaTime * Input.GetAxis ("Horizontal" + playerNum), 0f);
	}

	public void MoveForward()
	{
		vel += transform.forward * acc * Input.GetAxis ("Forward" + playerNum);

	}

	public void MoveBack()
	{
		vel -= transform.forward * accBack * Input.GetAxis ("Back" + playerNum);
	}

	public void Fire()
	{
		print ("fire");
	}

	public void Jump()
	{
		print ("jump");
	}
}