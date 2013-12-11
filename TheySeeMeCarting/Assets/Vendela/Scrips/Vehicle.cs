using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

	//health
	public int life;
	public bool isImmortal;

	public int playerNum;

	public float speed;
	public float speedRotation;
	public Player player;
	
	public Vector3 gravityVel = Vector3.zero;


	//public float boostSpeed2;
	

	public float acc;
	public float accBack;
	
	Vector3 vel;
	
	public float velDamp;

	void Start(){

		rigidbody.centerOfMass = new Vector3 (0f,-1f,0f);

	}

	void FixedUpdate(){

		if (transform.position.y > 2.628834){
			vel += Physics.gravity * Time.fixedDeltaTime;
		}

		if(Input.GetButtonDown ("Fire" + playerNum))
		{
			PickupSpawner_vcl spawner = gameObject.GetComponent<PickupSpawner_vcl>();
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
	}
	
	void Update ()
	{

		// D-pad test
		if (Input.GetAxis ("Shuffle" + playerNum) > 0f){


			PickupSpawner_vcl pickupSpawner = gameObject.GetComponent<PickupSpawner_vcl>();
			pickupSpawner.ShufflePickups();
			
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

	public void CalcLife(){
		
		if (isImmortal == true){
			return;
		}
		
		
		life--;
		CheckGameOver ();
		
	}
	
	public void CheckGameOver(){
		if (life == 0){
			Debug.Log ("You have lost");
			GameOver ();
		}
	}
	
	public void GameOver(){
		Destroy (gameObject);
	}
	
	public void setColor(){
		MeshRenderer playerColor = gameObject.GetComponent<MeshRenderer>();
		
		if (isImmortal){
			playerColor.material.color = Color.green;
		}
		
		if (!isImmortal){
			playerColor.material.color = Color.blue;
		}
	}
}