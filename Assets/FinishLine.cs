using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    GameObject winScreen;
    private void OnTriggerEnter2D(Collider2D other)
    {
        winScreen.SetActive(true);
        print("finishing");
    }
}
