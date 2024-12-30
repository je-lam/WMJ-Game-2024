using UnityEngine;

public class PengBalancer2 : MonoBehaviour
{
    [SerializeField]
    Transform track;

    private Transform cachedTransform;
    private Vector3 cachedPosition;

    void Start()
    {
        cachedTransform = GetComponent<Transform>();
        if (track)
        {
            cachedPosition = track.position;
        }
    }

    void Update()
    {
        TrackPosition();
    }

    void TrackPosition()
    {
        if (track && cachedPosition != track.position)
        {
            cachedPosition = track.position + new Vector3(0, 1.9f, 0);
            transform.position = cachedPosition + new Vector3(0, 1.9f, 0);
        }
    }
}
