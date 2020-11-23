using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class MapInputManager : MonoBehaviour
{
    [SerializeField]
    private AngerBar angerbar;
    [SerializeField]
    private DisgustBar disgustbar;
    [SerializeField]
    private FearBar fearbar;
    [SerializeField]
    private HappinessBar happinessbar;
    [SerializeField]
    private NeutralBar neutralbar;
    [SerializeField]
    private SadnessBar sadnessbar;
    [SerializeField]
    private SurpriseBar surprisebar;

    //changes DaveMan made
    [SerializeField]
    private StressBar stressbar;
//    [SerializeField]
//    private ChangePercentageText changepercentagetext;

    //input ke number ko increase karne ke liye yahaan pe change karna hai
    //public GameObject goAge;
    //public GameObject goLevel;
    /*public RawImage anger;
    public RawImage disgust;
    public RawImage fear;
    public RawImage happiness;
    public RawImage neutral;
    public RawImage sadness;
    public RawImage surprise;*/

    //yahaan pe change karna hai
    //private float sim_age;
    //private float sim_level;
    private float sim_mood;
    private float sim_anger;
    private float sim_disgust;
    private float sim_fear;
    private float sim_happiness;
    private float sim_neutral;
    private float sim_sadness;
    private float sim_surprise;

    //changes DaveMan made
    private float sim_stress;


    readonly string host = "0.0.0.0";
    readonly int port = 54321;
    Thread ListenerThread;
    UdpClient clientL = new UdpClient();

    void Stop()
    {

        clientL.Close();

        ListenerThread.Join();
        ListenerThread.Abort();

        clientL = new UdpClient();

    }

    public void ListenForMessages()
    {

        while (true)
        {

            Byte[] bytesL = new Byte[1024];
            var remoteEP = new IPEndPoint(IPAddress.Parse(host), port);
            clientL.Client.Bind(remoteEP);
            var from = new IPEndPoint(0, 0);
            //float ageFromSimulink = 0;
            //float levelFromSimulink = 0;
            float moodFromSimulink = 0;
            float angerFromSimulink = 0;
            float disgustFromSimulink = 0;
            float fearFromSimulink = 0;
            float happinessFromSimulink = 0;
            float neutralFromSimulink = 0;
            float sadnessFromSimulink = 0;
            float surpriseFromSimulink = 0;

            //changes DaveMan made
            float stressFromSimulink = 0;

            while (true)
            {
                string rx_line = System.Text.Encoding.Default.GetString(clientL.Receive(ref from));
                string[] rx_array = rx_line.Split(new string[] { "," }, StringSplitOptions.None);
                //yahaan pe change karna hai
                if (rx_array.Length == 9)//changes DaveMan made before 8 now 9
                {
                    if (float.TryParse(rx_array[0], out moodFromSimulink))
                    {
                        this.sim_mood = moodFromSimulink;
                    }
                    if (float.TryParse(rx_array[1], out angerFromSimulink))
                    {
                        this.sim_anger = angerFromSimulink;
                    }
                    if (float.TryParse(rx_array[2], out disgustFromSimulink))
                    {
                        this.sim_disgust = disgustFromSimulink;
                    }
                    if (float.TryParse(rx_array[3], out fearFromSimulink))
                    {
                        this.sim_fear = fearFromSimulink;
                    }
                    if (float.TryParse(rx_array[4], out happinessFromSimulink))
                    {
                        this.sim_happiness = happinessFromSimulink;
                    }
                    if (float.TryParse(rx_array[5], out neutralFromSimulink))
                    {
                        this.sim_neutral = neutralFromSimulink;
                    }
                    if (float.TryParse(rx_array[6], out sadnessFromSimulink))
                    {
                        this.sim_sadness = sadnessFromSimulink;
                    }
                    if (float.TryParse(rx_array[7], out surpriseFromSimulink))
                    {
                        this.sim_surprise = surpriseFromSimulink;
                    } if (float.TryParse(rx_array[7], out surpriseFromSimulink))
                    {
                        this.sim_surprise = surpriseFromSimulink;
                    } //changes DaveMan made 
                    if (float.TryParse(rx_array[8], out stressFromSimulink))
                    {
                        this.sim_stress = stressFromSimulink;
                    }
                }
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
        //yahaan pe change karna hai agar values unity me read karni hai toh, warna change karna zaruri nahi hai
        Debug.Log("Mood " + this.sim_mood + "\n");

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

        //changes DaveMan made 
        stressbar.SetSize(this.sim_stress);

        

    }
}
