using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
            Debug.Log($"dead.");
            SceneManager.LoadScene("Death");
    }
}
