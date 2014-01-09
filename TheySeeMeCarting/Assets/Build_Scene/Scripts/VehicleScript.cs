using UnityEngine;
using System.Collections;

public class VehicleScript : MonoBehaviour {		
		
	public WheelCollider wheelFL;
	public WheelCollider wheelFR;
	public WheelCollider wheelRL;
	public WheelCollider wheelRR;
	
	public float steerMax = 20f;
	public float motorMax = 10f;
	public float brakeMax = 100f;

	private float steer = 0f;
	public float motor = 0f;
	private float brake = 0f;


	private Player player;

		
	void Start()
	{
		player = FindObjectOfType<Player>();
		//rigidbody.centerOfMass += new Vector3(0f, 0f, -1f);
	}
	
	
	void FixedUpdate()
	{
		steer = Mathf.Clamp(Input.GetAxis("Horizontal" + player.playerNumber), -1, 1);
		motor = Mathf.Clamp(Input.GetAxis("Vertical" + player.playerNumber), 0, 1);
		brake = -1 * Mathf.Clamp(Input.GetAxis("Vertical" + player.playerNumber), -1, 0);

		MoveForward();

		wheelRL.motorTorque = motorMax * motor;
		wheelRR.motorTorque = motorMax * motor;
		wheelRL.brakeTorque = brakeMax * brake;
		wheelRR.brakeTorque = brakeMax * brake;
		wheelFL.steerAngle = steerMax * steer;
		wheelFR.steerAngle = steerMax * steer;
	}

	public void MoveForward()
	{
		if (Input.GetAxis ("Forward0") != 0f)
		{
			//print ("herro");
			wheelFL.motorTorque = motorMax * Input.GetAxis ("Forward0");
			wheelFR.motorTorque = motorMax * Input.GetAxis ("Forward0");
			print (motorMax * Input.GetAxis("Forward0"));
		}
	}
}
