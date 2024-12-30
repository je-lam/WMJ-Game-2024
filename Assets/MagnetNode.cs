using System.Drawing;
using UnityEngine;

public class MagnetNode : MonoBehaviour
{

    PointEffector2D magField;

    PointEffector2D[] magFields;
    SpriteRenderer nodeSpriteRenderer;

    UnityEngine.Color originalColor;
    void Start()
    {
        magFields = GetComponentsInChildren<PointEffector2D>();
        nodeSpriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = nodeSpriteRenderer.color;
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

            nodeSpriteRenderer.color = UnityEngine.Color.gray;
        }
        else
        {
            print("grabbing");
        }
    }
}
