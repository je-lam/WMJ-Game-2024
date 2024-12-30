using UnityEngine;

public class CharaMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    const float DEF_SPEED = 2f;
    const float DASH_SPEED = 5f;

    const string POLARITY = "SOUTH";

    CircleCollider2D magneticField;

    float currSpeed;

    float inputX;
    float inputY;
    // -1 means pressing DOWN, 1 means pressing UP

    public bool holdDownForMagnet; //this should later be handled by game manager
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        print("hello world");
        currSpeed = DASH_SPEED;
        magneticField = GetComponentInChildren<CircleCollider2D>();
        holdDownForMagnet = true;
    }

    void Update()
    {
        UpdateMoveInputs();
        Vector2 moveDirection = new Vector2(inputX * currSpeed, 0);
        if (inputX != 0)
        {
            MoveHoriz(moveDirection);
        }
        HandleMagnet();
    }

    public void UpdateMoveInputs()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }

    void MoveHoriz(Vector2 dir)
    {
        rb.linearVelocityX = dir.x * currSpeed;
    }

    void HandleMagnet()
    {
        if (holdDownForMagnet == true)
        {
            if (Input.GetKey(KeyCode.C))
            {
                magneticField.enabled = true;
            }
            else
            {
                if (magneticField.enabled == true)
                {
                    magneticField.enabled = false;
                }
            }
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                magneticField.enabled = !magneticField.enabled;
                print("toggling magnet");
            }

        }
    }
}
