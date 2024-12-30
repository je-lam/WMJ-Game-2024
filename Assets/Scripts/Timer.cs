using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    bool timerActive = false;
    float currTime;
    public Text currTimeText;
    public int startMinutes;
    void Start()
    {
        currTime = startMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
        {
            currTime = currTime - Time.deltaTime;
            if (currTime <= 0)
            {
                timerActive = false;
                Start();
                print("timer ended");
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currTime);
        currTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}
