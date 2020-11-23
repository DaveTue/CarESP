using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTags : MonoBehaviour
{
    public GameObject egocar;
    public GameObject leadingcar;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(egocar.gameObject.tag);
        Debug.Log(leadingcar.gameObject.tag);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
