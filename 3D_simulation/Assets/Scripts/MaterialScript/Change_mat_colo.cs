using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Change_mat_colo : MonoBehaviour
{

    public Material[] material;
    Renderer rend;
    public float input;
    //public BodyMap col;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        //material[0].SetColor("_Color", new Color(255f / 255f, 255f / 255f, 255f / 255f, 0.5f));
    }

    void Update()
    {

        ChangeMaterialFunc(material[0]);
        //rend.sharedMaterial = material[1];

    }
    
    void ChangeMaterialFunc(Material newmat)
    {
        
        Renderer[] children;
        children = GetComponentsInChildren<Renderer>();
        
      
        foreach (Renderer rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = newmat;
               
            }
            rend.materials = mats;
        }
    }

}
