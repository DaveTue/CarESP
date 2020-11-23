using UnityEngine;
using System.Collections;

public class Material_LeadCar : MonoBehaviour
{

    public Material[] material;
    Renderer rend;
    public float input;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    void Update()
    {
        
            ChangeMaterialFunc(material[0]);
            //rend.sharedMaterial = material[1];
        
    }

    void ChangeMaterialFunc(Material newMat)
    {
        Renderer[] children;
        children = GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = newMat;
            }
            rend.materials = mats;
        }
    }


}