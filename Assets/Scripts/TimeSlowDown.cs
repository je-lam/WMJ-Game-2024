using UnityEngine;

public class TimeSlowdown2D : MonoBehaviour
{
    public float slowTimeScale = 0.1f;
    public float slowdownDuration = 5f;

    private bool isSlowingDown = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the trigger (you can replace "Player" with the appropriate tag).
        if (other.CompareTag("Player") && !isSlowingDown)
        {
            StartCoroutine(SlowDownTime());
            Debug.Log("hi :)");
        }
    }

    private System.Collections.IEnumerator SlowDownTime()
    {
        isSlowingDown = true;

        // Slow down time.
        Time.timeScale = slowTimeScale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale; // Adjust FixedUpdate timing.

        Debug.Log("za warudo!");
        // Wait for the slowdown duration in real-world time.
        yield return new WaitForSecondsRealtime(slowdownDuration);

        // Restore time to normal.
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f; // Restore FixedUpdate timing.

        isSlowingDown = false;
    }
}
