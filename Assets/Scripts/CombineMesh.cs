using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CombineMesh : MonoBehaviour
{
   void Start()
    {
        /*MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 1;
        while(i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
            i++;
        }

        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);
        */
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        List<MeshFilter> meshfilter = new List<MeshFilter>();
        for (int i = 1; i < meshFilters.Length; i++)
            meshfilter.Add(meshFilters[i]);
        CombineInstance[] combine = new CombineInstance[meshfilter.Count];
        int np = 0;
        while (np < meshfilter.Count)
        {
            combine[np].mesh = meshfilter[np].sharedMesh;
            combine[np].transform = meshfilter[np].transform.localToWorldMatrix;
            meshfilter[np].gameObject.SetActive(false);
            np++;
        }

        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        //transform.gameObject.SetActive(true);
    }

}
