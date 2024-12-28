using System.Drawing;
using UnityEngine;

public class MagnetNode : MonoBehaviour
{
    public string polarity;

    PointEffector2D magField;
    SpriteRenderer nodeSpriteRenderer;
    void Start()
    {
        magField = GetComponent<PointEffector2D>();
        nodeSpriteRenderer = GetComponent<SpriteRenderer>();
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
