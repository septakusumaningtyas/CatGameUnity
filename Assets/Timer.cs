using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer;
    float seconds;
    float minutes;

    [SerializeField] Text timerText;
    
    void Start()
    {
        timer = 0;
    }
    
    void Update()
    {
        TimerWatch();
    }

    void TimerWatch()
    {
        timer += Time.deltaTime;
        seconds = timer % 60;
        minutes = timer / 60;

        timerText.text = minutes.ToString("00") + " : " + seconds.ToString("00");
    }
}
