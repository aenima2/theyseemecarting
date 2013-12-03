using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControls : MonoBehaviour {
	

	public Color color;
	
	public KeyCode forwardKey;
	public KeyCode backKey;
	public KeyCode leftKey;
	public KeyCode rightKey;
	public KeyCode shootKey;
	
	//Camera
	public float CamX;
	public float CamP;

	public Vehicle vehicle;


	
	
	
	void Start () {
		

	}
	
	void Update(){
 

		
		//all key-codes
		vehicle = vehicle.GetComponent<Vehicle>();
		vehicle.backInput = backKey;
		vehicle.forwardInput = forwardKey;
		vehicle.leftInput = leftKey;
		vehicle.rightInput = rightKey;
		vehicle.shootInput = shootKey;

		
		
		Camera vecCam = vehicle.GetComponentInChildren<Camera>();	
		vecCam.rect = new Rect(CamX, 0f, CamP, 1f);
	}
	

	
}
	

	
