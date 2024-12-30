using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    bool watchActive = false;
    float currTime;
    public TextMeshProUGUI currTimeText;
    void Start()
    {
        currTime = 0;
        StartWatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (watchActive == true)
        {
            currTime = currTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currTime);
        currTimeText.text = time.ToString(@"mm\:ss\:fff");
    }

    public void StartWatch()
    {
        watchActive = true;
    }

    public void EndWatch()
    {
        watchActive = false;
    }
}
