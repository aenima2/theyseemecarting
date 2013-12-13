using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Replicant : MonoBehaviour {

	public GameObject clonedObject;
	public GameObject waypointContainer;
	public List<Transform> wayPoints;
	public int currentWaypoint;


	void Awake(){

		waypointContainer = GameObject.Find("WaypointContainer");
		GetWayPoints ();
	}
	void Start () {

	}

	void Update () {
		NavigateTorwardsWaypoint();
	}

	public Vector3 ClonePosition(){
		return transform.position;
	}

	void GetWayPoints(){

		Transform[] tempWaypoint = waypointContainer.GetComponentsInChildren <Transform>();
		
		wayPoints = new List<Transform>();
		
		wayPoints.AddRange (tempWaypoint); 
		wayPoints.Remove (waypointContainer.transform); 
	
	}

	void NavigateTorwardsWaypoint(){
	
		float relativeXPos = wayPoints[currentWaypoint].position.x;
		float relativeZPos = wayPoints[currentWaypoint].position.z;

		Vector3 relativeWaypointPos;

		relativeWaypointPos = transform.InverseTransformPoint(relativeXPos, transform.position.y, relativeZPos);
	
//
//		inputSteer = relativeWaypointPos.x/relativeWaypointPos.magnitude;

		//Vector3 RelativeWaypointPos = transform.InverseTransformPoint(Vector3(wayPoints[currentWaypoints]

		//Vector3 currentPos = transform.position;
		Quaternion rotation = Quaternion.LookRotation(wayPoints[currentWaypoint].position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);

		transform.Translate (0,0, Time.deltaTime * 20f);

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Waypoint"){
		currentWaypoint++;

			if (currentWaypoint >= wayPoints.Count){
			currentWaypoint = 0;
		}

		}
	}
	
}
