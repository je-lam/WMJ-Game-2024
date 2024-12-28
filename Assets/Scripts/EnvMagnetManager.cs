using System.Collections.Generic;
using UnityEngine;

public class EnvMagnetManager : MonoBehaviour
{
    GameObject[] allEnvMagnets;
    List<PointEffector2D> allEnvMagneticFields;
    void Start()
    {
        allEnvMagnets = GameObject.FindGameObjectsWithTag("Env Magnet");
        allEnvMagneticFields = new List<PointEffector2D>();
        for (int i = 0; i < allEnvMagnets.Length; i++)
        {
            allEnvMagneticFields.Add(allEnvMagnets[i].GetComponent<PointEffector2D>());
        }
        print("Number of Env magnets: " + GetNumberOfEnvMagnets());
    }

    void AdjustAllToPlayerPolarity()
    {
        for (int i = 0; i < allEnvMagneticFields.Count; i++)
        {
            allEnvMagneticFields[i].forceMagnitude *= -1;
        }
    }

    int GetNumberOfEnvMagnets()
    {
        return allEnvMagneticFields.Count;
    }
}
