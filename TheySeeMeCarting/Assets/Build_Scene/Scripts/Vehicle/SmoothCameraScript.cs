using UnityEngine;
using System.Collections;

public class SmoothCameraScript : MonoBehaviour {

	
	public Transform target; // The target we are following

	public float distance; // The distance in the x-z plane to the target
	public float height; // The height we want the camera to be above the target
	public float heightDamping; // Delay height
	public float rotationDamping; // Delay rotation
	
	// Place the script in the Camera-Control group in the component menu
	[AddComponentMenu("Camera-Control/Smooth Follow")]

	void LateUpdate ()
	{
		if (!target) // Early out if there's no target
			return;
		
		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;
		
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;
		
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		
		// Damp the height
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		
		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

		// Set the position of the camera on the x-z plane to:
		// distance (meters) behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
		
		// Set the height of the camera
		transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

		// Always look at the target
		transform.LookAt (target);
	}
}
