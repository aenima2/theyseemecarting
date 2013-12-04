using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControls : MonoBehaviour {
	

	public Color color;

	public KeyCode shootKey;
	public KeyCode boostKey;
	
	//Camera
	public float CamX;
	public float CamP;

	public Vehicle vehicle;


	
	
	
	void Start () {
		

	}
	
	void Update(){
 

		
		//all key-codes
		vehicle = vehicle.GetComponent<Vehicle>();
		//vehicle.boostInput = boostKey;
		vehicle.shootInput = shootKey;

		
		
		Camera vecCam = vehicle.GetComponentInChildren<Camera>();	
		vecCam.rect = new Rect(CamX, 0f, CamP, 1f);
	}
	

	
}
	

	
