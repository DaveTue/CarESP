using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveHandlerScript : MonoBehaviour
{
   // public GameObject egocar;
   // public GameObject CurveHandler;
    //public GameObject leadcar;
    //define the variables that are going to be sent
    //public VehicleEvent cf;
    public int CurveFlag=0;
    public int TriggerIn=0;
    public CurveEventSend curvef;
   // public int CurveflagCar = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerIn > 0)
            
        {
            // Debug.Log(leadcar.gameObject.tag);
          
            Triggered();
           
        }else
        {
            //cf.send2simulink=0;
            curvef.curve_detect = 0;
            CurveFlag = 0;
          //  curvef.curve_detect = 0;
        }
    }
    void Triggered()
    {
        //cf.send2simulink=1;
        curvef.curve_detect = 1;
        CurveFlag = 1;

    }
}
