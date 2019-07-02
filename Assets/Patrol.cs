using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : StateMachineBehaviour {

	GameObject NPC;
	GameObject[] waypoints;
	int currentWp;

	void Awake()
	{
		waypoints = GameObject.FindGameObjectsWithTag ("waypoint");
	}

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		NPC = animator.gameObject;
		currentWp = 0;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		if (waypoints.Length == 0)
			return;
		if (Vector3.Distance (waypoints [currentWp].transform.position,
			NPC.transform.position) < 3.0f) {
			currentWp++;
			if (currentWp >= waypoints.Length) { 
				currentWp = 0;
			}
		}

		var direction = waypoints [currentWp].transform.position - NPC.transform.position;
		NPC.transform.rotation = Quaternion.Slerp (NPC.transform.rotation,
			Quaternion.LookRotation (direction),
			1.0f * Time.deltaTime);
		NPC.transform.Translate (0, 0, Time.deltaTime * 2.0f);
	}


	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
