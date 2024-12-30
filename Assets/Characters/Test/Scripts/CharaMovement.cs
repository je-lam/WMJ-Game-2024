using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    const float DEF_SPEED = 2f;
    const float DASH_SPEED = 6.5f;
    CircleCollider2D magneticField;

    float currSpeed;

    float inputX;
    float inputY;
    // -1 means pressing DOWN, 1 means pressing UP

    public const string PENGUIN = "penguin";
    [SerializeField]
    PhysicsMaterial2D penguinMaterial;
    public const string BEAR = "bear";
    [SerializeField]
    PhysicsMaterial2D bearMaterial;
    float rotationZ;
    public string activeCharacter;

    Animator activeAnimator;

    public bool holdDownForMagnet; //this should later be handled by game manager

    [SerializeField]
    SpriteRenderer inactiveBear;

    [SerializeField]
    SpriteRenderer iPenguinRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeCharacter = PENGUIN;
        currSpeed = DASH_SPEED;
        magneticField = GetComponentInChildren<CircleCollider2D>();
        activeAnimator = GetComponent<Animator>();

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
        HandleSwapping();
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
            if (activeCharacter.Equals(PENGUIN))
            {
                SwapToBear();
            }
            else
            {
                SwapToPenguin();
            }
        }
    }

    void SwapToBear()
    {
        SwapToBearAnimation();
        rb.sharedMaterial = bearMaterial;
        activeCharacter = BEAR;

        inactiveBear.enabled = false;
        iPenguinRenderer.enabled = true;
    }

    void SwapToPenguin()
    {
        SwapToPenguinAnimation();
        rb.sharedMaterial = penguinMaterial;
        activeCharacter = PENGUIN;

        inactiveBear.enabled = true;
        iPenguinRenderer.enabled = false;
    }


    void SwapToBearAnimation()
    {
        activeAnimator.Play("BearAct");
    }

    void SwapToPenguinAnimation()
    {
        activeAnimator.Play("PenguinAct");
    }

    void SwapToNorthPolarity()
    {

    }

    void SwapToSouthPolarity()
    {

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
