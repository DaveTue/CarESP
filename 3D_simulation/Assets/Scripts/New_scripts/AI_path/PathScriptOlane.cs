using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScriptOlane : MonoBehaviour
{
  

    Color rayColor = Color.red;
    List<Transform> patholane;

    void OnDrawGizmosSelected()// function that is called inside of the editor
    {

        Gizmos.color = rayColor;
        Transform[] childs = transform.GetComponentsInChildren<Transform>(); // grap all the objects which are child objects
        patholane = new List<Transform>();
        foreach (Transform c in childs)
        {
            if (c != transform)
                patholane.Add(c);
            
        }
        for (int i = 0; i < patholane.Count; i++)
        {
            Vector3 pos = patholane[i].position;
            if (i > 0)
            {
                Vector3 prev = patholane[i - 1].position;
                Gizmos.DrawLine(prev, pos);
                Gizmos.DrawWireSphere(pos, 0.3f);
                Debug.Log(pos + "\n");
            }
        }

    }
}
