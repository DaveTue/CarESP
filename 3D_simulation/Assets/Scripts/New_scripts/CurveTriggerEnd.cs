using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveTriggerEnd : MonoBehaviour
{
    private GameObject ego_car;
   
    public CurveHandlerScript Curveflag;

    void Start()
    {
        ego_car= GameObject.Find("E36");
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == ego_car)
        { Curveflag.TriggerIn = 0;
            
        }

        /*if (other.gameObject.tag == "Kyle")
        {
            Kyle.gameObject.GetComponent<Animator>().enabled = false;
            Kyle.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Kyle.gameObject.GetComponent<Transform>().position = new Vector3(866.4879f, 922.862f, 805.3486f);
            cs.AvoidPedestrian++;
            //ADD FUNCTION HERE FOR PEDESTRIAN SURVIVING
        }*/

    }
}

