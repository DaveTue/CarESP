using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class Vehicle_data : MonoBehaviour
{
    //public GameObject gotest;
    //public GameObject gotest1;

    //private float in_test;
    //private float in_test1;

    //these are the value that I want to change and send to Simulink

        //ego car values
    public GameObject ego_car;
    private float ego_speed=0;
    public float car_speed = 0;
    public float ego_acc;
    private float ego_dirangle;
    private float ego_posx=0;
    private float ego_posz=0;
    private float speed_last=0;
    public float ego_distance=0;
    public float ego_distance_0;
    private float ego_x = 0;
    private float ego_z = 0;
    private double dist_cal = 0;

    // lead car values
    GameObject lead_vh;
    private float lead_speed = 0;
    private float lead_posx = 0;
    private float lead_posz=0;
    private int lead_presence = 0;
    //oLane vehicle values
    GameObject olane_vh;
    private float olane_speed = 0;
    private float olane_dirangle;
    private float olane_posx = 0;
    private float olane_posz;
    private int olane_presence = 0;

    // curve detection
   // private int curve_detect = 0; 


    //public float send_test1 = 0;
    //public float send_test1 = 0;

    readonly string host = "0.0.0.0";
    readonly int port = 54325;
    Thread ListenerThread;
    UdpClient client = new UdpClient();

    void Stop()
    {

        client.Close();

        ListenerThread.Join();
        ListenerThread.Abort();

        client = new UdpClient();

    }

    public void ListenForMessages()
    {

        while (true)
        {

            Byte[] bytes = new Byte[1024];
            var remoteEP = new IPEndPoint(IPAddress.Parse(host), port);
            client.Client.Bind(remoteEP);
            var from = new IPEndPoint(0, 0);

            //float testFromRhapsody = 0;
            //float test1FromRhapsody = 0;

            while (true)
            {
                string rx_line = System.Text.Encoding.Default.GetString(client.Receive(ref from));
               // string[] rx_array = rx_line.Split(new string[] { "," }, StringSplitOptions.None);
                //change here (yahaan pe change karna hai)
                /*if (rx_array.Length == 2)
                {
                    if (float.TryParse(rx_array[0], out testFromRhapsody))
                    {
                        this.in_test = testFromRhapsody;
                    }
                    if (float.TryParse(rx_array[1], out test1FromRhapsody))
                    {
                        this.in_test1 = test1FromRhapsody;
                    }
                }*/
                //ego car variables transform to string for message
                string ego_speed_str1 = String.Format("{0:F4}", ego_speed);
                string ego_posx_str = String.Format("{0:F4}", ego_posx);
                string ego_posz_str = String.Format("{0:F4}", ego_posz);
                string ego_acc_str1 = String.Format("{0:F4}", ego_acc);
                string ego_direction_str1 = String.Format("{0:F4}", ego_dirangle);
                string str_ego = ego_speed_str1 + "," + ego_posx_str + "," + ego_posz_str + "," + ego_acc_str1 + "," + ego_direction_str1;
                //Lead car variables transform to string for message
                string lead_presence_str =String.Format("{0:F4}", lead_presence);
                string lead_speed_str = String.Format("{0:F4}", lead_speed);
                string lead_posx_str = String.Format("{0:F4}", lead_posx);
                string lead_posz_str = String.Format("{0:F4}", lead_posz);
                string str_lead = lead_presence_str + "," + lead_speed_str + "," + lead_posx_str + "," + lead_posz_str;
                //other lane car variables transform to string for message
                string olane_presence_str = String.Format("{0:F4}", olane_presence);
                string olane_speed_str = String.Format("{0:F4}", olane_speed);
                string olane_posx_str = String.Format("{0:F4}", olane_posx);
                string olane_posz_str = String.Format("{0:F4}", olane_posz);
                string olane_direction_str = String.Format("{0:F4}", olane_dirangle);
                string str_olane = olane_presence_str + "," + olane_speed_str + "," + olane_posx_str + "," + olane_posz_str + "," + olane_direction_str;
                // curve detectiion variable transform to string for message
                // string curve_detect_str = String.Format("{0:F4}",curve_detect);
                string ego_distance_str = String.Format("{0:F4}", ego_distance);
                //all together
                string str = str_ego + "," + str_lead + "," + str_olane + "," + ego_distance_str;
                //string str1 = test_val_str1;
                var str_to_simulink = str;

                var byte_array = Encoding.GetEncoding("UTF-8").GetBytes(str_to_simulink);
                client.Send(byte_array, str_to_simulink.Length, from.Address.ToString(), from.Port);
               // Debug.Log("message " + curve_detect_str + "\n");
                
            }
        }

    }

    void Start()
    {
        ego_speed = ego_car.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        car_speed = ego_speed*3.6f;
        ego_acc = (ego_speed - speed_last) / Time.fixedDeltaTime;
        ego_dirangle = ego_car.transform.rotation.eulerAngles.y;
        ego_posx = ego_car.gameObject.transform.position.x;
        ego_posz = ego_car.gameObject.transform.position.z;
        speed_last = ego_speed;
        ego_distance = ego_distance_0;
        ego_x = ego_posx;
        ego_z = ego_posz;
        lead_vh = GameObject.Find("leading_car");
        if (lead_vh == null)
        {
            //Debug.Log("No leading vehicle found");
            lead_speed = 0;
            lead_posx = 0;
            lead_posz = 0;
            lead_presence = 0;
        }
        else
        {
            Debug.Log("lead_car detected");
            lead_speed = lead_vh.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            lead_posx = lead_vh.gameObject.transform.position.x;
            lead_posz = lead_vh.gameObject.transform.position.z;
            lead_presence = 1;
        }

        olane_vh = GameObject.Find("olane_car");
        if (olane_vh == null)
        {
            //Debug.Log("No leading vehicle found");
            olane_speed = 0;
            olane_posx = 0;
            olane_posz = 0;
            olane_dirangle=0;
            olane_presence = 0;
        }
        else
        {
            Debug.Log("olane_car detected");
            olane_speed = olane_vh.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            olane_posx = olane_vh.gameObject.transform.position.x;
            olane_posz = olane_vh.gameObject.transform.position.z;
            olane_dirangle = olane_vh.transform.rotation.eulerAngles.y;
            olane_presence = 1;
        }

        ListenerThread = new Thread(() => ListenForMessages());
        ListenerThread.Start();
       

    }

    // Update is called once per frame
    void Update()
    {
        ego_speed = ego_car.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        car_speed = ego_speed*3.6f;
        ego_acc = (ego_speed - speed_last) / Time.fixedDeltaTime;
        ego_dirangle = ego_car.transform.rotation.eulerAngles.y;
        ego_posx = ego_car.gameObject.transform.position.x;
        ego_posz = ego_car.gameObject.transform.position.z;
        speed_last = ego_speed;
        dist_cal = Math.Sqrt(Math.Pow(ego_posx - ego_x, 2) + Math.Pow(ego_posz - ego_z, 2));
        ego_distance = ego_distance + Convert.ToSingle(dist_cal);
        ego_x = ego_posx;
        ego_z = ego_posz;
        //Debug.Log("distance=" + ego_distance + "\n");
        if (lead_vh == null)
        {
            //Debug.Log("No leading vehicle found");
            lead_speed = 0;
            lead_posx = 0;
            lead_posz = 0;
            lead_presence = 0;
        }
        else
        {
            lead_speed = lead_vh.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            lead_posx = lead_vh.gameObject.transform.position.x;
            lead_posz = lead_vh.gameObject.transform.position.z;
            lead_presence = 1;
        }

        if (olane_vh == null)
        {
            //Debug.Log("No leading vehicle found");
            olane_speed = 0;
            olane_posx = 0;
            olane_posz = 0;
            olane_dirangle = 0;
            olane_presence = 0;
        }
        else
        {
            olane_speed = olane_vh.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            olane_posx = olane_vh.gameObject.transform.position.x;
            olane_posz = olane_vh.gameObject.transform.position.z;
            olane_dirangle = olane_vh.transform.rotation.eulerAngles.y;
            olane_presence = 1;
        }

        //Debug.Log("Test value " + this.in_test + "\n");
        //Debug.Log("Test1 value " + this.in_test1 + "\n");
        //Debug.Log("SendTest value " + send_test + "\n");
        //Debug.Log("SendTest1 value " + send_test1 + "\n");
    }
}
