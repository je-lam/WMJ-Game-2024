using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(EdgeCollider2D))]
public class FinalTerrain : MonoBehaviour
{
    Mesh mesh;
    EdgeCollider2D coll;
    public LineRenderer lr;
    [Range(0, 15000)]
    public int Xsize;
    public int Ysize;

    public float Amplitude;
    public float frequency;

    public int seed;

    int _seed;

    public float LineOffset = -0.25f;

    void Awake()
    {
        Generate();
    }

    public void Generate()
    {
        mesh = new Mesh();
        coll = GetComponent<EdgeCollider2D>();
        lr = GetComponent<LineRenderer>();
        GetComponent<MeshFilter>().mesh = mesh;

        if (seed == 0)
        {
            _seed = Random.Range(0, 999);
        }
        else
        {
            _seed = seed;
        }

        Vector3[] vertices = GenerateTerrain.Vertices(Xsize, Ysize, frequency, Amplitude, _seed);
        mesh.vertices = vertices;
        mesh.triangles = GenerateTerrain.Trinagles(Xsize, Ysize);
        mesh.RecalculateNormals(); // Optional: Ensures lighting works properly

        coll.points = GenerateTerrain.Collider(mesh.vertices, Xsize, Ysize);
        UpdateColliderPosition();

        TerrainRender.GenerateLineRenderer(mesh.vertices, Ysize, ref lr, LineOffset);
        UpdateLineRendererPosition();
    }

    void UpdateColliderPosition()
    {
        // Adjust collider points based on GameObject's position
        Vector2 offset = transform.position;
        Vector2[] colliderPoints = coll.points;
        for (int i = 0; i < colliderPoints.Length; i++)
        {
            colliderPoints[i] += offset;
        }
        coll.points = colliderPoints;
    }

    void UpdateLineRendererPosition()
    {
        // Adjust line renderer to follow GameObject's position if necessary
        if (lr.useWorldSpace)
        {
            for (int i = 0; i < lr.positionCount; i++)
            {
                lr.SetPosition(i, lr.GetPosition(i) + transform.position);
            }
        }
    }

    void OnValidate()
    {
        // Ensure Generate() runs when parameters change in the Editor
        if (Application.isPlaying)
        {
            Generate();
        }
    }
}
