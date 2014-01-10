using UnityEngine;
using System.Collections;

public class VehicleScriptOld : MonoBehaviour {		
		
	public WheelCollider wheelFL;
	public WheelCollider wheelFR;
	public WheelCollider wheelRL;
	public WheelCollider wheelRR;
	
	public float steerMax;
	public float motorMax;
	public float brakeMax;

	public float steer;
	public float motor;
	public float brake;


	private Player player;

		
	void Start()
	{
		player = FindObjectOfType<Player>();
		//rigidbody.centerOfMass += new Vector3(0f, 0f, -1f);
	}
	
	
	void FixedUpdate()
	{
		steer = Mathf.Clamp(Input.GetAxis("Horizontal0"), -1, 1);
		motor = Mathf.Clamp(Input.GetAxis("Forward0"), 0, 1);
		brake = -1 * Mathf.Clamp(Input.GetAxis("Back0"), -1, 0);

		wheelRL.motorTorque = motorMax * motor;
		wheelRR.motorTorque = motorMax * motor;

		print ("speed " + motorMax * motor);

		wheelRL.brakeTorque = brakeMax * brake;
		wheelRR.brakeTorque = brakeMax * brake;

		wheelFL.steerAngle = steerMax * steer;
		wheelFR.steerAngle = steerMax * steer;
	}

	/*
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
	*/
}
