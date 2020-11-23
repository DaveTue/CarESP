using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterReset : MonoBehaviour
{

    public GameObject Kyle;
    public CounterScript cs;
    

    // Use this for initialization
    void Start()
    {
        Kyle = GameObject.Find("Robot Kyle");
        Kyle.gameObject.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {

        Kyle.gameObject.GetComponent<Transform>().position = new Vector3(866.4879f, 922.862f, 805.3486f);
        Kyle.gameObject.GetComponent<Animator>().enabled = false;
        cs.TriggerEnter = 0;
        cs.HitPedestrian = 0;
        cs.AvoidPedestrian = 0;

        //ADD FUNCTION HERE FOR ENTERING THE INVISIBLE TRIGGER
    }

}
