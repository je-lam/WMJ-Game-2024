using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TerrainRender{

	public static Vector3[] GenerateLineRenderer(Vector3[] MeshVertices, int Ysize,ref LineRenderer LineRenderer , float offset)
    {
        Vector3[] points = new Vector3[MeshVertices.Length];

        int i = 0;

        for (int vert = 0; vert < MeshVertices.Length; vert++)
        {

           if( MeshVertices[vert].y >= Ysize)
           {
                points[i] = new Vector3(MeshVertices[vert].x,MeshVertices[vert].y + offset,-5);
                i++;
           }
        }
        LineRenderer.positionCount = i;
        LineRenderer.SetPositions(points);
        return points;
    }
        
	
}
