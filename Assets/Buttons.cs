using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

	public OVRInput.Button ovrbtn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(OVRInput.GetDown(ovrbtn)){GetComponent<Button>().onClick.Invoke ();}
	}
}
