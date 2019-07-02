using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class detectOther : MonoBehaviour {

	public NavMeshAgent agent;

	private bool toggle =  true;


	// Use this for initialization
	void Start () {
		agent = GetComponentInParent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Vehicle") {
			Debug.Log ("Halt");
			agent.enabled = !toggle;


		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Vehicle") {
			Debug.Log ("Weiter");
			agent.enabled = toggle;
		}
	}
}
