using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

using UnityEngine.UI;

public class QuestBoy : MonoBehaviour {

	public GameObject questBoxBoyWait;
	public GameObject questBoxBoyFinish;
	public GameObject questBoxBoy;
	public Transform player;
	public static bool boyHavePizza = false;

	private float distance;
	private float interactRange = 2.5f;
	private GameObject freezePlayer;
	private GameObject boy;
	public bool done = false;

	// Use this for initialization
	void Start () {
		freezePlayer = GameObject.Find ("Player");
			freezePlayer.GetComponent <FirstPersonController>();
		boy = GameObject.Find ("QuestBoy");
			boy.GetComponent<CapsuleCollider>();
	}

	void Update () {
		if(OVRInput.GetDown(OVRInput.Button.One)){OnMouseDown();}
	}
	
	public void OnMouseDown(){
		distance = Vector3.Distance(player.position, transform.position);
		if (Quest.check <= 1 && distance < interactRange) {
			questBoxBoyWait.SetActive (true);

			freezePlayer.GetComponent <FirstPersonController> ().enabled = false;
			boy.GetComponent<CapsuleCollider> ().enabled = false;

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		if (Quest.checkPizza == true && distance < interactRange){
			boyHavePizza = true;

			questBoxBoyWait.SetActive (false);
			questBoxBoyFinish.SetActive(true);

			freezePlayer.GetComponent <FirstPersonController> ().enabled = false;
			boy.GetComponent<CapsuleCollider> ().enabled = false;

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		if (done && distance < interactRange){
			questBoxBoyFinish.SetActive(false);
			questBoxBoy.SetActive(true);

			freezePlayer.GetComponent <FirstPersonController> ().enabled = false;
			boy.GetComponent<CapsuleCollider> ().enabled = false;

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void Abschliessen(){
		if (boyHavePizza == true && distance < interactRange)
		{
			done = true;
			questBoxBoyFinish.SetActive(false);
			questBoxBoy.SetActive(true);

			freezePlayer.GetComponent <FirstPersonController> ().enabled = false;
			boy.GetComponent<CapsuleCollider> ().enabled = false;

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void Close ()
	{
		questBoxBoyWait.SetActive(false);
		questBoxBoyFinish.SetActive(false);
		questBoxBoy.SetActive(false);

		freezePlayer.GetComponent <FirstPersonController> ().enabled = true;
		boy.GetComponent<CapsuleCollider> ().enabled = true;

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	
	}
		
}


