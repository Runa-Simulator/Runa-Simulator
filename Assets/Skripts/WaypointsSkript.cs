/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointsSkript : MonoBehaviour {

	NavMeshAgent boat;

	public Transform[] Waypoints;
	public int cur_loc;
	public float stop_distance;

	void Start () 
	{
		boat = GetComponent<NavMeshAgent> ();
		boat.stoppingDistance = stop_distance;
	}

	void Update () 
	{
		float distance = Vector3.Distance (transform.position, Waypoints [cur_loc].position);
		transform.LookAt (Waypoints [cur_loc]);

		if (distance <= stop_distance) {
			cur_loc += 1;
		}

		if (cur_loc >= Waypoints.Length) {
			cur_loc = 0;
		}

		//Location1
		if (cur_loc == 0) {
			boat.SetDestination (Waypoints [0].position);
		}

		//Location2
		if (cur_loc == 1) {
			boat.SetDestination (Waypoints [1].position);
		}

		//Location3
		if (cur_loc == 2) {
			boat.SetDestination (Waypoints [2].position);
		}
	}
}*/
