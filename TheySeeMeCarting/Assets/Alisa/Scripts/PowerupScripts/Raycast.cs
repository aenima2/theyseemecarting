using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

	public RaycastHit hit;
	
	public GameObject caster;

	public float rotDegree;

	public float rayLength;

	void Start () {
	
	}


	void Update () {
	
	}
				
	public void RayCast(){

		for (int i = 0; i < 361; i++) {
			
			Vector3 rayDirection = transform.forward;
			transform.Rotate (0f, rotDegree, 0f);
			
			if (Physics.Raycast(transform.position, rayDirection, out hit, rayLength)){

				if (hit.collider.gameObject.tag == "Player"){

					VehicleScript vehicle = hit.collider.gameObject.GetComponent<VehicleScript>();
					Rigidbody playerRB = hit.collider.gameObject.GetComponent<Rigidbody>();

					playerRB.AddExplosionForce(300f, transform.position, 20f); 

					vehicle.CalcLife();
					break;

				}
			}

		}
	}
}
