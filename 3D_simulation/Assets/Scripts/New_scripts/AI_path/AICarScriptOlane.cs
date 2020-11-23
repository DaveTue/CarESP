using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AICarScriptOlane : MonoBehaviour
{
    public Transform PathGroup_For;
    private Transform pathGroup_olane;
    public Transform pathGroup_Rev;
    public int Pathchose = 1;
    public Vector3 centerOfMass;

    public float maxSteer = 15;
    public float maxTorque = 500;
    public float currentSpeed;
    public float topSpeed = 150;
    public float decelerationSpeed = 10;

    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    public int currentPathObj_olane;
    public float distFromPath = 20;

    private List<Transform> patholane;
    private Rigidbody rb;

    void Start()
    {
        patholane = new List<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
        getPath();
    }

    void Update()
    {
        getSteer();
        Move();
    }

    void getPath()
    {
        if (Pathchose == 1) { pathGroup_olane = PathGroup_For; }
        else { pathGroup_olane = pathGroup_Rev; } 
            
        Transform[] childObejects = pathGroup_olane.GetComponentsInChildren<Transform>();

        for (int i = 0; i < childObejects.Length; i++)
        {
            Transform temp = childObejects[i];
            if (temp.gameObject.GetInstanceID() != GetInstanceID())
                patholane.Add(temp);
        }

        Debug.Log(patholane.Count);
    }

    void getSteer()
    {
        Vector3 steerVector = transform.InverseTransformPoint(new Vector3(patholane[currentPathObj_olane].position.x, transform.position.y, patholane[currentPathObj_olane].position.z));
        float newSteer = maxSteer * (steerVector.x / steerVector.magnitude);
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;

        if (steerVector.magnitude <= distFromPath) //might be distFromPath variable
        {
            currentPathObj_olane++;
            Debug.Log(currentPathObj_olane);
        }

        if (currentPathObj_olane >= patholane.Count)
        {
            currentPathObj_olane = 1;
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
        }
        else
        {
            wheelRL.motorTorque = 0;
            wheelRR.motorTorque = 0;
            wheelRL.brakeTorque = decelerationSpeed;
            wheelRR.brakeTorque = decelerationSpeed;
        }
    }

}
