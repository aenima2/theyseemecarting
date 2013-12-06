using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {


	public int playerNum;

	public float speed;
	public float speedRotation;
	
	public Vector3 gravityVel = Vector3.zero;


	//public float boostSpeed2;
	

	public float acc;
	public float accBack;
	
	Vector3 vel;
	
	public float velDamp;

		
	
	
	
	void Update ()
	{
		if(Input.GetButtonDown ("Fire" + playerNum))
		{
			Fire();
		}

		if(Input.GetButtonDown ("Jump" + playerNum))
		{
			Jump();
		}

		vel *= Mathf.Pow(velDamp, Time.deltaTime);
		rigidbody.velocity = (vel * Time.deltaTime * speed);
		
		MoveForward();
		MoveBack();

		// D-pad test
		if (Input.GetAxis ("Shuffle" + playerNum) > 0f){

			Debug.Log ("shuffle");
			
		}


		//rigidbody.velocity = (vel * Time.deltaTime * speedBack);
		//vel -= transform.forward * acc * Input.GetAxis ("Back" + playerNum);

		//Debug.Log(Input.GetAxis ("Horizontal" + playerNum));
	
		/*//boost
		if (Input.GetKeyDown (boostInput) ) {
			boostSpeed2 = 5f;
			
		}
		
		if (Input.GetKeyUp (boostInput) ) {
			boostSpeed2 = 1f;
			
		} */
		
		transform.Rotate(0f, speedRotation * Time.deltaTime * Input.GetAxis ("Horizontal" + playerNum), 0f);
	}

	public void MoveForward()
	{
		vel += transform.forward * acc * Input.GetAxis ("Forward" + playerNum);
		Debug.Log(Input.GetAxis ("Horizontal" + playerNum));
	}

	public void MoveBack()
	{
		vel -= transform.forward * accBack * Input.GetAxis ("Back" + playerNum);
	}

	public void Fire()
	{
		print ("fire");
	}

	public void Jump()
	{
		print ("jump");
	}
}