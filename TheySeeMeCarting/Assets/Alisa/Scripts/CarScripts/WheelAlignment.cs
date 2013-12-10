using UnityEngine;
using System.Collections;

public class WheelAlignment : MonoBehaviour {

	public WheelCollider currentWheelCollider;
	public GameObject slipPrefab;

	public float rotationValue = 0f;
	
	void Start () {

		RaycastHit hit;
		Vector3 colliderCenterPoint = currentWheelCollider.transform.TransformPoint (currentWheelCollider.center);


		if (Physics.Raycast (colliderCenterPoint, -currentWheelCollider.transform.up, out hit, (currentWheelCollider.suspensionDistance + currentWheelCollider.radius))){
			transform.position = hit.point + (currentWheelCollider.transform.up * currentWheelCollider.radius);
		}else{
			transform.position = colliderCenterPoint - (currentWheelCollider.transform.up * currentWheelCollider.suspensionDistance);

		}

		transform.rotation = currentWheelCollider.transform.rotation * Quaternion.Euler(rotationValue, currentWheelCollider.steerAngle, 0f);

		rotationValue += currentWheelCollider.rpm * (360/60) * Time.deltaTime;

//		WheelHit currentGroundHit;
//		currentWheelCollider.GetGroundHit(currentGroundHit);
//
//		if (Mathf.Abs (currentGroundHit.sidewaysSlip)>1.5){
//			if (slipPrefab){ 
//				Instantiate (slipPrefab, currentGroundHit.point, Quaternion.identity);
//
//			}
//		}
	
	}

	void Update () {
	
	}
}
