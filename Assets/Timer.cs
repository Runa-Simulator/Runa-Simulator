using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public GameObject Zeitanzeige;
    TextMesh anzeige;
    private float startTime;
    private bool start = false;

	// Use this for initialization
	void Start () {
        anzeige = Zeitanzeige.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            anzeige.text = minutes + " : " + seconds;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        // wenn Auto durch den Start fährt, Zeit starten.
        if (other.gameObject.CompareTag("RallyStart"))
        {
            start = true;
            startTime = Time.time;
        }

        // Wenn Auto im Zielbereich, Zeit stoppen.
        if (other.gameObject.CompareTag("Ziel"))
        {
            start = false;
            anzeige.color = Color.yellow;
        }
    }
}
