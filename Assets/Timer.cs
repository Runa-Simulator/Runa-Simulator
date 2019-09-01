using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public GameObject Zeitanzeige;
    public GameObject Strafzeitanzeige;
    TextMesh zeitanzeige;
    TextMesh strafzeitanzeige;
    private float startTime;
    private bool start = false;
    private float penaltyTime;
    private bool penalty = false;
    private float p = 0;
    private float pTotal = 0;
    private float t = 0;
    string minutes;
    string seconds;
    string p_minutes;
    string p_seconds;


	// Use this for initialization
	void Start () {
        zeitanzeige = Zeitanzeige.GetComponent<TextMesh>();
        strafzeitanzeige = Strafzeitanzeige.GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        
        
        if (start)
        {
            t = Time.time - startTime;
            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f2");

            zeitanzeige.text = minutes + " : " + seconds;

            if (penalty)
            {
                p = Time.time - penaltyTime + pTotal;

                // Code doppelt. Könnte noch in eine Funktion mit Parameter (p oder pTotal) ausgelagert/optimiert werden.
                p_minutes = ((int)p / 60).ToString();
                p_seconds = (p % 60).ToString("f2");

                strafzeitanzeige.text = "+ " + p_minutes + " : " + p_seconds;
            } else
            {
                if (p > 0)
                {
                    pTotal = p;
                    p = 0;

                    // Code doppelt. Könnte noch in eine Funktion mit Parameter (p oder pTotal) ausgelagert/optimiert werden.
                    p_minutes = ((int)pTotal / 60).ToString();
                    p_seconds = (pTotal % 60).ToString("f2");

                    strafzeitanzeige.text = "+ " + p_minutes + " : " + p_seconds;
                }
            }

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

            minutes = (((int)t / 60) + ((int)pTotal / 60)).ToString();
            seconds = ((t % 60) + (pTotal % 60)).ToString("f2");

            zeitanzeige.text = minutes + " : " + seconds;
            strafzeitanzeige.text = " ";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // während Auto auf Wasser ist
        if (other.gameObject.CompareTag("Wasser"))
        {

            if (!penalty)
            {
                penalty = true;
                penaltyTime = Time.time;
            }
        } else if (penalty)
        {
            penalty = false;
        }
    }
}


