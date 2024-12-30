using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Array to hold audio clips
    public AudioClip[] deathClips;
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on this GameObject.");
        }
        if (deathClips == null || deathClips.Length == 0)
        {
            Debug.LogError("Please assign death audio clips in the inspector.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("dead.");

        if (audioSource != null && deathClips.Length > 0)
        {
            // Select a random clip
            int randomIndex = Random.Range(0, deathClips.Length);
            AudioClip selectedClip = deathClips[randomIndex];

            // Play the selected clip
            audioSource.PlayOneShot(selectedClip);
        }

        // Load the death scene after a delay
        StartCoroutine(LoadDeathSceneAfterDelay());
    }

    private IEnumerator LoadDeathSceneAfterDelay()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);


        // Load the Death scene
        SceneManager.LoadScene("Death");
    }
}
