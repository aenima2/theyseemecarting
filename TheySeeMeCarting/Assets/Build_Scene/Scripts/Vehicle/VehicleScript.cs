using UnityEngine;
using System.Collections;

public class VehicleScript : MonoBehaviour {

	public int life;
	public bool isImmortal;

	//[HideInInspector]
	public float playerVehicleNr;

	// These variables allow the script to power the wheels of the car.
	public WheelCollider frontLeftWheel;
	public WheelCollider frontRightWheel;

	public float engineTorque; // speed
	public float wheelTurn; // How much the front wheels can turn

	private float engineRPM; // Currently not in use
	private Vector3 speed; // Current vehicle speed


	public bool inAir = false; // Used to check if the vehicle is air-born

	private Camera vehicleCam; 

	private Player player;
	
	
	
	void Start()
	{
		// I usually alter the center of mass to make the car more stable. I'ts less likely to flip this way.
		transform.FindChild("Chassi").rigidbody.centerOfMass += new Vector3(0f, -0.75f, 0.25f);

		player = FindObjectOfType<Player>();
	}

	void Update()
	{
		//speed = rigidbody.velocity; // Sets current speed
		//print (speed);
	}

	void FixedUpdate()
	{
		CheckGrounded();
	}


	public void CheckGrounded()
	{
		WheelHit hit;
		
		bool groundedL = frontLeftWheel.GetGroundHit(out hit);
		bool groundedR = frontRightWheel.GetGroundHit(out hit);
		
		if(groundedL || groundedR) // If any of the front-wheels touches the ground, the vehicle is grounded
			inAir = false;
		else // If not the vehicle is in air
			inAir = true;
	}


	public void Torque (Player P)
	{
		player = P;

		// apply torque to the front wheels
		frontLeftWheel.motorTorque = engineTorque * Input.GetAxis("Forward" + player.playerNumber);
		frontRightWheel.motorTorque = engineTorque * Input.GetAxis("Forward" + player.playerNumber);
	}


	public void Steering (Player P)
	{
		// changes the angulardrag depending on how much motor torque is added to the wheels, needs to be changed to how fast you're going
		if (frontLeftWheel.motorTorque > 70) 
		{
			rigidbody.angularDrag = 2000;
			//wheelTurn = 10;
			//frontLeftWheel.steerAngle = 10 * Input.GetAxis ("Horizontal0");
			//frontRightWheel.steerAngle = 10 * Input.GetAxis ("Horizontal0");
		} else
		{
			rigidbody.angularDrag = 10f;
			//wheelTurn = 30;
			//frontLeftWheel.steerAngle = 10 * Input.GetAxis ("Horizontal0");
			//frontRightWheel.steerAngle = 10 * Input.GetAxis ("Horizontal0");
		}

		// the steer angle is an arbitrary value multiplied by the user input
		frontLeftWheel.steerAngle = wheelTurn * Input.GetAxis("Horizontal" + player.playerNumber);
		frontRightWheel.steerAngle = wheelTurn * Input.GetAxis("Horizontal" + player.playerNumber);
	}


	public void Fire()
	{
		PickupResponseScript spawnPowerup = gameObject.GetComponent<PickupResponseScript>();
		spawnPowerup.SpawnPickup();
	}


	public void Jump()
	{
		print ("jump");
		rigidbody.velocity = new Vector3(0f, 5f, 0f);
	}


	/*
	 * public void ShufflePickups
	 * Enables players to scroll through picked up pickups by calling the Function from the PickupSpawner_vcl
	 * 
	 */
	public void ShufflePickups()
	{
		PickupResponseScript shufflePickup = gameObject.GetComponent<PickupResponseScript>();
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
	public void CheckGameOver()
	{
		if (life == 0)
		{
			Debug.Log ("You have lost");
			GameOver ();
		}
	}


	public void GameOver()
	{
		Destroy (gameObject);
	}


	public void SetColor()
	{
		MeshRenderer playerColor = gameObject.GetComponent<MeshRenderer>();
		
		if (isImmortal)
			playerColor.material.color = Color.green;
		
		if (!isImmortal)
			playerColor.material.color = Color.blue;
	}
}
