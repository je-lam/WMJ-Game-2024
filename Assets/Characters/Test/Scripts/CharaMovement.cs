using UnityEngine;

public class CharaMovement : MonoBehaviour
{
    const float DEF_SPEED = 20f;
    const float DASH_SPEED = 80f;

    float inputX;
    float inputY;
    void Start()
    {
        print("hello world");
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        if (inputY != 1)
        {
            print("Pressing DOWN key");
        }
    }
}
