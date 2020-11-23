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
public class DesktopInputManager : MonoBehaviour
{
    //input ke number ko increase karne ke liye yahaan pe change karna hai
    //public GameObject goAge;
    //public GameObject goLevel;
    public ParticleSystem driver_age;
    public ParticleSystem driver_blood_alcohol;
    public ParticleSystem driver_alertness_level;
    public ParticleSystem driver_vision;
    public ParticleSystem driver_workload;
    public ParticleSystem driving_proficiency;
    public ParticleSystem driver_attitude;
    public ParticleSystem freq_overspeed;
    public ParticleSystem freq_deviation_from_lane;
    public ParticleSystem freq_steer_overcorrect;
    public ParticleSystem freq_honk;
    public ParticleSystem freq_tailgate;
    public ParticleSystem freq_overtake;
    public ParticleSystem correct_maintenance;
    public ParticleSystem period_maintenance;
    public ParticleSystem freq_emergency_brake;
    public ParticleSystem freq_emergency_turn;
    public ParticleSystem driving_stability;
    public ParticleSystem vehicle_mileage;
    public ParticleSystem freq_accident;
    public ParticleSystem severity_of_accident;
    public ParticleSystem num_of_OBD_problem;
    public ParticleSystem fuel_level;
    public ParticleSystem battery_level;
    public ParticleSystem tire_pressure;
    public ParticleSystem oil_level;
    public ParticleSystem wheel_balance;
    public ParticleSystem freq_parts_replacement;
    public ParticleSystem freq_quality;
    public ParticleSystem tire_health;
    public ParticleSystem recognize_objects;
    public ParticleSystem ability_com_other_vehicle;
    public ParticleSystem ability_com_infrastructure;
    public ParticleSystem friendly_HVI_system;
    public ParticleSystem aware_driver_intent;
    public ParticleSystem aware_other_vehicle_intent;
    public ParticleSystem aware_driver_behavior;
    public ParticleSystem aware_other_vehicle_behavior;
    public ParticleSystem aware_other_vehicle_emotion;
    public ParticleSystem freq_software_update;
    public ParticleSystem status_software_update;
    public ParticleSystem road_condition;
    public ParticleSystem probability_natural_disaster;
    public ParticleSystem probability_road_accident;
    public ParticleSystem probability_construction_obstruction;
    public ParticleSystem parking_temperature;
    public ParticleSystem parking_humidity;
    public ParticleSystem environment_condition;
    public ParticleSystem weather;
    public ParticleSystem time_of_day;

    //public GameObject goDriver_age;
    //public GameObject goDriver_blood_alcohol;
    //public GameObject goDriver_alertness_level;
    //public GameObject goDriver_vision;
    //public GameObject goDriver_workload;
    //public GameObject goDriving_proficiency;
    //public GameObject goDriver_attitude;
    //public GameObject goFreq_overspeed;
    //public GameObject goFreq_deviation_from_lane;
    //public GameObject goFreq_steer_overcorrect;
    //public GameObject goFreq_honk;
    //public GameObject goFreq_tailgate;
    //public GameObject goFreq_overtake;
    //public GameObject goCorrect_maintenance;
    //public GameObject goPeriod_maintenance;
    //public GameObject goFreq_emergency_brake;
    //public GameObject goFreq_emergency_turn;
    //public GameObject goDriving_stability;
    //public GameObject goVehicle_mileage;
    //public GameObject goFreq_accident;
    //public GameObject goSeverity_of_accident;
    //public GameObject goNum_of_obd_problem;
    //public GameObject goFuel_level;
    //public GameObject goBattery_level;
    //public GameObject goTire_pressure;
    //public GameObject goOil_level;
    //public GameObject goWheel_balance;
    //public GameObject goFreq_parts_replacement;
    //public GameObject goFreq_quality;
    //public GameObject goTire_health;
    //public GameObject goRecognize_objects;
    //public GameObject goAbility_com_other_vehicle;
    //public GameObject goAbility_com_infrastructure;
    //public GameObject goFriendly_hvi_system;
    //public GameObject goAware_driver_intent;
    //public GameObject goAware_other_vehicle_intent;
    //public GameObject goAware_driver_behavior;
    //public GameObject goAware_other_vehicle_behavior;
    //public GameObject goAware_other_vehicle_emotion;
    //public GameObject goFreq_software_update;
    //public GameObject goStatus_software_update;
    //public GameObject goRoad_condition;
    //public GameObject goProbability_natural_disaster;
    //public GameObject goProbability_road_accident;
    //public GameObject goProbability_construction_obstruction;
    //public GameObject goParking_temperature;
    //public GameObject goParking_humidity;
    //public GameObject goEnvironment_condition;
    //public GameObject goWeather;
    //public GameObject goTime_of_day;

    //yahaan pe change karna hai
    //private float sim_age;
    //private float sim_level;
    private float sim_driver_age;
    private float sim_driver_blood_alcohol;
    private float sim_driver_alertness_level;
    private float sim_driver_vision;
    private float sim_driver_workload;
    private float sim_driving_proficiency;
    private float sim_driver_attitude;
    private float sim_freq_overspeed;
    private float sim_freq_deviation_from_lane;
    private float sim_freq_steer_overcorrect;
    private float sim_freq_honk;
    private float sim_freq_tailgate;
    private float sim_freq_overtake;
    private float sim_correct_maintenance;
    private float sim_period_maintenance;
    private float sim_freq_emergency_brake;
    private float sim_freq_emergency_turn;
    private float sim_driving_stability;
    private float sim_vehicle_mileage;
    private float sim_freq_accident;
    private float sim_severity_of_accident;
    private float sim_num_of_OBD_problem;
    private float sim_fuel_level;
    private float sim_battery_level;
    private float sim_tire_pressure;
    private float sim_oil_level;
    private float sim_wheel_balance;
    private float sim_freq_parts_replacement;
    private float sim_freq_quality;
    private float sim_tire_health;
    private float sim_recognize_objects;
    private float sim_ability_com_other_vehicle;
    private float sim_ability_com_infrastructure;
    private float sim_friendly_HVI_system;
    private float sim_aware_driver_intent;
    private float sim_aware_other_vehicle_intent;
    private float sim_aware_driver_behavior;
    private float sim_aware_other_vehicle_behavior;
    private float sim_aware_other_vehicle_emotion;
    private float sim_freq_software_update;
    private float sim_status_software_update;
    private float sim_road_condition;
    private float sim_probability_natural_disaster;
    private float sim_probability_road_accident;
    private float sim_probability_construction_obstruction;
    private float sim_parking_temperature;
    private float sim_parking_humidity;
    private float sim_environment_condition;
    private float sim_weather;
    private float sim_time_of_day;

    Color color5 = new Color(100f / 255f, 221f / 255f, 22f / 255f); //bright green
    Color color4 = new Color(48f / 255f, 79f / 255f, 255f / 255f);  //dark blue
    Color color3 = new Color(255f / 255f, 252f / 255f, 7f / 255f);  //bright yellow
    Color color2 = new Color(255f / 255f, 109f / 255f, 0f / 255f);  //dark orange
    Color color1 = new Color(214f / 255f, 0f / 255f, 0f / 255f);    //dark red

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
            float driver_ageFromSimulink = 0;
            float driver_blood_alcoholFromSimulink = 0;
            float driver_alertness_levelFromSimulink = 0;
            float driver_visionFromSimulink = 0;
            float driver_workloadFromSimulink = 0;
            float driving_proficiencyFromSimulink = 0;
            float driver_attitudeFromSimulink = 0;
            float freq_overspeedFromSimulink = 0;
            float freq_deviation_from_laneFromSimulink = 0;
            float freq_steer_overcorrectFromSimulink = 0;
            float freq_honkFromSimulink = 0;
            float freq_tailgateFromSimulink = 0;
            float freq_overtakeFromSimulink = 0;
            float correct_maintenanceFromSimulink = 0;
            float period_maintenanceFromSimulink = 0;
            float freq_emergency_brakeFromSimulink = 0;
            float freq_emergency_turnFromSimulink = 0;
            float driving_stabilityFromSimulink = 0;
            float vehicle_mileageFromSimulink = 0;
            float freq_accidentFromSimulink = 0;
            float severity_of_accidentFromSimulink = 0;
            float num_of_OBD_problemFromSimulink = 0;
            float fuel_levelFromSimulink = 0;
            float battery_levelFromSimulink = 0;
            float tire_pressureFromSimulink = 0;
            float oil_levelFromSimulink = 0;
            float wheel_balanceFromSimulink = 0;
            float freq_parts_replacementFromSimulink = 0;
            float freq_qualityFromSimulink = 0;
            float tire_healthFromSimulink = 0;
            float recognize_objectsFromSimulink = 0;
            float ability_com_other_vehicleFromSimulink = 0;
            float ability_com_infrastructureFromSimulink = 0;
            float friendly_HVI_systemFromSimulink = 0;
            float aware_driver_intentFromSimulink = 0;
            float aware_other_vehicle_intentFromSimulink = 0;
            float aware_driver_behaviorFromSimulink = 0;
            float aware_other_vehicle_behaviorFromSimulink = 0;
            float aware_other_vehicle_emotionFromSimulink = 0;
            float freq_software_updateFromSimulink = 0;
            float status_software_updateFromSimulink = 0;
            float road_conditionFromSimulink = 0;
            float probability_natural_disasterFromSimulink = 0;
            float probability_road_accidentFromSimulink = 0;
            float probability_construction_obstructionFromSimulink = 0;
            float parking_temperatureFromSimulink = 0;
            float parking_humidityFromSimulink = 0;
            float environment_conditionFromSimulink = 0;
            float weatherFromSimulink = 0;
            float time_of_dayFromSimulink = 0;

            while (true)
            {
                string rx_line = System.Text.Encoding.Default.GetString(clientL.Receive(ref from));
                string[] rx_array = rx_line.Split(new string[] { "," }, StringSplitOptions.None);
                //yahaan pe change karna hai
                if (rx_array.Length == 50)
                {
                    if (float.TryParse(rx_array[0], out driver_ageFromSimulink))
                    {
                        this.sim_driver_age = driver_ageFromSimulink;
                    }
                    if (float.TryParse(rx_array[1], out driver_blood_alcoholFromSimulink))
                    {
                        this.sim_driver_blood_alcohol = driver_blood_alcoholFromSimulink;
                    }
                    if (float.TryParse(rx_array[2], out driver_alertness_levelFromSimulink))
                    {
                        this.sim_driver_alertness_level = driver_alertness_levelFromSimulink;
                    }
                    if (float.TryParse(rx_array[3], out driver_visionFromSimulink))
                    {
                        this.sim_driver_vision = driver_visionFromSimulink;
                    }
                    if (float.TryParse(rx_array[4], out driver_workloadFromSimulink))
                    {
                        this.sim_driver_workload = driver_workloadFromSimulink;
                    }
                    if (float.TryParse(rx_array[5], out driving_proficiencyFromSimulink))
                    {
                        this.sim_driving_proficiency = driving_proficiencyFromSimulink;
                    }
                    if (float.TryParse(rx_array[6], out driver_attitudeFromSimulink))
                    {
                        this.sim_driver_attitude = driver_attitudeFromSimulink;
                    }
                    if (float.TryParse(rx_array[7], out freq_overspeedFromSimulink))
                    {
                        this.sim_freq_overspeed = freq_overspeedFromSimulink;
                    }
                    if (float.TryParse(rx_array[8], out freq_deviation_from_laneFromSimulink))
                    {
                        this.sim_freq_deviation_from_lane = freq_deviation_from_laneFromSimulink;
                    }
                    if (float.TryParse(rx_array[9], out freq_steer_overcorrectFromSimulink))
                    {
                        this.sim_freq_steer_overcorrect = freq_steer_overcorrectFromSimulink;
                    }
                    if (float.TryParse(rx_array[10], out freq_honkFromSimulink))
                    {
                        this.sim_freq_honk = freq_honkFromSimulink;
                    }
                    if (float.TryParse(rx_array[11], out freq_tailgateFromSimulink))
                    {
                        this.sim_freq_tailgate = freq_tailgateFromSimulink;
                    }
                    if (float.TryParse(rx_array[12], out freq_overtakeFromSimulink))
                    {
                        this.sim_freq_overtake = freq_overtakeFromSimulink;
                    }
                    if (float.TryParse(rx_array[13], out correct_maintenanceFromSimulink))
                    {
                        this.sim_correct_maintenance = correct_maintenanceFromSimulink;
                    }
                    if (float.TryParse(rx_array[14], out period_maintenanceFromSimulink))
                    {
                        this.sim_period_maintenance = period_maintenanceFromSimulink;
                    }
                    if (float.TryParse(rx_array[15], out freq_emergency_brakeFromSimulink))
                    {
                        this.sim_freq_emergency_brake = freq_emergency_brakeFromSimulink;
                    }
                    if (float.TryParse(rx_array[16], out freq_emergency_turnFromSimulink))
                    {
                        this.sim_freq_emergency_turn = freq_emergency_turnFromSimulink;
                    }
                    if (float.TryParse(rx_array[17], out driving_stabilityFromSimulink))
                    {
                        this.sim_driving_stability = driving_stabilityFromSimulink;
                    }
                    if (float.TryParse(rx_array[18], out vehicle_mileageFromSimulink))
                    {
                        this.sim_vehicle_mileage = vehicle_mileageFromSimulink;
                    }
                    if (float.TryParse(rx_array[19], out freq_accidentFromSimulink))
                    {
                        this.sim_freq_accident = freq_accidentFromSimulink;
                    }
                    if (float.TryParse(rx_array[20], out severity_of_accidentFromSimulink))
                    {
                        this.sim_severity_of_accident = severity_of_accidentFromSimulink;
                    }
                    if (float.TryParse(rx_array[21], out num_of_OBD_problemFromSimulink))
                    {
                        this.sim_num_of_OBD_problem = num_of_OBD_problemFromSimulink;
                    }
                    if (float.TryParse(rx_array[22], out fuel_levelFromSimulink))
                    {
                        this.sim_fuel_level = fuel_levelFromSimulink;
                    }
                    if (float.TryParse(rx_array[23], out battery_levelFromSimulink))
                    {
                        this.sim_battery_level = battery_levelFromSimulink;
                    }
                    if (float.TryParse(rx_array[24], out tire_pressureFromSimulink))
                    {
                        this.sim_tire_pressure = tire_pressureFromSimulink;
                    }
                    if (float.TryParse(rx_array[25], out oil_levelFromSimulink))
                    {
                        this.sim_oil_level = oil_levelFromSimulink;
                    }
                    if (float.TryParse(rx_array[26], out wheel_balanceFromSimulink))
                    {
                        this.sim_wheel_balance = wheel_balanceFromSimulink;
                    }
                    if (float.TryParse(rx_array[27], out freq_parts_replacementFromSimulink))
                    {
                        this.sim_freq_parts_replacement = freq_parts_replacementFromSimulink;
                    }
                    if (float.TryParse(rx_array[28], out freq_qualityFromSimulink))
                    {
                        this.sim_freq_quality = freq_qualityFromSimulink;
                    }
                    if (float.TryParse(rx_array[29], out tire_healthFromSimulink))
                    {
                        this.sim_tire_health = tire_healthFromSimulink;
                    }
                    if (float.TryParse(rx_array[30], out recognize_objectsFromSimulink))
                    {
                        this.sim_recognize_objects = recognize_objectsFromSimulink;
                    }
                    if (float.TryParse(rx_array[31], out ability_com_other_vehicleFromSimulink))
                    {
                        this.sim_ability_com_other_vehicle = ability_com_other_vehicleFromSimulink;
                    }
                    if (float.TryParse(rx_array[32], out ability_com_infrastructureFromSimulink))
                    {
                        this.sim_ability_com_infrastructure = ability_com_infrastructureFromSimulink;
                    }
                    if (float.TryParse(rx_array[33], out friendly_HVI_systemFromSimulink))
                    {
                        this.sim_friendly_HVI_system = friendly_HVI_systemFromSimulink;
                    }
                    if (float.TryParse(rx_array[34], out aware_driver_intentFromSimulink))
                    {
                        this.sim_aware_driver_intent = aware_driver_intentFromSimulink;
                    }
                    if (float.TryParse(rx_array[35], out aware_other_vehicle_intentFromSimulink))
                    {
                        this.sim_aware_other_vehicle_intent = aware_other_vehicle_intentFromSimulink;
                    }
                    if (float.TryParse(rx_array[36], out aware_driver_behaviorFromSimulink))
                    {
                        this.sim_aware_driver_behavior = aware_driver_behaviorFromSimulink;
                    }
                    if (float.TryParse(rx_array[37], out aware_other_vehicle_behaviorFromSimulink))
                    {
                        this.sim_aware_other_vehicle_behavior = aware_other_vehicle_behaviorFromSimulink;
                    }
                    if (float.TryParse(rx_array[38], out aware_other_vehicle_emotionFromSimulink))
                    {
                        this.sim_aware_other_vehicle_emotion = aware_other_vehicle_emotionFromSimulink;
                    }
                    if (float.TryParse(rx_array[39], out freq_software_updateFromSimulink))
                    {
                        this.sim_freq_software_update = freq_software_updateFromSimulink;
                    }
                    if (float.TryParse(rx_array[40], out status_software_updateFromSimulink))
                    {
                        this.sim_status_software_update = status_software_updateFromSimulink;
                    }
                    if (float.TryParse(rx_array[41], out road_conditionFromSimulink))
                    {
                        this.sim_road_condition = road_conditionFromSimulink;
                    }
                    if (float.TryParse(rx_array[42], out probability_natural_disasterFromSimulink))
                    {
                        this.sim_probability_natural_disaster = probability_natural_disasterFromSimulink;
                    }
                    if (float.TryParse(rx_array[43], out probability_road_accidentFromSimulink))
                    {
                        this.sim_probability_road_accident = probability_road_accidentFromSimulink;
                    }
                    if (float.TryParse(rx_array[44], out probability_construction_obstructionFromSimulink))
                    {
                        this.sim_probability_construction_obstruction = probability_construction_obstructionFromSimulink;
                    }
                    if (float.TryParse(rx_array[45], out parking_temperatureFromSimulink))
                    {
                        this.sim_parking_temperature = parking_temperatureFromSimulink;
                    }
                    if (float.TryParse(rx_array[46], out parking_humidityFromSimulink))
                    {
                        this.sim_parking_humidity = parking_humidityFromSimulink;
                    }
                    if (float.TryParse(rx_array[47], out environment_conditionFromSimulink))
                    {
                        this.sim_environment_condition = environment_conditionFromSimulink;
                    }
                    if (float.TryParse(rx_array[48], out weatherFromSimulink))
                    {
                        this.sim_weather = weatherFromSimulink;
                    }
                    if (float.TryParse(rx_array[49], out time_of_dayFromSimulink))
                    {
                        this.sim_time_of_day = time_of_dayFromSimulink;
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
        Debug.Log("Driver age " + this.sim_driver_age + "\n");
        //Debug.Log("Driver blood alcohol level " + this.sim_driver_blood_alcohol + "\n");
        //Debug.Log("Driver alertness level " + this.sim_driver_alertness_level + "\n");
        //Debug.Log("Driver vision " + this.sim_driver_vision + "\n");
        //Debug.Log("Driver workload " + this.sim_driver_workload + "\n");
        //Debug.Log("Driver proficiency " + this.sim_driving_proficiency + "\n");
        //Debug.Log("Driver attitude " + this.sim_driver_attitude + "\n");
        //Debug.Log("Frequency of overspeeding " + this.sim_freq_overspeed + "\n");
        //Debug.Log("Frequency of deviation from lane " + this.sim_freq_deviation_from_lane + "\n");
        //Debug.Log("Frequency of overcorrecting " + this.sim_freq_steer_overcorrect + "\n");
        //1
        if (this.sim_driver_age == 1)
        {
            driver_age.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_driver_age == 2)
        {
            driver_age.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_driver_age == 3)
        {
            driver_age.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_driver_age == 4)
        {
            driver_age.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_driver_age == 5)
        {
            driver_age.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //iske neeche baaki saare add karna hain aur unity me particles bhi create karne hain exact location spe
        //2
        if (this.sim_driver_blood_alcohol == 1)
        {
            driver_blood_alcohol.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_driver_blood_alcohol == 2)
        {
            driver_blood_alcohol.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_driver_blood_alcohol == 3)
        {
            driver_blood_alcohol.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_driver_blood_alcohol == 4)
        {
            driver_blood_alcohol.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_driver_blood_alcohol == 5)
        {
            driver_blood_alcohol.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //3
        if (this.sim_driver_alertness_level == 1)
        {
            driver_alertness_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_driver_alertness_level == 2)
        {
            driver_alertness_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_driver_alertness_level == 3)
        {
            driver_alertness_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_driver_alertness_level == 4)
        {
            driver_alertness_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_driver_alertness_level == 5)
        {
            driver_alertness_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //4
        if (this.sim_driver_vision == 1)
        {
            driver_vision.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_driver_vision == 2)
        {
            driver_vision.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_driver_vision == 3)
        {
            driver_vision.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_driver_vision == 4)
        {
            driver_vision.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_driver_vision == 5)
        {
            driver_vision.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //5
        if (this.sim_driver_workload == 1)
        {
            driver_workload.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_driver_workload == 2)
        {
            driver_workload.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_driver_workload == 3)
        {
            driver_workload.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_driver_workload == 4)
        {
            driver_workload.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_driver_workload == 5)
        {
            driver_workload.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //6
        if (this.sim_driving_proficiency == 1)
        {
            driving_proficiency.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_driving_proficiency == 2)
        {
            driving_proficiency.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_driving_proficiency == 3)
        {
            driving_proficiency.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_driving_proficiency == 4)
        {
            driving_proficiency.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_driving_proficiency == 5)
        {
            driving_proficiency.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //7
        if (this.sim_driver_attitude == 1)
        {
            driver_attitude.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_driver_attitude == 2)
        {
            driver_attitude.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_driver_attitude == 3)
        {
            driver_attitude.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_driver_attitude == 4)
        {
            driver_attitude.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_driver_attitude == 5)
        {
            driver_attitude.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //8
        if (this.sim_freq_overspeed == 1)
        {
            freq_overspeed.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_freq_overspeed == 2)
        {
            freq_overspeed.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_freq_overspeed == 3)
        {
            freq_overspeed.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_freq_overspeed == 4)
        {
            freq_overspeed.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_freq_overspeed == 5)
        {
            freq_overspeed.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //9
        if (this.sim_freq_deviation_from_lane == 1)
        {
            freq_deviation_from_lane.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_freq_deviation_from_lane == 2)
        {
            freq_deviation_from_lane.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_freq_deviation_from_lane == 3)
        {
            freq_deviation_from_lane.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_freq_deviation_from_lane == 4)
        {
            freq_deviation_from_lane.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_freq_deviation_from_lane == 5)
        {
            freq_deviation_from_lane.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //10
        if (this.sim_freq_steer_overcorrect == 1)
        {
            freq_steer_overcorrect.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_freq_steer_overcorrect == 2)
        {
            freq_steer_overcorrect.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_freq_steer_overcorrect == 3)
        {
            freq_steer_overcorrect.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_freq_steer_overcorrect == 4)
        {
            freq_steer_overcorrect.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_freq_steer_overcorrect == 5)
        {
            freq_steer_overcorrect.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //11
        if (this.sim_freq_honk == 1)
        {
            freq_honk.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_freq_honk == 2)
        {
            freq_honk.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_freq_honk == 3)
        {
            freq_honk.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_freq_honk == 4)
        {
            freq_honk.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_freq_honk == 5)
        {
            freq_honk.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //12
        if (this.sim_freq_tailgate == 1)
        {
            freq_tailgate.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_freq_tailgate == 2)
        {
            freq_tailgate.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_freq_tailgate == 3)
        {
            freq_tailgate.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_freq_tailgate == 4)
        {
            freq_tailgate.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_freq_tailgate == 5)
        {
            freq_tailgate.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //13
        if (this.sim_freq_overtake == 1)
        {
            freq_overtake.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_freq_overtake == 2)
        {
            freq_overtake.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_freq_overtake == 3)
        {
            freq_overtake.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_freq_overtake == 4)
        {
            freq_overtake.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_freq_overtake == 5)
        {
            freq_overtake.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //14
        if (this.sim_correct_maintenance == 1)
        {
            correct_maintenance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_correct_maintenance == 2)
        {
            correct_maintenance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_correct_maintenance == 3)
        {
            correct_maintenance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_correct_maintenance == 4)
        {
            correct_maintenance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_correct_maintenance == 5)
        {
            correct_maintenance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //15
        if (this.sim_period_maintenance == 1)
        {
            period_maintenance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_period_maintenance == 2)
        {
            period_maintenance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_period_maintenance == 3)
        {
            period_maintenance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_period_maintenance == 4)
        {
            period_maintenance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_period_maintenance == 5)
        {
            period_maintenance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //16
        if (this.sim_freq_emergency_brake == 1)
        {
            freq_emergency_brake.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_freq_emergency_brake == 2)
        {
            freq_emergency_brake.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_freq_emergency_brake == 3)
        {
            freq_emergency_brake.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_freq_emergency_brake == 4)
        {
            freq_emergency_brake.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_freq_emergency_brake == 5)
        {
            freq_emergency_brake.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //17
        if (this.sim_freq_emergency_turn == 1)
        {
            freq_emergency_turn.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_freq_emergency_turn == 2)
        {
            freq_emergency_turn.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_freq_emergency_turn == 3)
        {
            freq_emergency_turn.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_freq_emergency_turn == 4)
        {
            freq_emergency_turn.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_freq_emergency_turn == 5)
        {
            freq_emergency_turn.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //18
        if (this.sim_driving_stability == 1)
        {
            driving_stability.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_driving_stability == 2)
        {
            driving_stability.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_driving_stability == 3)
        {
            driving_stability.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_driving_stability == 4)
        {
            driving_stability.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_driving_stability == 5)
        {
            driving_stability.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //19
        if (this.sim_vehicle_mileage == 1)
        {
            vehicle_mileage.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_vehicle_mileage == 2)
        {
            vehicle_mileage.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_vehicle_mileage == 3)
        {
            vehicle_mileage.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_vehicle_mileage == 4)
        {
            vehicle_mileage.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_vehicle_mileage == 5)
        {
            vehicle_mileage.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //20
        if (this.sim_freq_accident == 1)
        {
            freq_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_freq_accident == 2)
        {
            freq_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_freq_accident == 3)
        {
            freq_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_freq_accident == 4)
        {
            freq_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_freq_accident == 5)
        {
            freq_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //21
        if (this.sim_severity_of_accident == 1)
        {
            severity_of_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_severity_of_accident == 2)
        {
            severity_of_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_severity_of_accident == 3)
        {
            severity_of_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_severity_of_accident == 4)
        {
            severity_of_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_severity_of_accident == 5)
        {
            severity_of_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //22
        if (this.sim_num_of_OBD_problem == 1)
        {
            num_of_OBD_problem.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_num_of_OBD_problem == 2)
        {
            num_of_OBD_problem.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_num_of_OBD_problem == 3)
        {
            num_of_OBD_problem.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_num_of_OBD_problem == 4)
        {
            num_of_OBD_problem.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_num_of_OBD_problem == 5)
        {
            num_of_OBD_problem.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //23
        if (this.sim_fuel_level == 1)
        {
            fuel_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_fuel_level == 2)
        {
            fuel_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_fuel_level == 3)
        {
            fuel_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_fuel_level == 4)
        {
            fuel_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_fuel_level == 5)
        {
            fuel_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //24
        if (this.sim_battery_level == 1)
        {
            battery_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_battery_level == 2)
        {
            battery_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_battery_level == 3)
        {
            battery_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_battery_level == 4)
        {
            battery_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_battery_level == 5)
        {
            battery_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //25
        if (this.sim_tire_pressure == 1)
        {
            tire_pressure.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_tire_pressure == 2)
        {
            tire_pressure.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_tire_pressure == 3)
        {
            tire_pressure.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_tire_pressure == 4)
        {
            tire_pressure.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_tire_pressure == 5)
        {
            tire_pressure.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //26
        if (this.sim_oil_level == 1)
        {
            oil_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_oil_level == 2)
        {
            oil_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_oil_level == 3)
        {
            oil_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_oil_level == 4)
        {
            oil_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_oil_level == 5)
        {
            oil_level.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //27
        if (this.sim_wheel_balance == 1)
        {
            wheel_balance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_wheel_balance == 2)
        {
            wheel_balance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_wheel_balance == 3)
        {
            wheel_balance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_wheel_balance == 4)
        {
            wheel_balance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_wheel_balance == 5)
        {
            wheel_balance.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //28
        if (this.sim_freq_parts_replacement == 1)
        {
            freq_parts_replacement.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_freq_parts_replacement == 2)
        {
            freq_parts_replacement.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_freq_parts_replacement == 3)
        {
            freq_parts_replacement.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_freq_parts_replacement == 4)
        {
            freq_parts_replacement.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_freq_parts_replacement == 5)
        {
            freq_parts_replacement.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //29
        if (this.sim_freq_quality == 1)
        {
            freq_quality.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_freq_quality == 2)
        {
            freq_quality.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_freq_quality == 3)
        {
            freq_quality.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_freq_quality == 4)
        {
            freq_quality.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_freq_quality == 5)
        {
            freq_quality.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //30
        if (this.sim_tire_health == 1)
        {
            tire_health.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_tire_health == 2)
        {
            tire_health.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_tire_health == 3)
        {
            tire_health.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_tire_health == 4)
        {
            tire_health.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_tire_health == 5)
        {
            tire_health.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //31
        if (this.sim_recognize_objects == 1)
        {
            recognize_objects.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_recognize_objects == 2)
        {
            recognize_objects.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_recognize_objects == 3)
        {
            recognize_objects.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_recognize_objects == 4)
        {
            recognize_objects.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_recognize_objects == 5)
        {
            recognize_objects.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //32
        if (this.sim_ability_com_other_vehicle == 1)
        {
            ability_com_other_vehicle.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_ability_com_other_vehicle == 2)
        {
            ability_com_other_vehicle.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_ability_com_other_vehicle == 3)
        {
            ability_com_other_vehicle.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_ability_com_other_vehicle == 4)
        {
            ability_com_other_vehicle.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_ability_com_other_vehicle == 5)
        {
            ability_com_other_vehicle.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //33
        if (this.sim_ability_com_infrastructure == 1)
        {
            ability_com_infrastructure.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_ability_com_infrastructure == 2)
        {
            ability_com_infrastructure.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_ability_com_infrastructure == 3)
        {
            ability_com_infrastructure.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_ability_com_infrastructure == 4)
        {
            ability_com_infrastructure.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_ability_com_infrastructure == 5)
        {
            ability_com_infrastructure.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //34
        if (this.sim_friendly_HVI_system == 1)
        {
            friendly_HVI_system.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_friendly_HVI_system == 2)
        {
            friendly_HVI_system.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_friendly_HVI_system == 3)
        {
            friendly_HVI_system.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_friendly_HVI_system == 4)
        {
            friendly_HVI_system.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_friendly_HVI_system == 5)
        {
            friendly_HVI_system.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //35
        if (this.sim_aware_driver_intent == 1)
        {
            aware_driver_intent.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_aware_driver_intent == 2)
        {
            aware_driver_intent.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_aware_driver_intent == 3)
        {
            aware_driver_intent.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_aware_driver_intent == 4)
        {
            aware_driver_intent.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_aware_driver_intent == 5)
        {
            aware_driver_intent.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //36
        if (this.sim_aware_other_vehicle_intent == 1)
        {
            aware_other_vehicle_intent.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_aware_other_vehicle_intent == 2)
        {
            aware_other_vehicle_intent.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_aware_other_vehicle_intent == 3)
        {
            aware_other_vehicle_intent.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_aware_other_vehicle_intent == 4)
        {
            aware_other_vehicle_intent.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_aware_other_vehicle_intent == 5)
        {
            aware_other_vehicle_intent.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //37
        if (this.sim_aware_driver_behavior == 1)
        {
            aware_driver_behavior.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_aware_driver_behavior == 2)
        {
            aware_driver_behavior.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_aware_driver_behavior == 3)
        {
            aware_driver_behavior.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_aware_driver_behavior == 4)
        {
            aware_driver_behavior.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_aware_driver_behavior == 5)
        {
            aware_driver_behavior.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //38
        if (this.sim_aware_other_vehicle_behavior == 1)
        {
            aware_other_vehicle_behavior.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_aware_other_vehicle_behavior == 2)
        {
            aware_other_vehicle_behavior.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_aware_other_vehicle_behavior == 3)
        {
            aware_other_vehicle_behavior.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_aware_other_vehicle_behavior == 4)
        {
            aware_other_vehicle_behavior.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_aware_other_vehicle_behavior == 5)
        {
            aware_other_vehicle_behavior.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //39
        if (this.sim_aware_other_vehicle_emotion == 1)
        {
            aware_other_vehicle_emotion.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_aware_other_vehicle_emotion == 2)
        {
            aware_other_vehicle_emotion.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_aware_other_vehicle_emotion == 3)
        {
            aware_other_vehicle_emotion.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_aware_other_vehicle_emotion == 4)
        {
            aware_other_vehicle_emotion.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_aware_other_vehicle_emotion == 5)
        {
            aware_other_vehicle_emotion.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //40
        if (this.sim_freq_software_update == 1)
        {
            freq_software_update.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_freq_software_update == 2)
        {
            freq_software_update.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_freq_software_update == 3)
        {
            freq_software_update.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_freq_software_update == 4)
        {
            freq_software_update.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_freq_software_update == 5)
        {
            freq_software_update.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //41
        if (this.sim_status_software_update == 1)
        {
            status_software_update.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_status_software_update == 2)
        {
            status_software_update.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_status_software_update == 3)
        {
            status_software_update.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_status_software_update == 4)
        {
            status_software_update.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_status_software_update == 5)
        {
            status_software_update.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //42
        if (this.sim_road_condition == 1)
        {
            road_condition.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_road_condition == 2)
        {
            road_condition.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_road_condition == 3)
        {
            road_condition.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_road_condition == 4)
        {
            road_condition.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_road_condition == 5)
        {
            road_condition.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //43
        if (this.sim_probability_natural_disaster == 1)
        {
            probability_natural_disaster.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_probability_natural_disaster == 2)
        {
            probability_natural_disaster.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_probability_natural_disaster == 3)
        {
            probability_natural_disaster.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_probability_natural_disaster == 4)
        {
            probability_natural_disaster.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_probability_natural_disaster == 5)
        {
            probability_natural_disaster.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //44
        if (this.sim_probability_road_accident == 1)
        {
            probability_road_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_probability_road_accident == 2)
        {
            probability_road_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_probability_road_accident == 3)
        {
            probability_road_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_probability_road_accident == 4)
        {
            probability_road_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_probability_road_accident == 5)
        {
            probability_road_accident.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //45
        if (this.sim_probability_construction_obstruction == 1)
        {
            probability_construction_obstruction.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_probability_construction_obstruction == 2)
        {
            probability_construction_obstruction.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_probability_construction_obstruction == 3)
        {
            probability_construction_obstruction.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_probability_construction_obstruction == 4)
        {
            probability_construction_obstruction.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_probability_construction_obstruction == 5)
        {
            probability_construction_obstruction.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //46
        if (this.sim_parking_temperature == 1)
        {
            parking_temperature.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_parking_temperature == 2)
        {
            parking_temperature.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_parking_temperature == 3)
        {
            parking_temperature.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_parking_temperature == 4)
        {
            parking_temperature.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_parking_temperature == 5)
        {
            parking_temperature.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //47
        if (this.sim_parking_humidity == 1)
        {
            parking_humidity.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_parking_humidity == 2)
        {
            parking_humidity.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_parking_humidity == 3)
        {
            parking_humidity.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_parking_humidity == 4)
        {
            parking_humidity.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_parking_humidity == 5)
        {
            parking_humidity.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //48
        if (this.sim_environment_condition == 1)
        {
            environment_condition.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_environment_condition == 2)
        {
            environment_condition.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_environment_condition == 3)
        {
            environment_condition.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_environment_condition == 4)
        {
            environment_condition.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_environment_condition == 5)
        {
            environment_condition.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //49
        if (this.sim_weather == 1)
        {
            weather.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_weather == 2)
        {
            weather.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_weather == 3)
        {
            weather.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_weather == 4)
        {
            weather.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_weather == 5)
        {
            weather.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //50
        if (this.sim_time_of_day == 1)
        {
            time_of_day.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (this.sim_time_of_day == 2)
        {
            time_of_day.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (this.sim_time_of_day == 3)
        {
            time_of_day.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (this.sim_time_of_day == 4)
        {
            time_of_day.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (this.sim_time_of_day == 5)
        {
            time_of_day.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = color5 }, 1);
        }
        //end
    }
}
