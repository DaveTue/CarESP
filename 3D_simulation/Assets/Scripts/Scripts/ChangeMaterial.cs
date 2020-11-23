using UnityEngine;
using System.Collections;

public class ChangeMaterial : MonoBehaviour
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
        if (input == 1)
        {
            ChangeMaterialFunc(material[1]);
            //rend.sharedMaterial = material[1];
        }
        if (input == 2)
        {
            ChangeMaterialFunc(material[2]);
            //rend.sharedMaterial = material[2];
        }
        if (input == 3)
        {
            ChangeMaterialFunc(material[3]);
            //rend.sharedMaterial = material[3];
        }
        if (input == 4)
        {
            ChangeMaterialFunc(material[4]);
            //rend.sharedMaterial = material[4];
        }
        if (input == 5)
        {
            ChangeMaterialFunc(material[5]);
            //rend.sharedMaterial = material[5];
        }
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