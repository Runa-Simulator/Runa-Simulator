using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenu;

	private GameObject freezeMouseLook;
	private bool isPaused = false;

	// Use this for initialization
	void Start () {
		freezeMouseLook = GameObject.Find ("Car");
		freezeMouseLook.GetComponent <CarUserControl>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			isPaused = !isPaused;
			if (isPaused) {
				PauseON ();
			} else {
				PauseOFF ();
			}
		}
	}

	public void PauseON(){
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		pauseMenu.gameObject.SetActive (true);
		Time.timeScale = 0; 						// Pausiert das Spiel
		freezeMouseLook.GetComponent <CarUserControl>().enabled = false;
	}

	public void PauseOFF(){
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		pauseMenu.gameObject.SetActive (false);

		Time.timeScale = 1;							// Spiel läuft wieder
		freezeMouseLook.GetComponent <CarUserControl>().enabled = true;
	}

	public void LoadMainMenu(){
		SceneManager.LoadScene (0);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}