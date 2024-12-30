using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public void retryGame(){

        if (SceneManager.GetActiveScene().name == "North pole test")
        {
            Debug.Log($"retrying.");
            SceneManager.LoadScene("North pole test");
        }
        else
        {
            Debug.Log($"retrying south pole?");
            SceneManager.LoadScene("South pole test");
        }

    }

    public void toLevelSelect()
    {
        SceneManager.LoadScene("South pole test");
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }

}
