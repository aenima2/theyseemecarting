using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {


	public int playerNum; 
	public float speed;
	public float speedRotation;
	
	public Vector3 gravityVel = Vector3.zero;
	
	public string forwardInput;
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

		vel += transform.forward * acc * -Input.GetAxis ("Vertical");

		Debug.Log(Input.GetAxis ("Horizontal" + playerNum));
	
		
		
		
		vel *= Mathf.Pow(velDamp, Time.deltaTime);
		////moves the vehicle in the direction & velocity spedified by vel, rotation of the 
		rigidbody.velocity = (vel * Time.deltaTime * speed);
		

		transform.Rotate(0f, -speedRotation * Time.deltaTime * Input.GetAxis ("Horizontal" + playerNum), 0f);
		
	}
	
	
	
}
