using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

	//health
	public int life;
	public bool isImmortal;

	public int playerNum;

	public float speed;
	public float speedRotation;
	
	public Vector3 gravityVel = Vector3.zero;

	public Camera vehicleCam;
	//public float boostSpeed2;

	public float acc;
	public float accBack;
	
	Vector3 vel;
	
	public float velDamp;

	private Player player;



	void Start(){
		rigidbody.centerOfMass = new Vector3 (0f,-1f,0f);
		gameObject.GetComponent<Vehicle>().enabled = true;
		player = FindObjectOfType<Player>();
		//playerNum = (int)player.playerNumber; // Get correct playernumber from the Player script

	}

	void FixedUpdate()
	{
		VehicleBehavior();
		print ("criss");
	}


	/*
	 * void VehicleBehavior
	 * Set vehicle gravity, damp-speed and velocity
	 * 
	 */
	void VehicleBehavior()
	{
		if (transform.position.y > 2.628834)
		{
			vel += Physics.gravity * Time.fixedDeltaTime;
		}

		vel *= Mathf.Pow(velDamp, Time.deltaTime);
		rigidbody.velocity = vel * Time.deltaTime * speed;
	}


	/*
	 * public void VehicleRotation
	 * Rotates the vehicle by rotating the vehicle position by getting the position of the left Funstick
	 * 
	 */
	public void VehicleRotation(Player p)
	{
		player = p;

		if(player.direction > 0) // If player is moving forward
		{
			transform.Rotate(0f, speedRotation * Time.deltaTime * Input.GetAxis ("Horizontal" + player.playerNumber), 0f);
		}
		else // If player is moving backwards
		{
			transform.Rotate(0f, -speedRotation * Time.deltaTime * Input.GetAxis ("Horizontal" + player.playerNumber), 0f);
		}
	}


	/*
	 * void MoveForward
	 * Moves the player forward by increasing velocity with acceleration and getting the left trigger-input from the gamepad
	 * 
	 */
	public void MoveForward(Player p)
	{
		player = p;

		vel += transform.forward * acc * Input.GetAxis ("Forward" + player.playerNumber);
	}


	/*
	 * void MoveBack
	 * Moves the player backwards by decreasing velocity with acceleration and getting the right trigger-input from the gamepad
	 * 
	 */
	public void MoveBack(Player P)
	{
		player = P;

		vel -= transform.forward * accBack * Input.GetAxis ("Back" + player.playerNumber);
	}

	/*
	 * public void Fire
	 * Spawns a pickup from the PickupSpawner_vcl script in front of the vehicle
	 * 
	 */
	public void Fire()
	{
		PickupSpawner_vcl spawnPickup = gameObject.GetComponent<PickupSpawner_vcl>();
		spawnPickup.SpawnPickup();
	}


	/*
	 * public void Jump
	 * 
	 * 
	 */
	public void Jump()
	{
		//print ("jump");
		vel += transform.up * 8;
	}


	/*
	 * public void ShufflePickups
	 * Enables players to scroll through picked up pickups by calling the Function from the PickupSpawner_vcl
	 * 
	 */
	public void ShufflePickups()
	{
		PickupSpawner_vcl shufflePickup = gameObject.GetComponent<PickupSpawner_vcl>();
		shufflePickup.ShufflePickups();
	}


	/*
	 * public void CalcLife
	 * If vehicle isn't immortal, remove life by subtracting from the life variable, 
	 * then checking the GameOverFunction
	 * 
	 */
	public void CalcLife(){
		
		if (isImmortal == true){
			return;
		}

		life--;
		CheckGameOver();
		
	}


	/*
	 * public void CheckGameOver
	 * 
	 * 
	 */
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