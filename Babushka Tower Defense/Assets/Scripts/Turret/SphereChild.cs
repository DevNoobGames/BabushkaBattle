using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChild : MonoBehaviour
{
    public Material Red;
    public Material Green;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("LoS"))
        {
            var mats = new Material[GetComponent<MeshRenderer>().materials.Length];
            for (var j = 0; j < GetComponent<MeshRenderer>().materials.Length; j++)
            {
                mats[j] = Red;
            }
            GetComponent<MeshRenderer>().materials = mats;
            GetComponentInParent<SpherePlacementTest>().canBuild = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //GetComponent<MeshRenderer>().material = Green;
        var mats = new Material[GetComponent<MeshRenderer>().materials.Length];
        for (var j = 0; j < GetComponent<MeshRenderer>().materials.Length; j++)
        {
            mats[j] = Green;
        }
        GetComponent<MeshRenderer>().materials = mats;
        GetComponentInParent<SpherePlacementTest>().canBuild = true;
    }
}
