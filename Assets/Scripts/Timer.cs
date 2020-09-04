using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public GameObject player;
    public TextMeshProUGUI timer;
    public float timeRemaining = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    void startTimer()
    {
        Debug.Log("Got here to Timer");
        enabled = true;
    }

    void stopTimer()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timer.SetText(((int)timeRemaining).ToString());
        }
        else
        {

            timer.SetText("0");
            player.SendMessage("lostGame");
        }
    }
}
