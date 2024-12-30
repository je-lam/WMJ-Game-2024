using UnityEngine;
using System.Collections;
public static class GenerateTerrain
{

    public static Vector3[] Vertices(int Xsize, int Ysize, float frequency, float amplitude, int seed)
    {
        Vector3[] vertices = new Vector3[(Xsize + 1) * (Ysize + 1)];

        int i = 0;

        for (int y = 0; y <= Ysize; y++)
        {
            for (int x = 0; x <= Xsize; x++)
            {
                float height = Mathf.Clamp(y, y * GenerateNoise.SimpleNoise(Xsize, Ysize, x, y, amplitude, frequency, seed), y);

                if (y >= Ysize)
                {
                    vertices[i] = new Vector3(x, height);
                }
                else
                {
                    vertices[i] = new Vector3(x, y);
                }
                i++;
            }
        }
        return vertices;
    }
    public static int[] Trinagles(int Xsize, int Ysize)
    {
        int[] triangles = new int[Xsize * Ysize * 6];

        int vert = 0;
        int tris = 0;

        for (int y = 0; y < Ysize; y++)
        {
            for (int x = 0; x < Xsize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + Xsize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + Xsize + 1;
                triangles[tris + 5] = vert + Xsize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
        return triangles;
    }

    public static Vector2[] Collider(Vector3[] meshVertices, int Xsize, int Ysize)
    {
        Vector2[] ColliderPoints = new Vector2[Xsize];
        int i = 0;
        for (int vert = 0; vert < meshVertices.Length; vert++)
        {
            if (meshVertices[vert].y >= Ysize && i < Xsize)
            {
                ColliderPoints[i] = new Vector2(meshVertices[vert].x, meshVertices[vert].y);
                i++;
            }

        }

        return ColliderPoints;
    }


}
