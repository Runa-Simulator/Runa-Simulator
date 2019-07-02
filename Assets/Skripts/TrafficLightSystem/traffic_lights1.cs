using UnityEngine;
using System.Collections;

public class traffic_lights1 : MonoBehaviour
{
	public GameObject red;
	public GameObject yellow;
	public GameObject green;

	private bool toggle = true;
	private Collider boxCol;

	// Use this for initialization
	void Start (){
		StartCoroutine (ToggleLights_1 ());
		boxCol = GetComponent<BoxCollider> ();
	}

	// Update is called once per frame
	void Update (){
		if (red.activeSelf) {
			//Debug.Log ("Ampel leuchtet rot");
			boxCol.enabled = toggle;
			//Debug.Log ("boxCol.enabled: " + boxCol.enabled);

		} else {
			boxCol.enabled = !toggle;
			//Debug.Log ("boxCol.enabled: " + boxCol.enabled);
		}
	}

	IEnumerator ToggleLights_1(){
		while (true) {
			red.gameObject.SetActive (toggle);
			yield return new WaitForSeconds (5.0f);
			yellow.gameObject.SetActive (toggle);
			yield return new WaitForSeconds (2.0f);
			red.gameObject.SetActive (!toggle);
			yellow.gameObject.SetActive (!toggle);
			green.gameObject.SetActive (toggle);
			yield return new WaitForSeconds (5.0f);
			green.gameObject.SetActive (!toggle);
			yellow.gameObject.SetActive (toggle);
			yield return new WaitForSeconds (2.0f);
			yellow.gameObject.SetActive (!toggle);
		}
	}
		
}