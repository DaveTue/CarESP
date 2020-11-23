using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public float t = 0;
    public sendCollision crash;
    
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
       crash.sendcolision = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t = t + Time.deltaTime;
        if (t >= 30) { crash.sendcolision = 0; }
        //Debug.Log("have it crash?:" + crash);

    }
        void OnCollisionEnter(Collision other)
        {
        crash.sendcolision = 1;
        t = 0;
        }
    }
