using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem2 : MonoBehaviour {
	public Transform player;
	public GameObject questBoxItem;

	private float distance;
	private float pickUpRange = 2.5f;

	void Update () {
		if(OVRInput.GetDown(OVRInput.Button.One)){OnMouseDown();}
	}

	public void OnMouseDown(){
		distance = Vector3.Distance (player.position, transform.position);
		if (distance < pickUpRange) {
			Quest2.getgift = true;
			questBoxItem.SetActive (true);

			StartCoroutine (Wait ());
			Destroy(gameObject);
			questBoxItem.SetActive(false);
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (3);
	}
}
