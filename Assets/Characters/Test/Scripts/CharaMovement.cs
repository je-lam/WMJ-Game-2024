using UnityEngine;
using UnityEngine.InputSystem;

public class CharaMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    const float DEF_SPEED = 2f;
    const float DASH_SPEED = 6.5f;

    const string POLARITY = "SOUTH";

    CircleCollider2D magneticField;

    float currSpeed;

    float inputX;
    float inputY;
    // -1 means pressing DOWN, 1 means pressing UP

    const string PENGUIN = "penguin";
    float rotZ;
    const string BEAR = "bear";
    float rotationZ;
    string activeCharacter;

    public bool holdDownForMagnet; //this should later be handled by game manager
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeCharacter = PENGUIN;
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

    private void FixedUpdate()
    {
        if (activeCharacter.Equals(PENGUIN))
        {
            LimitPenguinRotation();
        }
    }

    void LimitPenguinRotation()
    {
        rotationZ = Mathf.Clamp(transform.localRotation.z, -90, 90);
        transform.localRotation = Quaternion.Euler(rotationZ, 0, 0);
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


    void HandleSwapping()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

        }
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
