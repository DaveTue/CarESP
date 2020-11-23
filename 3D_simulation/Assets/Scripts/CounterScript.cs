using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour {

    GameObject Counter;
    public CheckIfTriggered cit;
    public CheckIfHit cih;

    public int TriggerEnter = 0;
	public int HitPedestrian = 0;
	public int AvoidPedestrian = 0;
     
    void Start()
    {
        /*GameObject Counter = GameObject.Find("Counter");
        CheckIfTriggered cit = Counter.GetComponent<CheckIfTriggered>();
        CheckIfHit cih = Counter.GetComponent<CheckIfHit>();
        */
    }

    void Update()
    {
        if (TriggerEnter > 0)
        {
            Triggered();
        }
        else
        {
            cit.send_test = 0;
            cih.send_test1 = 0;
        }
    }
    
    void Triggered()
    {
        cit.send_test = 1;
        if (HitPedestrian > 0)
        {
            cih.send_test1 = 1;
        }
        else if(AvoidPedestrian > 0)
        {
            cih.send_test1 = -1;
        }
        else
        {
            cih.send_test1 = 0;
        }
    }


}
