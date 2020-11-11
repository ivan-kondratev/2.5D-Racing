using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(AdvancedMeshCombiner))]
public class MeshCombinerEditor : Editor
{
    void OnSceneGUI()
    {
        AdvancedMeshCombiner meshCombiner = target as AdvancedMeshCombiner;

        if (Handles.Button(meshCombiner.transform.position + Vector3.up * 5, Quaternion.LookRotation(Vector3.up), 1, 1, Handles.CubeHandleCap))
        {
            meshCombiner.AdvancedMerge();
        }
    }
}
