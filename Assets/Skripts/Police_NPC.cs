using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Police_NPC : MonoBehaviour 
{
	[SerializeField]
	public Transform target;
	NavMeshAgent agent;

	void Start () 
	{
		agent = this.GetComponent<NavMeshAgent> ();
		agent.destination = target.position;

		if (agent == null) {
			Debug.LogError ("The nav mesh agent component ist not attached to" );
		} else {
			SetDestination ();
		}
	}

	private void SetDestination ()
	{
		if (target != null) {
			Vector3 targetVector = target.transform.position;
			agent.SetDestination (targetVector);
		}
	}
}

