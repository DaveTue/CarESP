using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveTrigger : MonoBehaviour
{
    private GameObject ego_car;
    public CurveHandlerScript Curveflag;
    
    void Start()
    {
       ego_car = GameObject.Find("E36");
        if (ego_car != null) { Debug.Log("found"); }
    }

    void Update()
    {
      //  if (ego_car != null) { Debug.Log("found"); }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == ego_car)
        
            { Curveflag.TriggerIn++;
            Debug.Log("Hit!!!!!!!!");
        }

           
    }

}
