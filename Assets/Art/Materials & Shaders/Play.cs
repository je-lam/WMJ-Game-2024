using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    public void playGame(){
        SceneManager.LoadScene("2D_BaseScene");
        }
}
