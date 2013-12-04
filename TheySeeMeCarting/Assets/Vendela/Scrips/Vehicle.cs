using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {


	public int playerNum; 
	public float speed;
	public float speedRotation;
	
	public Vector3 gravityVel = Vector3.zero;

	public KeyCode shootInput;
	//public KeyCode boostInput;

	//public float boostSpeed2;
	

	public float acc;
	
	Vector3 vel;
	
	public float velDamp;

		
	
	
	
	void Update (){

		if(Input.GetKeyDown(shootInput)){
			Debug.Log ("Fire");
		}
		
		
		//get the vehicle to move forward and backward by pressing keys
		//Vector3 vel = Vector3.zero; 

		//get the vehicle to move backward and forward
		vel += transform.forward * acc * -Input.GetAxis ("Forward" + playerNum);
		vel -= transform.forward * acc * -Input.GetAxis ("Back" + playerNum);

		Debug.Log(Input.GetAxis ("Horizontal" + playerNum));
	
		/*//boost
		if (Input.GetKeyDown (boostInput) ) {
			boostSpeed2 = 5f;
			
		}
		
		if (Input.GetKeyUp (boostInput) ) {
			boostSpeed2 = 1f;
			
		} */
		
		
		vel *= Mathf.Pow(velDamp, Time.deltaTime);
		////moves the vehicle in the direction & velocity spedified by vel, rotation of the 
		rigidbody.velocity = (vel * Time.deltaTime * speed);
		

		transform.Rotate(0f, speedRotation * Time.deltaTime * Input.GetAxis ("Horizontal" + playerNum), 0f);


		
	}
	
	
	
}
