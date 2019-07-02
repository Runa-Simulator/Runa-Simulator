using UnityEngine;
using System.Collections;

public class traffic_lights2 : MonoBehaviour
{
	public GameObject red;
	public GameObject yellow;
	public GameObject green;

	private bool toggle = true;

	// Use this for initialization
	void Start (){
		StartCoroutine (ToggleLights_2 ());
	}

	// Update is called once per frame
	void Update (){
	}

	IEnumerator ToggleLights_2(){
		while (true) {
			green.gameObject.SetActive (toggle);
			yield return new WaitForSeconds (5.0f);
			green.gameObject.SetActive (!toggle);
			yellow.gameObject.SetActive (toggle);
			yield return new WaitForSeconds (2.0f);
			yellow.gameObject.SetActive (!toggle);
			red.gameObject.SetActive (toggle);
			yield return new WaitForSeconds (5.0f);
			yellow.gameObject.SetActive (toggle);
			yield return new WaitForSeconds (2.0f);
			red.gameObject.SetActive (!toggle);
			yellow.gameObject.SetActive (!toggle);
		}
	}
}