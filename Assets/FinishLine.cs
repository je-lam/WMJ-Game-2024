using UnityEngine;

public class FinishLine : MonoBehaviour
{

    public StopWatch stopwatch;
    [SerializeField] GameObject winScreen;
    private void OnTriggerEnter2D(Collider2D other)
    {
        winScreen.SetActive(true);
        if (stopwatch != null) 
        {
            stopwatch.EndWatch();
        }
        print("finishing");
    }
}
