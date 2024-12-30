using Unity.Mathematics;
using UnityEngine;

public class PengBalancer2 : MonoBehaviour
{
    [SerializeField]
    Transform track;

    private Transform cachedTransform;
    private Vector3 cachedPosition;
    Animator pengAnimator;
    private string currState;
    Rigidbody2D rb;
    Vector3 worldVelocity;
    Vector3 previousPosition;

    int framesBetweenWpUpdate = 12;
    int currFramesBetween = 0;

    void Start()
    {

        pengAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cachedTransform = GetComponent<Transform>();
        if (track)
        {
            cachedPosition = track.position;
        }



    }

    void Update()
    {
        TrackPosition();
        AnimUpdate();

        if (currFramesBetween >= framesBetweenWpUpdate)
        {
            worldVelocity.x = (transform.position.x - previousPosition.x) / Time.deltaTime;
            previousPosition = transform.position;
            currFramesBetween = 0;
        }
        currFramesBetween++;
    }

    void TrackPosition()
    {
        if (track && cachedPosition != track.position)
        {
            cachedPosition = track.position + new Vector3(0, 1.9f, 0);
            transform.position = cachedPosition + new Vector3(0, 1.9f, 0);
        }
    }

    void AnimUpdate()
    {
        if (math.abs(worldVelocity.x) > 6)
        {
            ChangeAnimState("Balancing");
            print(math.abs(worldVelocity.x));
        }
        else
        {
            ChangeAnimState("Idle_Balance");
        }
    }

    void ChangeAnimState(string newState)
    {
        if (currState == newState)
        {
            return;
        }
        pengAnimator.Play(newState);
        currState = newState;
    }
}
