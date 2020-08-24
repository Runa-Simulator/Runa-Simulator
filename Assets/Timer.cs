using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public GameObject Zeitanzeige; 
    TextMesh zeitanzeige;
    private float startTime;
    private bool start = false;
    private float penaltyTime;
    private bool penalty = false;
    private float t = 0;
    string minutes;
    string seconds;
    string p_minutes;
    string p_seconds;


	// Use this for initialization
	void Start () {
        zeitanzeige = Zeitanzeige.GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        
        
        if (start)
        {
            t = Time.time - startTime;
            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f2");

            zeitanzeige.text = minutes + " : " + seconds;
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
            zeitanzeige.color = Color.yellow;

            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f2");

            zeitanzeige.text = minutes + " : " + seconds;
        }
            
    }
}


