using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Vehicle") {
			Debug.Log ("Object entered the trigger");
		}
	}
		
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Vehicle") {
			Debug.Log ("Weg");
		}
	}

}
