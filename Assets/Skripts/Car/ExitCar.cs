/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;


public class ExitCar : MonoBehaviour {

	public Transform player;
	public Transform carCamera;

	private CarController controllerCar;
	private CarUserControl carUserCtrl;
	private CarAudio audioCar;
	private AudioSource carAudioSource;


	// Use this for initialization
	void Start () {
		carCamera.gameObject.SetActive (false);
		controllerCar = (CarController) GetComponent("CarController");
		carUserCtrl = (CarUserControl) GetComponent("CarUserControl");
		audioCar = (CarAudio) GetComponent("CarAudio");
		carAudioSource = (AudioSource) GetComponent("AudioSource");
	}
	
	// Update is called once per frame
	void Update () {
		if(OVRInput.GetDown(OVRInput.Button.Two)){exitCar();}
	}

	public void exitCar(){
		EnterCar2.isInCar = false;
		player.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 3);

		player.gameObject.SetActive (true);
		carCamera.gameObject.SetActive (false);

		controllerCar.enabled = false;
		carUserCtrl.enabled = false;
		audioCar.enabled = false;
		carAudioSource.enabled = false;
	}
}
*/