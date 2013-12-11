using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

	public RaycastHit hit;
	
	public GameObject caster;

	public float rotDegree;

	public float rayLength;

	public bool done;

	void Start () {
	
	}


	void Update () {
	
		//if (!done){
		//RayCast ();
		//}
	}
				
	public void RayCast(){

		for (int i = 0; i < 361; i++) {
			
			if (i >= 359){
				done = true;
			}
			
			Vector3 rayDirection = transform.forward;
			transform.Rotate (0f, rotDegree, 0f);
			
			if (Physics.Raycast(transform.position, rayDirection, out hit, rayLength)){

				if (hit.collider.gameObject.tag == "Player"){

					done = true;

					Vehicle player = hit.collider.gameObject.GetComponent<Vehicle>();
					Rigidbody playerRB = hit.collider.gameObject.GetComponent<Rigidbody>();

					playerRB.AddExplosionForce(300f, transform.position, 20f); 

					player.CalcLife();
					break;

				}
				Debug.Log("Raycast collision"+ hit.collider.name);
				
				Debug.DrawLine (transform.position, hit.point);
			}

		}
	}
}
