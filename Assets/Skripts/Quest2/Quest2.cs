using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Quest2 : MonoBehaviour {
	public Transform player;
	public GameObject questBox01;
	public GameObject questBox02;
	public GameObject questBox03;
	public GameObject questBox04;
	public GameObject questBox05;
	public static bool getgift = false;
	public static int check = 0;

	private float distance;
	private float interactRange = 2.5f;
	private GameObject freezePlayer;
	private GameObject npcCollider;
	private GameObject spawnItem1;


	// Use this for initialization
	void Start () {
		freezePlayer = GameObject.Find ("Player");
			freezePlayer.GetComponent <FirstPersonController>();
		npcCollider = GameObject.Find ("QuestNPC2");
			npcCollider.GetComponent<CapsuleCollider>();
		spawnItem1 = GameObject.Find("GiftItem1");
			spawnItem1.GetComponent<MeshRenderer>();
	}

	void Update () {
		if(OVRInput.GetDown(OVRInput.Button.One)){OnMouseDown();}
	}

	public void OnMouseDown(){
		distance = Vector3.Distance(player.position, transform.position);
		if (check == 0 && distance < interactRange) {
			check = 0;
			questBox01.SetActive (true);

			freezePlayer.GetComponent <FirstPersonController> ().enabled = false;
			npcCollider.GetComponent<CapsuleCollider> ().enabled = false;

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		if (check == 1 && distance < interactRange)
		{
			questBox03.SetActive(true);

			freezePlayer.GetComponent <FirstPersonController> ().enabled = false;
			npcCollider.GetComponent<CapsuleCollider> ().enabled = false;

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		if (check == 2 && distance < interactRange)
		{
			questBox05.SetActive(true);

			freezePlayer.GetComponent <FirstPersonController> ().enabled = false;
			npcCollider.GetComponent<CapsuleCollider> ().enabled = false;

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void Helfen(){
		questBox01.SetActive (false);
		questBox02.SetActive (true);
	}

	public void Annehmen(){
		check = 1;
		questBox02.SetActive(false);

		freezePlayer.GetComponent <FirstPersonController> ().enabled = true;
		npcCollider.GetComponent<CapsuleCollider> ().enabled = true;

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		spawnItem1.GetComponent<MeshRenderer>().enabled = true;
	}

	public void Abschliessen(){
		if (getgift == true)
		{
			check = 2;
			questBox03.SetActive(false);
			questBox04.SetActive(true);

			freezePlayer.GetComponent <FirstPersonController> ().enabled = false;
			npcCollider.GetComponent<CapsuleCollider> ().enabled = false;

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void Close ()
	{
		questBox01.SetActive(false);
		questBox02.SetActive(false);
		questBox03.SetActive(false);
		questBox04.SetActive(false);
		questBox05.SetActive(false);

		freezePlayer.GetComponent <FirstPersonController> ().enabled = true;
		npcCollider.GetComponent<CapsuleCollider> ().enabled = true;

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
}