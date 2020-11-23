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
public class InputVariables : MonoBehaviour
{
    public float t = 0;
    public float pedestrian_active = 0;
    public float r_personality=0;
    public float rate_acc=1.2f;
    public float rate_deacc=1.2f;
    public float average_speed=50f;
    public float avg_gap=3.5f;
    public float un_ObjRecog=0.9f;
    public int acc_now = 600;
    public float av_road_acc = 611.5f;
    public float sd_road_acc = 116.64f;
    public float speed_limit = 100f;
    public float max_car_speed = 220f;

    //states variables
     public int dr_age_st = 1;
   // public enum dr_age_st { Perfect , good , fair , bad , verybad}
    public int dr_emotion_st = 1;
    public int dr_alchoholL_st = 1;
    public int dr_alertness_st = 1;
    public int dr_vision_st = 1;
    public int dr_workload_st = 1;
    public int dr_attitude_st = 1;
    public int period_mantainance_st = 1;
    public int speeding_freq_st = 1;
    //private int gap_st = 1; //the computation is implemented here 
    public int vh_mass_st = 1;
    public int noise_st = 1;
    public int vh_HMinterface_st = 1;
    public int software_update_st = 1;
    public int digital_interface_st = 1;
    public int v2v_st = 1;
    public int v2i_st = 1;
    public int bigdata_st = 1;
    public int collective_driving_st = 1;
    public int prob_construction_st = 1;
    public int cab_temp_st = 1;
    public int cab_humidity_st = 1;
    public int dr_environment_cond_st = 1;
    public int road_surface_st = 1;
    public int road_cond_st = 1;
    public int weather_st = 1;
    public int time_day_st = 1;

    readonly string host = "0.0.0.0";
    readonly int port = 54330;
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
                //non state variables transform to string for message
                string r_personality_str = String.Format("{0:F4}", r_personality);
                string rate_acc_str = String.Format("{0:F4}", rate_acc);
                string rate_deacc_str = String.Format("{0:F4}", rate_deacc);
                string avg_gap_str = String.Format("{0:F4}", avg_gap);
                string un_ObjRecog_str = String.Format("{0:F4}", un_ObjRecog);
                string acc_now_str = String.Format("{0:F4}", acc_now);
                string av_road_acc_str = String.Format("{0:F4}", av_road_acc);
                string sd_road_acc_str = String.Format("{0:F4}", sd_road_acc);

                string non_st_var = r_personality_str + "," + rate_acc_str + "," + rate_deacc_str + "," + avg_gap_str + "," + un_ObjRecog_str + "," + acc_now_str + "," + av_road_acc_str + "," + sd_road_acc_str;
                //state variables variables transform to string for message
                string dr_age_st_str = String.Format("{0:F4}", dr_age_st);
                string dr_emotion_st_str = String.Format("{0:F4}", dr_emotion_st);
                string dr_alchoholL_str = String.Format("{0:F4}", dr_alchoholL_st);
                string dr_alertness_st_str = String.Format("{0:F4}", dr_alertness_st);
                string dr_vision_st_str = String.Format("{0:F4}", dr_vision_st);
                string dr_workload_st_str = String.Format("{0:F4}", dr_workload_st);
                string dr_attitude_st_str = String.Format("{0:F4}", dr_attitude_st);
                string period_mantainance_st_str = String.Format("{0:F4}", period_mantainance_st);
                string speeding_freq_st_str = String.Format("{0:F4}", speeding_freq_st);
                string vh_mass_st_str = String.Format("{0:F4}", vh_mass_st);
                string noise_st_str = String.Format("{0:F4}", noise_st);
                string vh_HMinterface_st_str = String.Format("{0:F4}", vh_HMinterface_st);
                string software_update_st_str = String.Format("{0:F4}", software_update_st);
                string digital_interface_st_str = String.Format("{0:F4}", digital_interface_st);
                string v2v_st_str = String.Format("{0:F4}", v2v_st);
                string v2i_st_str = String.Format("{0:F4}", v2i_st);
                string bigdata_st_str = String.Format("{0:F4}", bigdata_st);
                string collective_driving_st_str = String.Format("{0:F4}", collective_driving_st);
                string prob_construction_st_str = String.Format("{0:F4}", prob_construction_st);
                string cab_temp_st_str = String.Format("{0:F4}", cab_temp_st);
                string cab_humidity_st_str = String.Format("{0:F4}", cab_humidity_st);
                string dr_environment_cond_st_str = String.Format("{0:F4}", dr_environment_cond_st);
                string road_surface_st_str = String.Format("{0:F4}", road_surface_st);
                string road_cond_st_str = String.Format("{0:F4}", road_cond_st);
                string weather_st_str = String.Format("{0:F4}", weather_st);
                string time_day_st_str = String.Format("{0:F4}", time_day_st);
               
                string st_var = dr_age_st_str + "," + dr_emotion_st_str + "," + dr_alchoholL_str + "," + dr_alertness_st_str + "," + dr_vision_st_str + "," + dr_workload_st_str + "," + dr_attitude_st_str + "," + period_mantainance_st_str + "," + speeding_freq_st_str + "," + vh_mass_st_str + "," + noise_st_str + "," + vh_HMinterface_st_str + "," + software_update_st_str + "," + digital_interface_st_str + "," + v2v_st_str + "," + v2i_st_str + "," + bigdata_st_str + "," + collective_driving_st_str + "," + prob_construction_st_str + "," + cab_temp_st_str + "," + cab_humidity_st_str + "," + dr_environment_cond_st_str + "," + road_surface_st_str + "," + road_cond_st_str + "," + weather_st_str + "," + time_day_st_str;

                string pedestrian_active_str = String.Format("{0:F4}", pedestrian_active);
                string average_speed_str = string.Format("{0:F4}", average_speed/3.6f);
                string speed_limit_str = string.Format("{0:F4}", speed_limit / 3.6f);
                string max_car_speed_str = string.Format("{0:F4}", max_car_speed / 3.6f);

                string new_var = pedestrian_active_str + "," + average_speed_str + "," + speed_limit_str + "," + max_car_speed_str;
                //all together
                string str = non_st_var + "," + st_var + "," + new_var;
                var str_to_simulink = str;

                var byte_array = Encoding.GetEncoding("UTF-8").GetBytes(str_to_simulink);
                client.Send(byte_array, str_to_simulink.Length, from.Address.ToString(), from.Port);
                //Debug.Log("message " + str + "\n");

            }
        }

    }

    void Start()
    {
        //average_speed = average_speed / 3.6f;
        //speed_limit = speed_limit / 3.6f;
        //max_car_speed = max_car_speed / 3.6f;
        ListenerThread = new Thread(() => ListenForMessages());
        ListenerThread.Start();
    }

    // Update is called once per frame
    void Update()
    {

        t =t + Time.deltaTime;
        if (t >= 0 & t<30)
        {
            acc_now = 20;
            av_road_acc = 60f;
            sd_road_acc = 12f;
            weather_st = 1;
            //un_ObjRecog = 1f;
            //v2v_st = 2;
            //  v2i_st = 2;
            // bigdata_st = 2;
            // collective_driving_st = 2;
        }
        if (t >= 30 & t < 60)
        {
            weather_st = 2;
            /*un_ObjRecog = 0.5f;
            v2v_st = 2;
            v2i_st = 2;
            bigdata_st = 2;
            collective_driving_st = 2;
            */
        }
        if (t >= 60 & t<90)
        {
            weather_st = 3;
            /*
           // un_ObjRecog = 0.5f;
            v2v_st = 1;
            v2i_st = 2;
            bigdata_st = 2;
            collective_driving_st = 2;*/
        }
        if (t >= 90 & t<120)
        {
            weather_st = 4;
            /*
             // un_ObjRecog = 1f;
             v2v_st = 1;
             v2i_st = 1;
             bigdata_st = 2;
             collective_driving_st = 2;*/
        }
        if (t >= 120 &  t < 150)
        {
            weather_st = 5;
            /*//un_ObjRecog = 1f;
            v2v_st = 1;
            v2i_st = 1;
            bigdata_st = 1;
            collective_driving_st = 2;*/
        }
        if (t >= 150 & t < 180)
        {
            weather_st = 5;
            road_surface_st=2;
            /*
              //  un_ObjRecog = 1f;
              v2v_st = 1;
              v2i_st = 1;
              bigdata_st = 1;
              collective_driving_st = 1;*/
        }
        if (t >= 180 & t<210)
        {
            weather_st = 5;
            road_surface_st = 3;
            
        }
        if (t >= 210 & t<240)
        {
            weather_st = 5;
            road_surface_st = 4;
            
        }

        if (t >= 240 & t < 270)
        {
            weather_st = 5;
            road_surface_st = 5;
           
        }
        if (t >= 270 )
        {
            weather_st = 1;
            road_surface_st = 1;

        }


        //average_speed = average_speed / 3.6f;
        //speed_limit = speed_limit / 3.6f;
        //max_car_speed = max_car_speed / 3.6f;



    }
}
