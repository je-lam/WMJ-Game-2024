using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer),typeof(EdgeCollider2D))]

public class FinalTerrain : MonoBehaviour {

    
    Mesh mesh;
    EdgeCollider2D coll;
    public LineRenderer lr;
    [Range(0,15000)]
    public int Xsize;
    public int Ysize;

    public float Amplitude;
    public float frequency;

    public int seed;

    int _seed;

    public float LineOffset = -0.25f; 
   
	void Awake ()
    {
        Generate();
    }

    
    public void Generate ()
    {

        mesh = new Mesh();
        coll = GetComponent<EdgeCollider2D>();
        lr = GetComponent<LineRenderer>();
        GetComponent<MeshFilter>().mesh = mesh;

        if (seed == 0)
        {
            _seed = Random.Range(0,999);
        }
        else
        {
            _seed = seed;
        }




        mesh.vertices = GenerateTerrain.Vertices(Xsize,Ysize,frequency,Amplitude,_seed);
        mesh.triangles = GenerateTerrain.Trinagles(Xsize,Ysize);
        coll.points = GenerateTerrain.Collider(mesh.vertices,Xsize,Ysize);
        TerrainRender.GenerateLineRenderer(mesh.vertices,Ysize,ref lr,LineOffset);
	}
}