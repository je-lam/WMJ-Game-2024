using System.Drawing;
using UnityEngine;

public class MagnetNode : MonoBehaviour
{


    PointEffector2D[] magFields;
    SpriteRenderer nodeSpriteRenderer;

    [SerializeField]
    Sprite disabledSprite;
    void Start()
    {
        magFields = GetComponentsInChildren<PointEffector2D>();
        nodeSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            print("Collided!");

            // DISABLES BOTH NORTH AND SOUTH!!!!
            for (int i = 0; i < 2; i++)
            {
                magFields[i].enabled = false;
            }

            nodeSpriteRenderer.sprite = disabledSprite;
        }
        else
        {
            print("grabbing");
        }
    }
}
