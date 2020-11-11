using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    public void CombineMeshes()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();

        Debug.Log(name + " is combining " + meshFilters.Length + " meshes!");

        Mesh finalMesh = new Mesh();
        CombineInstance[] combines = new CombineInstance[meshFilters.Length];

        int i = 0;
        while (i < meshFilters.Length)
        {
            //combines[i].subMeshIndex = 0;
            combines[i].mesh = meshFilters[i].sharedMesh;
            combines[i].transform = meshFilters[i].transform.localToWorldMatrix;
            i++;
        }

        finalMesh.CombineMeshes(combines);
        GetComponent<MeshFilter>().sharedMesh = finalMesh;
    }
}
