using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

	public float speed;
	public float speedRotation;
	
	public Vector3 gravityVel = Vector3.zero;
	
	public KeyCode forwardInput;
	public KeyCode backInput;
	public KeyCode leftInput;
	public KeyCode rightInput;
	public KeyCode shootInput;
	

	public float acc;
	
	Vector3 vel;
	
	public float velDamp;

		
	
	
	
	void Update (){
		
		if(Input.GetKeyDown(shootInput)){
		}
		
		
		//get the vehicle to move forward and backward by pressing keys
		//Vector3 vel = Vector3.zero; 
		
		if (Input.GetKey (forwardInput) ) {
			vel += transform.forward * acc;
		}
		
		if (Input.GetKey (backInput) ) {
			vel -= transform.forward * acc;  
		}
	
		
		
		
		vel *= Mathf.Pow(velDamp, Time.deltaTime);
		////moves the vehicle in the direction & velocity spedified by vel, rotation of the 
		rigidbody.velocity = (vel * Time.deltaTime * speed);
		
		
		if (Input.GetKey (leftInput) ) {
			transform.Rotate(0f, -speedRotation * Time.deltaTime, 0f);
		} else if(Input.GetKey (rightInput) ) {
			transform.Rotate(0f, speedRotation * Time.deltaTime, 0f);
		} else {
			transform.Rotate(0f, 0f, 0f);
		}
		
	}
	
	
	
}
