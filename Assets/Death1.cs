using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Death1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log($"dead.");
            SceneManager.LoadScene("Death");
    }
}
