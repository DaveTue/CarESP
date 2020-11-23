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
public class CurveEventSend : MonoBehaviour
{
    //public GameObject gotest;
    //public GameObject gotest1;

    //private float in_test;
    //private float in_test1;

    //these are the value that I want to change and send to Simulink

   
    // curve detection
     public float curve_detect = 0; 


    //public float send_test1 = 0;
    //public float send_test1 = 0;

    readonly string host = "0.0.0.0";
    readonly int port = 54340;
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
                
                // curve detectiion variable transform to string for message
                string curve_detect_str = String.Format("{0:F4}",curve_detect);
                //all together
                string str = curve_detect_str;
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
        
        ListenerThread = new Thread(() => ListenForMessages());
        ListenerThread.Start();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
