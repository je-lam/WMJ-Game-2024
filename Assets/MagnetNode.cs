using System.Drawing;
using UnityEngine;

public class MagnetNode : MonoBehaviour
{

    PointEffector2D magField;
    SpriteRenderer nodeSpriteRenderer;

    UnityEngine.Color originalColor;
    void Start()
    {
        magField = GetComponent<PointEffector2D>();
        nodeSpriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = nodeSpriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            print("Collided!");
            magField.enabled = false;
            nodeSpriteRenderer.color = UnityEngine.Color.gray;
        }
        else
        {
            print("grabbing");
        }
    }
}
