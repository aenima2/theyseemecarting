﻿using UnityEngine;
using System.Collections;

public class VehicleScriptTEST : MonoBehaviour {
	
	public int life;
	public bool isImmortal;
	
	// These variables allow the script to power the wheels of the car.
	public WheelCollider frontLeftWheel;
	public WheelCollider frontRightWheel;
	
	// These variables are for the gears, the array is the list of ratios. The script
	// uses the defined gear ratios to determine how much torque to apply to the wheels.
	//public float[] gearRatio;
	//public int currentGear;
	
	public float engineTorque; // speed
	private Vector3 speed;
	
	private float engineRPM;
	
	private Camera vehicleCam; 
	
	private Player player;

	public bool inAir = false; // Used to check if the vehicle is air-born


	
	void Start()
	{
		// I usually alter the center of mass to make the car more stable. I'ts less likely to flip this way.
		rigidbody.centerOfMass += new Vector3(0f, -0.75f, 0.25f);
		
		player = FindObjectOfType<Player>();
	}
	
	
	void Update()
	{
		Torque();
		Steering();

		KeyBoardTorque();

		//if (speed.x == still)
		//	AssistedSteering();

		if (Input.GetButtonDown("Fire0"))
			Fire();
		if (Input.GetButtonDown("Shuffle0")) 
			ShufflePickups();
		if (Input.GetButtonDown("Jump0")) 
			Jump();

		speed = rigidbody.velocity; // Set actual velocity as speed
		//print (speed.y);

		/*
		if(inAir)
		{
			rigidbody.AddForce(0f, -50000f, 0f);// * Time.fixedDeltaTime;
			//Physics.gravity = new Vector3(0f, -100f, 0f);
			//speed -= Physics.gravity * Time.fixedDeltaTime * 100;
		}
		//else
		//	Physics.gravity = new Vector3(0f, -10f, 0f);
		*/
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

	
	public void Torque ()
	{
		//player = P;
		
		//print ("torque " + player.playerNumber);
		
		// finally, apply the values to the wheels.	The torque applied is divided by the current gear, and
		// multiplied by the user input variable.
		frontLeftWheel.motorTorque = engineTorque * Input.GetAxis("Forward0");
		frontRightWheel.motorTorque = engineTorque * Input.GetAxis("Forward0");
	}


	void KeyBoardTorque()
	{
		if (Input.GetKey(KeyCode.W))
		{
			frontLeftWheel.motorTorque = engineTorque;
			frontRightWheel.motorTorque = engineTorque;
		}

		if (Input.GetKey(KeyCode.S))
		{
			frontLeftWheel.motorTorque = -engineTorque;
			frontRightWheel.motorTorque = -engineTorque;
		}
	}
	
	
	public void Steering()
	{
		// the steer angle is an arbitrary value multiplied by the user input.
		if (frontLeftWheel.motorTorque > 70) 
		{
			rigidbody.angularDrag = 20;
			//frontLeftWheel.steerAngle = 10 * Input.GetAxis ("Horizontal0");
			//frontRightWheel.steerAngle = 10 * Input.GetAxis ("Horizontal0");
		} else
		{
			rigidbody.angularDrag = 1;
			//frontLeftWheel.steerAngle = 10 * Input.GetAxis ("Horizontal0");
			//frontRightWheel.steerAngle = 10 * Input.GetAxis ("Horizontal0");
		}

		frontLeftWheel.steerAngle = 10 * Input.GetAxis ("Horizontal0");
		frontRightWheel.steerAngle = 10 * Input.GetAxis ("Horizontal0");
	}

	void KeyBoardSteering()
	{
		if (Input.GetKey(KeyCode.A))
		{
			frontLeftWheel.steerAngle = 100;
			frontRightWheel.steerAngle = 100;
		}
	}


	public void AssistedSteering()
	{
		transform.Rotate(0f, 10 * Time.deltaTime * Input.GetAxis ("Horizontal0"), 0f);
		print("turning");
	}


	public void Jump()
	{
		print ("jump");
		rigidbody.AddForce (0f, 500000f, 0);
	}

	
	public void Fire()
	{
		PickupResponseScript spawnPowerup = gameObject.GetComponent<PickupResponseScript>();
		spawnPowerup.SpawnPickup();
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
