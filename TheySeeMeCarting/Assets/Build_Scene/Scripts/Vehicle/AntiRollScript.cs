using UnityEngine;
using System.Collections;

public class AntiRollScript : MonoBehaviour {

	public WheelCollider WheelL;
	public WheelCollider WheelR;

	public float AntiRoll = 5000.0f;


	void FixedUpdate()
	{
		WheelHit hit;
		
		float travelL = 1.0f;
		float travelR = 1.0f;

		bool groundedL = WheelL.GetGroundHit(out hit);
		bool groundedR = WheelR.GetGroundHit(out hit);

		if (groundedL)
		{
			travelL = (-WheelL.transform.InverseTransformPoint (hit.point).y - WheelL.radius) / WheelL.suspensionDistance;
			//print ("grounded L");
		}

		if (groundedR)
		{
			travelR = (-WheelR.transform.InverseTransformPoint (hit.point).y - WheelR.radius) / WheelR.suspensionDistance;
			//print ("grounded R");
		}

		float antiRollForce = (travelL - travelR) * AntiRoll;

		//print (antiRollForce);

		if (groundedL)
		{
			rigidbody.AddForceAtPosition (WheelL.transform.up * -antiRollForce, WheelL.transform.position);
			//print ("antiroll L");
		}

		if (groundedR)
		{
			rigidbody.AddForceAtPosition (WheelR.transform.up * antiRollForce, WheelR.transform.position);
			//print ("antiroll R");
		}
	}
}
