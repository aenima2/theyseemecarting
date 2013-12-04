using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Clone : MonoBehaviour {

	public GameObject waypointContainer;
	public List<Transform> wayPoints;
	
	void Start () {
		Debug.Log (ClonePosition ());
		GetWayPoints();
	}

	void Update () {
	
	}

	public Vector3 ClonePosition(){
		return transform.position;
	}

	void GetWayPoints(){

		Transform[] tempWaypoint = waypointContainer.GetComponentsInChildren <Transform>();
		
		wayPoints = new List<Transform>();
		
		wayPoints.AddRange (tempWaypoint); //transfer object from array to list
		wayPoints.Remove (waypointContainer.transform); //remove the transform of this object

	}
}
