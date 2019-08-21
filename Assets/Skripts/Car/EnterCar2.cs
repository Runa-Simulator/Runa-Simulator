using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class EnterCar2 : MonoBehaviour {

	public Transform player;
	public Transform carCamera;
	public Text carText;

	private int enterRange = 3;
	private float distance;
	private CarDrive controllerCar;
	private CarUserControl carUserCtrl;
	private CarAudio audioCar;
	private AudioSource carAudioSource;
	private bool isInCar = false;

	// Use this for initialization
	void Start () {
		carCamera.gameObject.SetActive (false);
		controllerCar = (CarDrive) GetComponent("CarController");
		carUserCtrl = (CarUserControl) GetComponent("CarUserControl");
		audioCar = (CarAudio) GetComponent("CarAudio");
		carAudioSource = (AudioSource) GetComponent("AudioSource");
	}
	
	// Update is called once per frame
	void Update () {
		if(OVRInput.GetDown(OVRInput.Button.One)){OnMouseDown();}
		distance = Vector3.Distance (player.position, transform.position);
		if(distance < enterRange && isInCar == false){
			carText.gameObject.SetActive(true);
		} else {
			carText.gameObject.SetActive(false);
		}
		if(OVRInput.GetDown(OVRInput.Button.Two) && isInCar == true)
		//if(Input.GetKeyDown(KeyCode.E) && isInCar == true)
		{
			ExitCar ();
		}
	}


	public void ExitCar(){
		isInCar = false;
		player.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 3);

		player.gameObject.SetActive (true);
		carCamera.gameObject.SetActive (false);

		controllerCar.enabled = false;
		carUserCtrl.enabled = false;
		audioCar.enabled = false;
		carAudioSource.enabled = false;
	}


	public void OnMouseDown(){
		if (distance < enterRange) {
			isInCar = true;

			player.gameObject.SetActive (false);
			carCamera.gameObject.SetActive (true);

			controllerCar.enabled = true;
			carUserCtrl.enabled = true;
			audioCar.enabled = true;
			carAudioSource.enabled = true;
		}
	}
}
