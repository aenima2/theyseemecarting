using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	static Waypoint start;
	public GameObject nextPoint;

	public bool isStart;

	void Awake(){
		if (isStart){
			start = this;
		}
	}
	void Start () {

	}

	void Update () {
	
	}

//	public Vector3 CalcTargetPosition(){
//
//		if (Vector3.Distance (transform.position, position) < 6){
//			return nextPoint.transform.position;
//		}
//	}

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawCube (transform.position, new Vector3(5f,5f,5f));

		if (nextPoint){
			Gizmos.color = Color.green;
			Gizmos.DrawLine (transform.position, nextPoint.transform.position);
		}
	}

}
