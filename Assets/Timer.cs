using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public GameObject Zeitanzeige;
    TextMesh zeitanzeige;
    public GameObject Rundenanzeige;
    TextMesh rundenanzeige;
    private float startTime;
    private bool start = false;
    private float t = 0;
    private int lap = 0;
    string minutes;
    string seconds;


    // Use this for initialization
    void Start()
    {
        zeitanzeige = Zeitanzeige.GetComponent<TextMesh>();
        rundenanzeige = Rundenanzeige.GetComponent<TextMesh>();
    }

    //Update is called once per frame

    // Wenn das Auto über die Linie fährt
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StartZiel")
        {
            switch (lap)
            {
                // Bei der ersten Durchfahrt bei Rennbeginn wird die Zeit gestartet und die erste Runde beginnt.
                case 0:
                    lap++;
                    start = true;
                    startTime = Time.time;
                    break;
                // nach der letzten Runde wird die Zeit angehalten und in gelber Schrift angezeigt. 
                case 2:
                    start = false;

                    zeitanzeige.color = Color.yellow;

                    minutes = ((int)t / 60).ToString();
                    seconds = (t % 60).ToString("f2");

                    zeitanzeige.text = minutes + " : " + seconds;
                    break;
                // Wenn die maximale Rundenzahl noch nicht erreicht ist, wird bei Durchfahrt der Start/Ziellinie einfach nur die Rundenzahl erhöht.
                default:
                    lap++;
                    break;
            }
        }
    }
    void Update()
    {
        rundenanzeige.text = "Runde " + lap + "/2";              // Rundenanzeiger bleibt unverändert

        if (start)
        // Während des Rennens wird die Zeit in weiß dargestellt.
        {
            t = Time.time - startTime;
            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f2");

            zeitanzeige.text = minutes + " : " + seconds;
        }
    }
}



