using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

public class sendCollision : MonoBehaviour
{
    public float sendcolision = 0;


    readonly string host = "0.0.0.0";
    readonly int port = 54319;
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
                string[] rx_array = rx_line.Split(new string[] { "," }, StringSplitOptions.None);
                //yahaan pe change karna hai
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
                string test_val_str1 = String.Format("{0:F4}", sendcolision);
                //string test1_val_str = String.Format("{0:F4}", send_test1);
                //string str = test_val_str + "," + test1_val_str;
                string str1 = test_val_str1;
                var str_to_send1 = str1;
                var byte_array = Encoding.GetEncoding("UTF-8").GetBytes(str_to_send1);
                client.Send(byte_array, str_to_send1.Length, from.Address.ToString(), from.Port);
                Debug.Log("------------------------value send:" + str_to_send1);
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
        Debug.Log("------------------------value send:" + sendcolision);
        //Debug.Log("Test value " + this.in_test + "\n");
        //Debug.Log("Test1 value " + this.in_test1 + "\n");
        //Debug.Log("SendTest value " + send_test + "\n");
        //Debug.Log("SendTest1 value " + send_test1 + "\n");
    }
}
