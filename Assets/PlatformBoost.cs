using Unity.VisualScripting;
using UnityEngine;

public class PlatformBoost : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    int bounceForce;

    [SerializeField]
    Vector3 boostDirection;

    private void OnTriggerEnter2D(Collider2D playerMagField)
    {
        if (playerMagField.tag.Equals("PlayerMagnet"))
        {
            print("boosting");
            print(transform.up);
            playerMagField.GetComponentInParent<Rigidbody2D>().AddForce(boostDirection * bounceForce, ForceMode2D.Impulse);
        }
    }
}
