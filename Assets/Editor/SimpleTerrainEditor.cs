using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FinalTerrain))]
public class SimpleTerrainEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("ReGenerate"))
        {
            FinalTerrain finalterrain = (FinalTerrain)target;
            finalterrain.Generate();
        }
    }

}
