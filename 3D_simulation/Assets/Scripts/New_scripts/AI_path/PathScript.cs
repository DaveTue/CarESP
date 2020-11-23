using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathScript : MonoBehaviour
{

    Color rayColor = Color.green;
    List<Transform> path;

    void OnDrawGizmosSelected()// function that is called inside of the editor
    {

        Gizmos.color = rayColor;
        Transform[] childs = transform.GetComponentsInChildren<Transform>(); // grap all the objects which are child objects
        path = new List<Transform>();
        foreach (Transform c in childs)
        {
            if (c != transform)
                path.Add(c);
        }
        for (int i = 0; i < path.Count; i++)
        {
            Vector3 pos = path[i].position;
            if (i > 0)
            {
                Vector3 prev = path[i - 1].position;
                Gizmos.DrawLine(prev, pos);
                Gizmos.DrawWireSphere(pos, 0.3f);
            }
        }

    }
}
