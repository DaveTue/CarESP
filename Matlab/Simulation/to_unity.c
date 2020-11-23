#define S_FUNCTION_NAME to_unity /* Defines and Includes */
#define S_FUNCTION_LEVEL 2          

#include "simstruc.h"

#define _WINSOCK_DEPRECATED_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS
#include <winsock2.h>
#include <windows.h>
#include <stdio.h>

#pragma comment(lib,"ws2_32.lib") //Winsock Library

#define SERVER "127.0.0.1"	//ip address of udp server
#define BUFLEN 512	//Max length of buffer
#define PORT 54320	//The port on which to listen for incoming data

// Global variables
WSADATA wsa; 
int s;
struct sockaddr_in si_other;
int terminate_threads;
int slen = sizeof(si_other);
char buf[BUFLEN];
char message[BUFLEN];

//initializing the values to be sent
float driver_age = 0;
float driver_blood_alcohol = 0;
float driver_alertness_level = 0;
float driver_vision = 0;
float driver_workload = 0;
float driving_proficiency = 0;
float driver_attitude = 0;
float freq_overspeed = 0;
float freq_deviation_from_lane = 0;
float freq_steer_overcorrect = 0;
float freq_honk = 0;
float freq_tailgate = 0;
float freq_overtake = 0;
float correct_maintenance = 0;
float period_maintenance = 0;
float freq_emergency_brake = 0;
float freq_emergency_turn = 0;
float driving_stability = 0;
float vehicle_mileage = 0;
float freq_accident = 0;
float severity_of_accident = 0;
float num_of_OBD_problem = 0;
float fuel_level = 0;
float battery_level = 0;
float tire_pressure = 0;
float oil_level = 0;
float wheel_balance = 0;
float freq_parts_replacement = 0;
float freq_quality = 0;
float tire_health = 0;
float recognize_objects = 0;
float ability_com_other_vehicle = 0;
float ability_com_infrastructure = 0;
float friendly_HVI_system = 0;
float aware_driver_intent = 0;
float aware_other_vehicle_intent = 0;
float aware_driver_behavior = 0;
float aware_other_vehicle_behavior = 0;
float aware_other_vehicle_emotion = 0;
float freq_software_update = 0;
float status_software_update = 0;
float road_condition = 0;
float probability_natural_disaster = 0;
float probability_road_accident = 0;
float probability_construction_obstruction = 0;
float parking_temperature = 0;
float parking_humidity = 0;
float environment_condition = 0;
float weather = 0;
float time_of_day = 0;
float health_factor = 0;

int init_udp();
int close_udp();

BOOL WINAPI consoleHandler(DWORD signal) {

	if (signal == CTRL_C_EVENT) {
		printf("Ctrl-C handled\n"); // do cleanup
		terminate_threads = 1;
	}

	return TRUE;
}

int init_udp() {

	//Initialise winsock
	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
	{
		printf("Failed. Error Code : %d", WSAGetLastError());
		exit(EXIT_FAILURE);
	}
	
	//create socket
	if ((s = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP)) == INVALID_SOCKET)
	{
		printf("socket() failed with error code : %d", WSAGetLastError());
		exit(EXIT_FAILURE);
	}
    
    int iVal = 5;
    int ret = setsockopt(s, SOL_SOCKET, SO_RCVTIMEO, (char *)&iVal, sizeof(iVal));
    
	//setup address structure
	memset((char *)&si_other, 0, sizeof(si_other));
	si_other.sin_family = AF_INET;
	si_other.sin_port = htons(PORT);
	si_other.sin_addr.s_addr = inet_addr(SERVER);

    recvfrom(s, buf, BUFLEN, 0, (struct sockaddr*) &si_other, &slen);
    memset(buf, '\0', BUFLEN);
    
    return 0;
}

int close_udp() {

	// close the socket
	if (closesocket(s) == SOCKET_ERROR) {
		printf("close failed with error: %d\n", WSAGetLastError());
		WSACleanup();
		return 1;
	}

	WSACleanup();
}

void send_udp() {
    //sending the values as a csv string
    sprintf(message, "%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f\n", driver_age, driver_blood_alcohol, driver_alertness_level, driver_vision, driver_workload, driving_proficiency, driver_attitude, freq_overspeed, freq_deviation_from_lane, freq_steer_overcorrect, freq_honk, freq_tailgate, freq_overtake, correct_maintenance, period_maintenance, freq_emergency_brake, freq_emergency_turn, driving_stability, vehicle_mileage, freq_accident, severity_of_accident, num_of_OBD_problem, fuel_level, battery_level, tire_pressure, oil_level, wheel_balance, freq_parts_replacement, freq_quality, tire_health, recognize_objects, ability_com_other_vehicle, ability_com_infrastructure, friendly_HVI_system, aware_driver_intent, aware_other_vehicle_intent, aware_driver_behavior, aware_other_vehicle_behavior, aware_other_vehicle_emotion, freq_software_update, status_software_update, road_condition, probability_natural_disaster, probability_road_accident, probability_construction_obstruction, parking_temperature, parking_humidity, environment_condition, weather, time_of_day, health_factor);
    //send the message
    if (sendto(s, message, strlen(message), 0, (struct sockaddr*) &si_other, slen) == SOCKET_ERROR) {
    }
}

static void mdlInitializeSizes(SimStruct *S)
{
    ssSetNumSFcnParams(S, 0);
    if (ssGetNumSFcnParams(S) != ssGetSFcnParamsCount(S)) {
        return; /* Parameter mismatch reported by the Simulink engine*/
    }
    
    //declaring number of input ports
    if (!ssSetNumInputPorts(S, 51)) return;
    
    //declaring all the input ports
    ssSetInputPortWidth(S, 0, 1);
    ssSetInputPortDirectFeedThrough(S, 0, 0);
    
    ssSetInputPortWidth(S, 1, 1);
    ssSetInputPortDirectFeedThrough(S, 1, 0);
    
    ssSetInputPortWidth(S, 2, 1);
    ssSetInputPortDirectFeedThrough(S, 2, 0);
    
    ssSetInputPortWidth(S, 3, 1);
    ssSetInputPortDirectFeedThrough(S, 3, 0);
    
    ssSetInputPortWidth(S, 4, 1);
    ssSetInputPortDirectFeedThrough(S, 4, 0);
    
    ssSetInputPortWidth(S, 5, 1);
    ssSetInputPortDirectFeedThrough(S, 5, 0);
    
    ssSetInputPortWidth(S, 6, 1);
    ssSetInputPortDirectFeedThrough(S, 6, 0);
    
    ssSetInputPortWidth(S, 7, 1);
    ssSetInputPortDirectFeedThrough(S, 7, 0);
    
    ssSetInputPortWidth(S, 8, 1);
    ssSetInputPortDirectFeedThrough(S, 8, 0);
    
    ssSetInputPortWidth(S, 9, 1);
    ssSetInputPortDirectFeedThrough(S, 9, 0);
    
    ssSetInputPortWidth(S, 10, 1);
    ssSetInputPortDirectFeedThrough(S, 10, 0);
    
    ssSetInputPortWidth(S, 11, 1);
    ssSetInputPortDirectFeedThrough(S, 11, 0);
    
    ssSetInputPortWidth(S, 12, 1);
    ssSetInputPortDirectFeedThrough(S, 12, 0);
    
    ssSetInputPortWidth(S, 13, 1);
    ssSetInputPortDirectFeedThrough(S, 13, 0);
    
    ssSetInputPortWidth(S, 14, 1);
    ssSetInputPortDirectFeedThrough(S, 14, 0);
    
    ssSetInputPortWidth(S, 15, 1);
    ssSetInputPortDirectFeedThrough(S, 15, 0);
    
    ssSetInputPortWidth(S, 16, 1);
    ssSetInputPortDirectFeedThrough(S, 16, 0);
    
    ssSetInputPortWidth(S, 17, 1);
    ssSetInputPortDirectFeedThrough(S, 17, 0);
    
    ssSetInputPortWidth(S, 18, 1);
    ssSetInputPortDirectFeedThrough(S, 18, 0);
    
    ssSetInputPortWidth(S, 19, 1);
    ssSetInputPortDirectFeedThrough(S, 19, 0);
    
    ssSetInputPortWidth(S, 20, 1);
    ssSetInputPortDirectFeedThrough(S, 20, 0);
    
    ssSetInputPortWidth(S, 21, 1);
    ssSetInputPortDirectFeedThrough(S, 21, 0);
    
    ssSetInputPortWidth(S, 22, 1);
    ssSetInputPortDirectFeedThrough(S, 22, 0);
    
    ssSetInputPortWidth(S, 23, 1);
    ssSetInputPortDirectFeedThrough(S, 23, 0);
    
    ssSetInputPortWidth(S, 24, 1);
    ssSetInputPortDirectFeedThrough(S, 24, 0);
    
    ssSetInputPortWidth(S, 25, 1);
    ssSetInputPortDirectFeedThrough(S, 25, 0);
    
    ssSetInputPortWidth(S, 26, 1);
    ssSetInputPortDirectFeedThrough(S, 26, 0);
    
    ssSetInputPortWidth(S, 27, 1);
    ssSetInputPortDirectFeedThrough(S, 27, 0);
    
    ssSetInputPortWidth(S, 28, 1);
    ssSetInputPortDirectFeedThrough(S, 28, 0);
    
    ssSetInputPortWidth(S, 29, 1);
    ssSetInputPortDirectFeedThrough(S, 29, 0);
    
    ssSetInputPortWidth(S, 30, 1);
    ssSetInputPortDirectFeedThrough(S, 30, 0);
    
    ssSetInputPortWidth(S, 31, 1);
    ssSetInputPortDirectFeedThrough(S, 31, 0);
    
    ssSetInputPortWidth(S, 32, 1);
    ssSetInputPortDirectFeedThrough(S, 32, 0);
    
    ssSetInputPortWidth(S, 33, 1);
    ssSetInputPortDirectFeedThrough(S, 33, 0);
    
    ssSetInputPortWidth(S, 34, 1);
    ssSetInputPortDirectFeedThrough(S, 34, 0);
    
    ssSetInputPortWidth(S, 35, 1);
    ssSetInputPortDirectFeedThrough(S, 35, 0);
    
    ssSetInputPortWidth(S, 36, 1);
    ssSetInputPortDirectFeedThrough(S, 36, 0);
    
    ssSetInputPortWidth(S, 37, 1);
    ssSetInputPortDirectFeedThrough(S, 37, 0);
    
    ssSetInputPortWidth(S, 38, 1);
    ssSetInputPortDirectFeedThrough(S, 38, 0);
    
    ssSetInputPortWidth(S, 39, 1);
    ssSetInputPortDirectFeedThrough(S, 39, 0);
    
    ssSetInputPortWidth(S, 40, 1);
    ssSetInputPortDirectFeedThrough(S, 40, 0);
    
    ssSetInputPortWidth(S, 41, 1);
    ssSetInputPortDirectFeedThrough(S, 41, 0);
    
    ssSetInputPortWidth(S, 42, 1);
    ssSetInputPortDirectFeedThrough(S, 42, 0);
    
    ssSetInputPortWidth(S, 43, 1);
    ssSetInputPortDirectFeedThrough(S, 43, 0);
    
    ssSetInputPortWidth(S, 44, 1);
    ssSetInputPortDirectFeedThrough(S, 44, 0);
    
    ssSetInputPortWidth(S, 45, 1);
    ssSetInputPortDirectFeedThrough(S, 45, 0);
    
    ssSetInputPortWidth(S, 46, 1);
    ssSetInputPortDirectFeedThrough(S, 46, 0);
    
    ssSetInputPortWidth(S, 47, 1);
    ssSetInputPortDirectFeedThrough(S, 47, 0);
    
    ssSetInputPortWidth(S, 48, 1);
    ssSetInputPortDirectFeedThrough(S, 48, 0);
    
    ssSetInputPortWidth(S, 49, 1);
    ssSetInputPortDirectFeedThrough(S, 49, 0);
    
    ssSetInputPortWidth(S, 50, 1);
    ssSetInputPortDirectFeedThrough(S, 50, 0);
    
    if (!ssSetNumOutputPorts(S, 0)) return;
    
    ssSetNumSampleTimes(S, 0.01);
    
    /* Take care when specifying exception free code - see sfuntmpl.doc */
    //ssSetOptions(S, SS_OPTION_EXCEPTION_FREE_CODE);
}

static void mdlInitializeSampleTimes(SimStruct *S)
{
    ssSetSampleTime(S, 0, INHERITED_SAMPLE_TIME);
    ssSetOffsetTime(S, 0, 0.0);
}

#define MDL_UPDATE
static void mdlUpdate(SimStruct *S, int_T tid) 
{ 
    //declaring all the input ports type
    InputRealPtrsType driver_age_sig = ssGetInputPortRealSignalPtrs(S, 0);
    InputRealPtrsType driver_blood_alcohol_sig = ssGetInputPortRealSignalPtrs(S, 1);
    InputRealPtrsType driver_alertness_level_sig = ssGetInputPortRealSignalPtrs(S, 2);
    InputRealPtrsType driver_vision_sig = ssGetInputPortRealSignalPtrs(S, 3);
    InputRealPtrsType driver_workload_sig = ssGetInputPortRealSignalPtrs(S, 4);
    InputRealPtrsType driving_proficiency_sig = ssGetInputPortRealSignalPtrs(S, 5);
    InputRealPtrsType driver_attitude_sig = ssGetInputPortRealSignalPtrs(S, 6);
    InputRealPtrsType freq_overspeed_sig = ssGetInputPortRealSignalPtrs(S, 7);
    InputRealPtrsType freq_deviation_from_lane_sig = ssGetInputPortRealSignalPtrs(S, 8);
    InputRealPtrsType freq_steer_overcorrect_sig = ssGetInputPortRealSignalPtrs(S, 9);
    InputRealPtrsType freq_honk_sig = ssGetInputPortRealSignalPtrs(S, 10);
    InputRealPtrsType freq_tailgate_sig = ssGetInputPortRealSignalPtrs(S, 11);
    InputRealPtrsType freq_overtake_sig = ssGetInputPortRealSignalPtrs(S, 12);
    InputRealPtrsType correct_maintenance_sig = ssGetInputPortRealSignalPtrs(S, 13);
    InputRealPtrsType period_maintenance_sig = ssGetInputPortRealSignalPtrs(S, 14);
    InputRealPtrsType freq_emergency_brake_sig = ssGetInputPortRealSignalPtrs(S, 15);
    InputRealPtrsType freq_emergency_turn_sig = ssGetInputPortRealSignalPtrs(S, 16);
    InputRealPtrsType driving_stability_sig = ssGetInputPortRealSignalPtrs(S, 17);
    InputRealPtrsType vehicle_mileage_sig = ssGetInputPortRealSignalPtrs(S, 18);
    InputRealPtrsType freq_accident_sig = ssGetInputPortRealSignalPtrs(S, 19);
    InputRealPtrsType severity_of_accident_sig = ssGetInputPortRealSignalPtrs(S, 20);
    InputRealPtrsType num_of_OBD_problem_sig = ssGetInputPortRealSignalPtrs(S, 21);
    InputRealPtrsType fuel_level_sig = ssGetInputPortRealSignalPtrs(S, 22);
    InputRealPtrsType battery_level_sig = ssGetInputPortRealSignalPtrs(S, 23);
    InputRealPtrsType tire_pressure_sig = ssGetInputPortRealSignalPtrs(S, 24);
    InputRealPtrsType oil_level_sig = ssGetInputPortRealSignalPtrs(S, 25);
    InputRealPtrsType wheel_balance_sig = ssGetInputPortRealSignalPtrs(S, 26);
    InputRealPtrsType freq_parts_replacement_sig = ssGetInputPortRealSignalPtrs(S, 27);
    InputRealPtrsType freq_quality_sig = ssGetInputPortRealSignalPtrs(S, 28);
    InputRealPtrsType tire_health_sig = ssGetInputPortRealSignalPtrs(S, 29);
    InputRealPtrsType recognize_objects_sig = ssGetInputPortRealSignalPtrs(S, 30);
    InputRealPtrsType ability_com_other_vehicle_sig = ssGetInputPortRealSignalPtrs(S, 31);
    InputRealPtrsType ability_com_infrastructure_sig = ssGetInputPortRealSignalPtrs(S, 32);
    InputRealPtrsType friendly_HVI_system_sig = ssGetInputPortRealSignalPtrs(S, 33);
    InputRealPtrsType aware_driver_intent_sig = ssGetInputPortRealSignalPtrs(S, 34);
    InputRealPtrsType aware_other_vehicle_intent_sig = ssGetInputPortRealSignalPtrs(S, 35);
    InputRealPtrsType aware_driver_behavior_sig = ssGetInputPortRealSignalPtrs(S, 36);
    InputRealPtrsType aware_other_vehicle_behavior_sig = ssGetInputPortRealSignalPtrs(S, 37);
    InputRealPtrsType aware_other_vehicle_emotion_sig = ssGetInputPortRealSignalPtrs(S, 38);
    InputRealPtrsType freq_software_update_sig = ssGetInputPortRealSignalPtrs(S, 39);
    InputRealPtrsType status_software_update_sig = ssGetInputPortRealSignalPtrs(S, 40);
    InputRealPtrsType road_condition_sig = ssGetInputPortRealSignalPtrs(S, 41);
    InputRealPtrsType probability_natural_disaster_sig = ssGetInputPortRealSignalPtrs(S, 42);
    InputRealPtrsType probability_road_accident_sig = ssGetInputPortRealSignalPtrs(S, 43);
    InputRealPtrsType probability_construction_obstruction_sig = ssGetInputPortRealSignalPtrs(S, 44);
    InputRealPtrsType parking_temperature_sig = ssGetInputPortRealSignalPtrs(S, 45);
    InputRealPtrsType parking_humidity_sig = ssGetInputPortRealSignalPtrs(S, 46);
    InputRealPtrsType environment_condition_sig = ssGetInputPortRealSignalPtrs(S, 47);
    InputRealPtrsType weather_sig = ssGetInputPortRealSignalPtrs(S, 48);
    InputRealPtrsType time_of_day_sig = ssGetInputPortRealSignalPtrs(S, 49);
    InputRealPtrsType health_factor_sig = ssGetInputPortRealSignalPtrs(S, 50);
    
    //assigning values to be sent to their respective variables
    driver_age = (float) **driver_age_sig;
    driver_blood_alcohol = (float) **driver_blood_alcohol_sig;
    driver_alertness_level = (float) **driver_alertness_level_sig;
    driver_vision = (float) **driver_vision_sig;
    driver_workload = (float) **driver_workload_sig;
    driving_proficiency = (float) **driving_proficiency_sig;
    driver_attitude = (float) **driver_attitude_sig;
    freq_overspeed = (float) **freq_overspeed_sig;
    freq_deviation_from_lane = (float) **freq_deviation_from_lane_sig;
    freq_steer_overcorrect = (float) **freq_steer_overcorrect_sig;
    freq_honk = (float) **freq_honk_sig;
    freq_tailgate = (float) **freq_tailgate_sig;
    freq_overtake = (float) **freq_overtake_sig;
    correct_maintenance = (float) **correct_maintenance_sig;
    period_maintenance = (float) **period_maintenance_sig;
    freq_emergency_brake = (float) **freq_emergency_brake_sig;
    freq_emergency_turn = (float) **freq_emergency_turn_sig;
    driving_stability = (float) **driving_stability_sig;
    vehicle_mileage = (float) **vehicle_mileage_sig;
    freq_accident = (float) **freq_accident_sig;
    severity_of_accident = (float) **severity_of_accident_sig;
    num_of_OBD_problem = (float) **num_of_OBD_problem_sig;
    fuel_level = (float) **fuel_level_sig;
    battery_level = (float) **battery_level_sig;
    tire_pressure = (float) **tire_pressure_sig;
    oil_level = (float) **oil_level_sig;
    wheel_balance = (float) **wheel_balance_sig;
    freq_parts_replacement = (float) **freq_parts_replacement_sig;
    freq_quality = (float) **freq_quality_sig;
    tire_health = (float) **tire_health_sig;
    recognize_objects = (float) **recognize_objects_sig;
    ability_com_other_vehicle = (float) **ability_com_other_vehicle_sig;
    ability_com_infrastructure = (float) **ability_com_infrastructure_sig;
    friendly_HVI_system = (float) **friendly_HVI_system_sig;
    aware_driver_intent = (float) **aware_driver_intent_sig;
    aware_other_vehicle_intent = (float) **aware_other_vehicle_intent_sig;
    aware_driver_behavior = (float) **aware_driver_behavior_sig;
    aware_other_vehicle_behavior = (float) **aware_other_vehicle_behavior_sig;
    aware_other_vehicle_emotion = (float) **aware_other_vehicle_emotion_sig;
    freq_software_update = (float) **freq_software_update_sig;
    status_software_update = (float) **status_software_update_sig;
    road_condition = (float) **road_condition_sig;
    probability_natural_disaster = (float) **probability_natural_disaster_sig;
    probability_road_accident = (float) **probability_road_accident_sig;
    probability_construction_obstruction = (float) **probability_construction_obstruction_sig;
    parking_temperature = (float) **parking_temperature_sig;
    parking_humidity = (float) **parking_humidity_sig;
    environment_condition = (float) **environment_condition_sig;
    weather = (float) **weather_sig;
    time_of_day = (float) **time_of_day_sig;
    health_factor = (float) **health_factor_sig;
    
} 

static void mdlOutputs(SimStruct *S, int_T tid)
{
    send_udp();
}

#define MDL_START
static void mdlStart(SimStruct *S) {
    init_udp();
}

static void mdlTerminate(SimStruct *S){
    close_udp();
}

#ifdef MATLAB_MEX_FILE /* Is this file being compiled as a MEX-file? */
#include "simulink.c" /* MEX-file interface mechanism */
#else
#include "cg_sfun.h" /* Code generation registration function */
#endif
