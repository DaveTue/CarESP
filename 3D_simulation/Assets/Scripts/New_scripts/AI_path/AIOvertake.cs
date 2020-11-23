using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIOvertake : MonoBehaviour
{
    //variables to move
    public int leadposition = 1;
    public int Lead_Anim_enable = 1;
    public int flag_behind = 1;
    public int Terminate = 0;
    public float topSpeed = 60;
    public float gapmin = 9;
    public float gapmax = 15;
    public float gap_OT = 11;
    public float maxTorque = 530;
    public int OT_times=0;


    public float decelerationSpeed = 20;

    public GameObject egocar;
    public GameObject leadcar;
    
    public int Object_path_0=1;

    
    public float gap;
    
    
    public int flag_OT = 0;  
  
    //variables for the overtake
    private float egox;
    private float egoz;
    private float egodir;
    private float egox1;
    private float egox2;
    private float egox3;
    private float egox4;
    private float egoz1;
    private float egoz2;
    private float egoz3;
    private float egoz4;
    private Vector2 egovector;

    //dimensions
    private float carlong=2.78f;
    private float widecar = 1.58f;
    private float tol = 0.5f;

    private float leadx;
    private float leadz;
    private float leaddir;
    private float leadingx1;
    private float leadingx2;
    private float leadingx3;
    private float leadingx4;
    private float leadingz1;
    private float leadingz2;
    private float leadingz3;
    private float leadingz4;
    private Vector2 leadingvector;
    private float oT_dis;



    private float acceleration;
    private float acc_rot;
    private float mass;

    private float oldspeed;

    public Transform pathGroup;
    public Transform pathOT;
    private Vector3 centerOfMass;
    private Vector3 steerVector;

    public float maxSteer = 15;
    
    private float currentSpeed;
    public float speedcar;

   

    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    public int currentPathObj=1;
    public float distFromPath = 20;

    private List<Transform> path;
    private List<Transform> pathOTfollow;
    private Rigidbody rb;

    void Start()
    {
       // if (Lead_Anim_enable == 0)
        //{
            //else
            //{
            // leadcar.gameObject.GetComponent<Animator>().enabled = false;
            if (leadposition == 1)
            {
                leadcar.gameObject.GetComponent<Transform>().position = new Vector3(859.5f, 923.52f, 811f);
                leadcar.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                Object_path_0 = 2;
            }
            else if (leadposition == 2)
            {
                leadcar.gameObject.GetComponent<Transform>().position = new Vector3(959.1f, 923.52f, 885.6f);
                leadcar.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                Object_path_0 = 11;
            }
            else if (leadposition == 3)
            {
                leadcar.gameObject.GetComponent<Transform>().position = new Vector3(857.3f, 923.52f, 965.3f);
                leadcar.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
                Object_path_0 = 21;
            }
            else if (leadposition == 4)
            {
                leadcar.gameObject.GetComponent<Transform>().position = new Vector3(750.1f, 923.52f, 888f);
                leadcar.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                Object_path_0 = 29;
            }
        //} 
        //}
        path = new List<Transform>();
        pathOTfollow = new List<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
        getPath();
        getPath2();
        mass = egocar.GetComponent<Rigidbody>().mass;
        oldspeed = egocar.GetComponent<Rigidbody>().velocity.magnitude;
        gap = Vector3.Distance(egocar.transform.position, leadcar.transform.position);
        flag_OT = 0;
        egox = egocar.transform.position.x;
        egoz = egocar.transform.position.z;
        egodir = egocar.transform.rotation.eulerAngles.y* Mathf.PI / 180;
        leadx = leadcar.transform.position.x;
        leadz = leadcar.transform.position.z;
        leaddir = leadcar.transform.rotation.eulerAngles.y* Mathf.PI / 180;
        egox1 = egox + carlong*Mathf.Sin(egodir) + widecar * Mathf.Cos(egodir);
        //egox2 = egox + carlong * Mathf.Sin(egodir) - widecar * Mathf.Cos(egodir);
        egox3 = egox - carlong * Mathf.Sin(egodir) + widecar * Mathf.Cos(egodir);
        //egox4 = egox - carlong * Mathf.Sin(egodir) - widecar * Mathf.Cos(egodir);
        egoz1 = egoz + carlong * Mathf.Cos(egodir) + widecar * Mathf.Sin(egodir);
        //egoz2 = egoz + carlong * Mathf.Cos(egodir) - widecar * Mathf.Sin(egodir);
        egoz3 = egoz - carlong * Mathf.Cos(egodir) + widecar * Mathf.Sin(egodir);
        //egoz4 = egoz - carlong * Mathf.Cos(egodir) - widecar * Mathf.Sin(egodir);
        egovector = new Vector2(egox1 - egox3, egoz1 - egoz3);
        leadingx1 = leadx + carlong * Mathf.Sin(leaddir) + widecar * Mathf.Cos(leaddir);
        //egox2 = egox + carlong * Mathf.Sin(egodir) - widecar * Mathf.Cos(egodir);
        leadingx3 = leadx - carlong * Mathf.Sin(leaddir) + widecar * Mathf.Cos(leaddir);
        //egox4 = egox - carlong * Mathf.Sin(egodir) - widecar * Mathf.Cos(egodir);
        leadingz1 = leadz + carlong * Mathf.Cos(leaddir) + widecar * Mathf.Sin(leaddir);
        //egoz2 = egoz + carlong * Mathf.Cos(egodir) - widecar * Mathf.Sin(egodir);
        leadingz3 = leadz - carlong * Mathf.Cos(leaddir) + widecar * Mathf.Sin(leaddir);
        //egoz4 = egoz - carlong * Mathf.Cos(egodir) - widecar * Mathf.Sin(egodir);
        leadingvector = new Vector2(leadingx1 - leadingx3, leadingz1 - leadingz3);
        oT_dis = Vector2.Distance(egovector, leadingvector);

    }

    void Update()
    {
        if (Lead_Anim_enable == 0)
        {
            //else
            //{
            //leadcar.gameObject.GetComponent<Animator>().enabled = false;
            if (leadposition == 1)
            {
                leadcar.gameObject.GetComponent<Transform>().position = new Vector3(859.5f, 923.52f, 811f);
                leadcar.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                Object_path_0 = 2;
            }
            else if (leadposition == 2)
            {
                leadcar.gameObject.GetComponent<Transform>().position = new Vector3(959.1f, 923.52f, 885.6f);
                leadcar.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                Object_path_0 = 11;
            }
            else if (leadposition == 3)
            {
                leadcar.gameObject.GetComponent<Transform>().position = new Vector3(857.3f, 923.52f, 965.3f);
                leadcar.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
                Object_path_0 = 21;
            }
            else if (leadposition == 4)
            {
                leadcar.gameObject.GetComponent<Transform>().position = new Vector3(750.1f, 923.52f, 888f);
                leadcar.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                Object_path_0 = 29;
            }
        }
        //}
        if (gap <= gap_OT && flag_behind==1) { flag_OT = 1; }
        getSteer();
        Move();
        speedcar = egocar.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        acceleration = (speedcar - oldspeed) / (Time.deltaTime) / 3.6f;
        oldspeed = speedcar;
        gap = Vector3.Distance(egocar.transform.position, leadcar.transform.position);
        egox = egocar.transform.position.x;
        egoz = egocar.transform.position.z;
        egodir = egocar.transform.rotation.eulerAngles.y * Mathf.PI / 180;
        leadx = leadcar.transform.position.x;
        leadz = leadcar.transform.position.z;
        leaddir = leadcar.transform.rotation.eulerAngles.y * Mathf.PI / 180;
        egox1 = egox + carlong * Mathf.Sin(egodir) + widecar * Mathf.Cos(egodir);
        //egox2 = egox + carlong * Mathf.Sin(egodir) - widecar * Mathf.Cos(egodir);
        egox3 = egox - carlong * Mathf.Sin(egodir) + widecar * Mathf.Cos(egodir);
        //egox4 = egox - carlong * Mathf.Sin(egodir) - widecar * Mathf.Cos(egodir);
        egoz1 = egoz + carlong * Mathf.Cos(egodir) + widecar * Mathf.Sin(egodir);
        //egoz2 = egoz + carlong * Mathf.Cos(egodir) - widecar * Mathf.Sin(egodir);
        egoz3 = egoz - carlong * Mathf.Cos(egodir) + widecar * Mathf.Sin(egodir);
        //egoz4 = egoz - carlong * Mathf.Cos(egodir) - widecar * Mathf.Sin(egodir);
        egovector = new Vector2(egox1 - egox3, egoz1 - egoz3);
        leadingx1 = leadx + carlong * Mathf.Sin(leaddir) + widecar * Mathf.Cos(leaddir);
        //egox2 = egox + carlong * Mathf.Sin(egodir) - widecar * Mathf.Cos(egodir);
        leadingx3 = leadx - carlong * Mathf.Sin(leaddir) + widecar * Mathf.Cos(leaddir);
        //egox4 = egox - carlong * Mathf.Sin(egodir) - widecar * Mathf.Cos(egodir);
        leadingz1 = leadz + carlong * Mathf.Cos(leaddir) + widecar * Mathf.Sin(leaddir);
        //egoz2 = egoz + carlong * Mathf.Cos(egodir) - widecar * Mathf.Sin(egodir);
        leadingz3 = leadz - carlong * Mathf.Cos(leaddir) + widecar * Mathf.Sin(leaddir);
        //egoz4 = egoz - carlong * Mathf.Cos(egodir) - widecar * Mathf.Sin(egodir);
        leadingvector = new Vector2(leadingx1 - leadingx3, leadingz1 - leadingz3);
        oT_dis = Vector2.Distance(egovector, leadingvector);
        if (oT_dis >= (carlong + tol) || Terminate==1)
        { flag_OT = 0;
            //flag_behind = 0;
        }
    }

    void getPath()
    {
        Transform[] childObejects = pathGroup.GetComponentsInChildren<Transform>();
        // Transform[] childObejects2 = pathOT.GetComponentsInChildren<Transform>();

        for (int i = 0; i < childObejects.Length; i++)
        {
            Transform temp = childObejects[i];
            if (temp.gameObject.GetInstanceID() != GetInstanceID())
                path.Add(temp);
        }
    }
        

        void getPath2()
        {
           // Transform[] childObejects = pathGroup.GetComponentsInChildren<Transform>();
            Transform[] childObejects2 = pathOT.GetComponentsInChildren<Transform>();

            
            for (int i = 0; i < childObejects2.Length; i++)
            {
                Transform temp = childObejects2[i];
             if (temp.gameObject.GetInstanceID() != GetInstanceID())
                pathOTfollow.Add(temp); 
            }

            //Debug.Log(pathList.Count);
        }

    void getSteer()
    {
        if (flag_OT==1 )
        {
            steerVector = transform.InverseTransformPoint(new Vector3(pathOTfollow[currentPathObj].position.x, transform.position.y, pathOTfollow[currentPathObj].position.z));
            OT_times++;
            //if (oT_dis >= carlong + tol) { flag_OT = 0; flag_behind = 0; }
        }
        else

            {steerVector = transform.InverseTransformPoint(new Vector3(path[currentPathObj].position.x, transform.position.y, path[currentPathObj].position.z)); }
        float newSteer = maxSteer * (steerVector.x / steerVector.magnitude);
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;

        if (steerVector.magnitude <= distFromPath) //might be distFromPath variable
        {
            currentPathObj++;
        }

        if (currentPathObj >= path.Count)
        {
            currentPathObj = 1;
        }
    }

    void Move()
    {
        currentSpeed = 2 * (22 / 7) * wheelRL.radius * wheelRL.rpm * 60 / 1000;
        currentSpeed = Mathf.Round(currentSpeed);

        if (gap <= gapmin && flag_OT==0 && flag_behind==1)
        {
            wheelRL.motorTorque = 0;
            wheelRR.motorTorque = 0;
            wheelRL.brakeTorque = decelerationSpeed;
            wheelRR.brakeTorque = decelerationSpeed;
        }

        if (currentSpeed <= topSpeed && (gap >= gapmax || flag_OT==1 ||flag_behind==0))
        {
            wheelRL.motorTorque = maxTorque;
            wheelRR.motorTorque = maxTorque;
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
            //acc_rot = wheelRL.motorTorque / (2 * (22 / 7) * wheelRL.radius * mass);
        }
        else
        {
            wheelRL.motorTorque = 0;
            wheelRR.motorTorque = 0;
            wheelRL.brakeTorque = decelerationSpeed;
            wheelRR.brakeTorque = decelerationSpeed;
            // acc_rot = -wheelRL.brakeTorque / (wheelRL.radius * mass);

        }

    }

}