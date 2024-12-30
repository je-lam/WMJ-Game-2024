using System;
using TMPro;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    bool watchActive = false;
    float currTime;
    public TextMeshProUGUI currTimeText;
    public TextMeshProUGUI customMessageText; // Add a reference to a TextMeshProUGUI for the message

    void Start()
    {
        currTime = 0;
        StartWatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (watchActive)
        {
            currTime += Time.deltaTime;
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

        // Check the time and display a custom message
        string message = GetCustomMessage(currTime);
        customMessageText.text = message;
    }

    private string GetCustomMessage(float time)
    {
        if (time < 10f)
        {
            return "God of Speed!";
        }
        else if (time < 15f)
        {
            return "Legendary Speed!";
        }
        else if (time < 40f)
        {
            return "Impressive Speed!";
        }
        else if (time < 50f)
        {
            return "Can be Speedier!";
        }
        else
        {
            return "Not Speedy Enough!";
        }
    }
}
