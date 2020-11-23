using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIegocar : MonoBehaviour
{
    //variables to move

    public GameObject egocar;
    public float acceleration;
    public float acc_rot;
    public float mass;

    private float oldspeed;

    public Transform pathGroup;
    public Vector3 centerOfMass;

    public float maxSteer = 15;
    public float maxTorque = 600;
    public float currentSpeed;
    public float speedcar;

    public float topSpeed = 150;
    public float decelerationSpeed = 10;

    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    public int currentPathObj; //works
   // public AIOvertake currentPathObj;
    public float distFromPath = 20;

    private List<Transform> path;
    private Rigidbody rb;

    void Start()
    {
        path = new List<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
        getPath();
        mass = egocar.GetComponent<Rigidbody>().mass;
        oldspeed = egocar.GetComponent<Rigidbody>().velocity.magnitude;
    }

    void Update()
    {
        getSteer();
        Move();
        speedcar = egocar.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        acceleration = (speedcar - oldspeed) / (Time.deltaTime) / 3.6f;
        oldspeed = speedcar;
    }

    void getPath()
    {
        Transform[] childObejects = pathGroup.GetComponentsInChildren<Transform>();

        for (int i = 0; i < childObejects.Length; i++)
        {
            Transform temp = childObejects[i];
            if (temp.gameObject.GetInstanceID() != GetInstanceID())
                path.Add(temp);
        }

        //Debug.Log(pathList.Count);
    }

    void getSteer()
    {
        Vector3 steerVector = transform.InverseTransformPoint(new Vector3(path[currentPathObj].position.x, transform.position.y, path[currentPathObj].position.z)); //works
        //Vector3 steerVector = transform.InverseTransformPoint(new Vector3(path[currentPathObj.Object_path_0].position.x, transform.position.y, path[currentPathObj.Object_path_0].position.z));
        float newSteer = maxSteer * (steerVector.x / steerVector.magnitude);
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;

        if (steerVector.magnitude <= distFromPath) //might be distFromPath variable
        {
            currentPathObj++; //works
            //currentPathObj.Object_path_0++;
        }
         if (currentPathObj >= path.Count)//works
        //if (currentPathObj.Object_path_0 >= path.Count)
        {
            currentPathObj = 1;//works
            //currentPathObj.Object_path_0 = 1;
        }
    }

    void Move()
    {
        currentSpeed = 2 * (22 / 7) * wheelRL.radius * wheelRL.rpm * 60 / 1000;
        currentSpeed = Mathf.Round(currentSpeed);


        if (currentSpeed <= topSpeed)
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