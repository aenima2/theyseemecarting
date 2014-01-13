using UnityEngine;
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
	
	public float engineTorque = 230.0f; // speed
	
	private float engineRPM = 0.0f;
	
	private Camera vehicleCam; 
	
	private Player player;
	
	
	
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
		if (Input.GetButtonDown("Fire0"))
			Fire();
		if (Input.GetButtonDown("Shuffle0")) 
			ShufflePickups();
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
	
	
	public void Steering ()
	{
		// the steer angle is an arbitrary value multiplied by the user input.
		frontLeftWheel.steerAngle = 10 * Input.GetAxis("Horizontal0");
		frontRightWheel.steerAngle = 10 * Input.GetAxis("Horizontal0");
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
