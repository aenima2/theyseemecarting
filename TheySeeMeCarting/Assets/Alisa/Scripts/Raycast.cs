using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

	public RaycastHit hit;
	
	public GameObject bomb;

	public float rotDegree;

	public bool done;

	void Start () {
	
	}

	void Update () {
	
		//if (!done){
		//RayCast ();
		//}
	}

//		for (int i = 0; i < 10; i++) {
//		
//			Quaternion q = Quaternion.AngleAxis(delta_degree, Vector3.forward);
//			Vector3 direction = Vector3.up;
//
//				direction = q * direction;
//
//				
	public void RayCast(){

		for (int i = 0; i < 361; i++) {
			
			if (i >= 359){
				done = true;
			}
			
			Vector3 rayDirection = transform.forward;
			transform.Rotate (0f, rotDegree, 0f);
			
			if (Physics.Raycast(transform.position, rayDirection, out hit, 20f)){

				if (hit.collider.gameObject.tag == "Player"){

					done = true;
					VehicleTest player = hit.collider.gameObject.GetComponent<VehicleTest>();
					player.CalcLife();
					break;

				}
				Debug.Log("Raycast collision"+ hit.collider.name);
				
				Debug.DrawLine (transform.position, hit.point);
			}

		}
	}
}
