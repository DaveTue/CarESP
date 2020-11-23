using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

public class BodyMap : MonoBehaviour
{
    public float R = 11f;
    public float G = 11f;
    public float B = 243f;
    public float t = 0.7f;
    /*
     public GameObject cabine;
     public GameObject tire_lr;
     public GameObject tire_lf;
     public GameObject tire_rr;
     public GameObject tire_rf;
     public GameObject wheel_lr;
     public GameObject wheel_lf;
     public GameObject wheel_rr;
     public GameObject wheel_rf;
     public GameObject motor;
     public GameObject dashboard;
     public GameObject door_lf;
     public GameObject door_lr;
     public GameObject door_rf;
     public GameObject door_rr;
     public GameObject body;
     public GameObject windshield;
     public GameObject lights;
     public GameObject communication;
     */
    public Material cabine_col;
    public Material tire_col;
    public Material wheel_col;
    public Material motor_col;
    public Material dashboard_col;
    public Material door_col;
    public Material body_col;
    public Material windshiled_col;
    public Material lights_col;
    public Material communication_col;

    private float cabine_st;
    private float tires_st;
    private float wheels_st;
    private float motor_st;
    private float dashboar_st;
    private float doors_st;
    private float body_st;
    private float windshield_st;
    private float lights_st;
    private float communication_st;

  //  public float percentage=0;

    readonly string host = "0.0.0.0";
    readonly int port = 54320;
    Thread ListenerThread;
    UdpClient clientL = new UdpClient();

    void Stop()
    {

        clientL.Close();

        ListenerThread.Join();
        ListenerThread.Abort();

        clientL = new UdpClient();

      

    }

    void OnApplicationQuit()
    {
        R = 255f;
        G = 255f;
        B = 255f;
        cabine_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        tire_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        wheel_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        motor_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        dashboard_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        door_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        body_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        windshiled_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        lights_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        communication_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
    }

    public void ListenForMessages()
    {

        while (true)
        {

            Byte[] bytesL = new Byte[1024];
            var remoteEP = new IPEndPoint(IPAddress.Parse(host), port);
            clientL.Client.Bind(remoteEP);
            var from = new IPEndPoint(0, 0);
           
            float cabine_st_simulink=0;
            float tires_st_simulink=0;
            float wheels_st_simulink=0;
            float motor_st_simulink=0;
            float dashboar_st_simulink=0;
            float doors_st_simulink=0;
            float body_st_simulink=0;
            float windshield_st_simulink=0;
            float lights_st_simulink=0;
            float communication_st_simulink=0;


            while (true)
            {
                string rx_line = System.Text.Encoding.Default.GetString(clientL.Receive(ref from));
                string[] rx_array = rx_line.Split(new string[] { "," }, StringSplitOptions.None);
                
                if (rx_array.Length == 10)//
                {
                    if (float.TryParse(rx_array[0], out cabine_st_simulink))
                    {
                        this.cabine_st = cabine_st_simulink;
                    }
                    if (float.TryParse(rx_array[1], out tires_st_simulink))
                    {
                        this.tires_st = tires_st_simulink;
                    }
                    if (float.TryParse(rx_array[2], out wheels_st_simulink))
                    {
                        this.wheels_st = wheels_st_simulink;
                    }
                    if (float.TryParse(rx_array[3], out motor_st_simulink))
                    {
                        this.motor_st = motor_st_simulink;
                    }
                    if (float.TryParse(rx_array[4], out dashboar_st_simulink))
                    {
                        this.dashboar_st = dashboar_st_simulink;
                    }
                    if (float.TryParse(rx_array[5], out doors_st_simulink))
                    {
                        this.doors_st = doors_st_simulink;
                    }
                    if (float.TryParse(rx_array[6], out body_st_simulink))
                    {
                        this.body_st = body_st_simulink;
                    }
                    if (float.TryParse(rx_array[7], out windshield_st_simulink))
                    {
                        this.windshield_st = windshield_st_simulink;
                    }
                    if (float.TryParse(rx_array[8], out lights_st_simulink))
                    {
                        this.lights_st = lights_st_simulink;
                    } //changes DaveMan made 
                    if (float.TryParse(rx_array[9], out communication_st_simulink))
                    {
                        this.communication_st = communication_st_simulink;
                    }
                }
            }
        }

    }

    public (float, float, float) RGB_transform(float a)
    {
        float max = 928f;
        float R_0 = 11f;
        float G_0 = 11f;
        float B_0 = 243f;
        float R=11f;
        float G=11f;
        float B=243f;
        float lim = 232f;

        double Place;
        Place = Math.Round(max * a,0);
        float place1 = Convert.ToSingle(Place);
        if (place1 / lim <= 1) { R = R_0; G = G_0 + place1; B = B_0; }
        else if (place1 / lim > 1 && place1 / lim <= 2) { float temp = place1 - lim; R = R_0; G = G_0 + lim;  B = B_0- temp; }
        else if (place1 / lim > 2 && place1 / lim <= 3) { float temp = place1 - 2*lim;  R = R_0 + temp; G = G_0 + lim;  B = B_0 - lim; }
        else if (place1 / lim > 3 && place1 / lim <= 4) { float temp = place1 - 3 * lim; R = R_0 + lim; G = G_0 + lim-temp; B = B_0 - lim; }

        return (R, G, B);

    }


 


    // Start is called before the first frame update
    void Start()
    {
        ListenerThread = new Thread(() => ListenForMessages());
        ListenerThread.Start();
        R = 11f;
        G = 11f;
        B = 243f;
        cabine_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        tire_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        wheel_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        motor_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        dashboard_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        door_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        body_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        windshiled_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        lights_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));
        communication_col.SetColor("_Color", new Color(R / 255f, G / 255f, B / 255f, t));

        /*
        cabine.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        tire_lf.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        tire_lr.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        tire_rf.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        tire_rr.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        // int N = wheel_lf.gameObject.GetComponent<Renderer>().materials.Length;
        // for (int i = 1; i == N; i++) { wheel_lf.gameObject.GetComponent<Renderer>().materials[i].color = new Color(R / 255f, G / 255f, B / 255f, t); }
        wheel_lf.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
       
        wheel_lr.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        wheel_rf.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        wheel_rr.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        motor.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        dashboard.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        door_lf.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        door_lr.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        door_rf.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        door_rr.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        body.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        windshield.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        lights.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        communication.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        */
    }

    // Update is called once per frame
    void Update()
    {
        

        (float cabR, float cabG,float cabB)=RGB_transform(cabine_st);
        //cabine.gameObject.GetComponent<Renderer>().material.color = new Color(cabR / 255f, cabG / 255f, cabB / 255f, t);
        cabine_col.SetColor("_Color", new Color(cabR / 255f, cabG / 255f, cabB / 255f, t));

        // cabine.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
        (float tireR, float tireG, float tireB) = RGB_transform(tires_st);
        tire_col.SetColor("_Color", new Color(tireR / 255f, tireG / 255f, tireB / 255f,t));
      //  tire_lf.gameObject.GetComponent<Renderer>().material.color = new Color(tireR / 255f, tireG / 255f, tireB / 255f, t);
        //tire_lr.gameObject.GetComponent<Renderer>().material.color = new Color(tireR / 255f, tireG / 255f, tireB / 255f, t);
        //tire_rf.gameObject.GetComponent<Renderer>().material.color = new Color(tireR / 255f, tireG / 255f, tireB / 255f, t);
        //tire_rr.gameObject.GetComponent<Renderer>().material.color = new Color(tireR / 255f, tireG / 255f, tireB / 255f, t);

        (float wheelR, float wheelG, float wheelB) = RGB_transform(wheels_st);
        wheel_col.SetColor("_Color", new Color(wheelR/255f, wheelG/255f, wheelB/255f,t));
        //wheel_lf.gameObject.GetComponent<Renderer>().material = Instantiate(Resources.Load("Material") as Material)
      //  int N = wheel_lf.gameObject.GetComponent<Renderer>().materials.Length;
        //Debug.Log("materials:" + N);
     //   for (int i = 1; i == N ; i++) { wheel_lf.gameObject.GetComponent<Renderer>().materials[i].color = new Color(wheelR / 255f, wheelG / 255f, wheelB / 255f, t); }
      //  wheel_lf.gameObject.GetComponent<Renderer>().material.color = new Color(wheelR / 255f, wheelG / 255f, wheelB / 255f, t);
       // wheel_lr.gameObject.GetComponent<Renderer>().material.color = new Color(wheelR / 255f, wheelG / 255f, wheelB / 255f, t);
        //wheel_rf.gameObject.GetComponent<Renderer>().material.color = new Color(wheelR / 255f, wheelG / 255f, wheelB / 255f, t);
        //wheel_rr.gameObject.GetComponent<Renderer>().material.color = new Color(wheelR / 255f, wheelG / 255f, wheelB / 255f, t);

        (float motorR, float motorG, float motorB) = RGB_transform(motor_st);
        motor_col.SetColor("_Color", new Color(motorR/255f,motorG/255f,motorB/255f,t));
        //motor.gameObject.GetComponent<Renderer>().material.color = new Color(motorR / 255f, motorG / 255f, motorB / 255f, t);

        (float dashR, float dashG, float dashB) = RGB_transform(dashboar_st);
        dashboard_col.SetColor("_Color", new Color(dashR/255f, dashG/255f, dashB/255f,t));
        //dashboard.gameObject.GetComponent<Renderer>().material.color = new Color(dashR / 255f, dashG / 255f, dashB / 255f, t);

        (float doorR, float doorG, float doorB) = RGB_transform(doors_st);
        door_col.SetColor("_Color", new Color (doorR/255f, doorG/255f, doorB/255f,t));
        //door_lf.gameObject.GetComponent<Renderer>().material.color = new Color(doorR / 255f, doorG / 255f, doorB / 255f, t);
        //door_lr.gameObject.GetComponent<Renderer>().material.color = new Color(doorR / 255f, doorG / 255f, doorB / 255f, t);
        //door_rf.gameObject.GetComponent<Renderer>().material.color = new Color(doorR / 255f, doorG / 255f, doorB / 255f, t);
        //door_rr.gameObject.GetComponent<Renderer>().material.color = new Color(doorR / 255f, doorG / 255f, doorB / 255f, t);

        (float bodyR, float bodyG, float bodyB) = RGB_transform(body_st);
        body_col.SetColor("_Color", new Color(bodyR/255f, bodyG/255f, bodyB/255f,t));
        //body.gameObject.GetComponent<Renderer>().material.color = new Color(bodyR / 255f, bodyG / 255f, bodyB / 255f, t);

        (float windR, float windG, float windB) = RGB_transform(windshield_st);
        windshiled_col.SetColor("_Color", new Color (windR/255f, windG/255f,windB/255f,t));
        //windshield.gameObject.GetComponent<Renderer>().material.color = new Color(windR / 255f, windG / 255f, windB / 255f, t);

        (float lightR, float lightG, float lightB) = RGB_transform(lights_st);
        lights_col.SetColor("_Color", new Color(lightR/255f, lightG/255f, lightB/255f,t));
       // lights.gameObject.GetComponent<Renderer>().material.color = new Color(lightR / 255f, lightG / 255f, lightB / 255f, t);

        (float commR, float commG, float commB) = RGB_transform(communication_st);
        communication_col.SetColor("_Color", new Color(commR/255f, commG/255f, commB/255f,t));
       // communication.gameObject.GetComponent<Renderer>().material.color = new Color(commR / 255f, commG / 255f, commB / 255f, t);
       // Debug.Log("communication" + communication_st);
        //   GameObject vehicle = GameObject.Find("BMWX54_ego");
        // GameObject part=vehicle.GetComponent<>()
        /*
        //Update value in SmileyGenerator.cs
        GameObject Smiley = GameObject.Find("Smiley");
        SmileyGenerator smileyGenerator = Smiley.GetComponent<SmileyGenerator>();

        smileyGenerator.Anger = this.sim_anger;
        angerbar.SetSize(this.sim_anger);

        smileyGenerator.Disgust = this.sim_disgust;
        disgustbar.SetSize(this.sim_disgust);

        smileyGenerator.Fear = this.sim_fear;
        fearbar.SetSize(this.sim_fear);

        smileyGenerator.Happiness = this.sim_happiness;
        happinessbar.SetSize(this.sim_happiness);

        smileyGenerator.Neutral = this.sim_neutral;
        neutralbar.SetSize(this.sim_neutral);

        smileyGenerator.Sadness = this.sim_sadness;
        sadnessbar.SetSize(this.sim_sadness);

        smileyGenerator.Surprise = this.sim_surprise;
        surprisebar.SetSize(this.sim_surprise);
        */
        //changes DaveMan made 
        // stressbar.SetSize(this.sim_stress);
        //cube.gameObject.GetComponent<Renderer>().material.color = new Color(R / 255f, G / 255f, B / 255f, t);
    }
}
