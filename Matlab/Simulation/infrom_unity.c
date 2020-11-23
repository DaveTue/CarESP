#define S_FUNCTION_NAME infrom_unity /* Defines and Includes */
#define S_FUNCTION_LEVEL 2
//for compile mex -O infrom_unity.c
#include "simstruc.h"

#define _WINSOCK_DEPRECATED_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS
#include <winsock2.h>
#include <windows.h>
#include <stdio.h>


#pragma comment(lib,"ws2_32.lib") //Winsock Library

#define SERVER "127.0.0.1"	//ip address of udp server
#define BUFLEN 512	//Max length of buffer
#define PORT 54330	//The port on which to listen for incoming data

// Global variables
WSADATA wsa; 
int s;
struct sockaddr_in si_other;
int terminate_threads;
int slen = sizeof(si_other);
char buf[BUFLEN];
char message[BUFLEN];


float r_personality=0;
float rate_acc=0;
float rate_deacc=0;
float avg_gap=0;
float un_ObjRecog=0;
float acc_now=0;
float av_road_acc=0;
float sd_road_acc=0;
float dr_age_st=0;
float dr_emotion_st=0;
float dr_alchoholL_st=0;
float dr_alertness_st=0;
float dr_vision_st=0;
float dr_workload_st=0;
float dr_attitude_st=0;
float period_mantainance_st=0;
float speeding_freq_st=0;
float vh_mass_st=0;
float noise_st=0;
float vh_HMinterface_st=0;
float software_update_st=0;
float digital_interface_st=0;
float v2v_st=0;
float v2i_st=0;
float bigdata_st=0;
float collective_driving_st=0;
float prob_construction_st=0;
float cab_temp_st=0;
float cab_humidity_st=0;
float dr_environment_cond_st=0;
float road_surface_st=0;
float road_cond_st=0;
float weather_st=0;
float time_day_st=0;

//new var
float pedestrian_active=0;
float  average_speed=0;
float speed_limit=0;
float max_car_speed=0;
//rec starts
float r_personality_rec=0;
float rate_acc_rec=0;
float rate_deacc_rec=0;
float avg_gap_rec=0;
float un_ObjRecog_rec=0;
float acc_now_rec=0;
float av_road_acc_rec=0;
float sd_road_acc_rec=0;
float dr_age_st_rec=0;
float dr_emotion_st_rec=0;
float dr_alchoholL_st_rec=0;
float dr_alertness_st_rec=0;
float dr_vision_st_rec=0;
float dr_workload_st_rec=0;
float dr_attitude_st_rec=0;
float period_mantainance_st_rec=0;
float speeding_freq_st_rec=0;
float vh_mass_st_rec=0;
float noise_st_rec=0;
float vh_HMinterface_st_rec=0;
float software_update_st_rec=0;
float digital_interface_st_rec=0;
float v2v_st_rec=0;
float v2i_st_rec=0;
float bigdata_st_rec=0;
float collective_driving_st_rec=0;
float prob_construction_st_rec=0;
float cab_temp_st_rec=0;
float cab_humidity_st_rec=0;
float dr_environment_cond_st_rec=0;
float road_surface_st_rec=0;
float road_cond_st_rec=0;
float weather_st_rec=0;
float time_day_st_rec=0;

//new variables
float pedestrian_active_rec=0;
float  average_speed_rec=0;
float speed_limit_rec=0;
float max_car_speed_rec=0;
 


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
	//printf("\nInitialising Winsock...");
	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
	{
		printf("Failed. Error Code : %d", WSAGetLastError());
		exit(EXIT_FAILURE);
	}
	//printf("Initialised.\n");

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

void parse_csv(char * str) {
   
    char* p = strtok(str, ",");// strtok separates a string using "," as a separator
	r_personality_rec = strtof(p,NULL); //interpret the p as floting values. 
    p = strtok(NULL, ",");
    rate_acc_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    rate_deacc_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    avg_gap_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    un_ObjRecog_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    acc_now_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    av_road_acc_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    sd_road_acc_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    dr_age_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    dr_emotion_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    dr_alchoholL_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    dr_alertness_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    dr_vision_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    dr_workload_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    dr_attitude_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    period_mantainance_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    speeding_freq_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    vh_mass_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    noise_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    vh_HMinterface_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    software_update_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    digital_interface_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    v2v_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    v2i_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    bigdata_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    collective_driving_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    prob_construction_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    cab_temp_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    cab_humidity_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    dr_environment_cond_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    road_surface_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    road_cond_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    weather_st_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    time_day_st_rec= strtof(p, NULL);
   //new 
    p = strtok(NULL, ",");
    pedestrian_active_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    average_speed_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    speed_limit_rec= strtof(p, NULL);
    p = strtok(NULL, ",");
    max_car_speed_rec= strtof(p, NULL);
    
    
     
}

void send_udp() {
        //sprintf(message, "%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f\n", ego_speed,ego_posx,ego_posz,ego_acc,ego_direction,lead_presence,lead_speed,lead_posx,lead_posz,olane_presence,olane_speed,olane_posx,olane_posz,olane_direction);
        //sprintf(message,"%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f\n",r_personality,rate_acc,rate_deacc,avg_gap,un_ObjRecog,acc_now,av_road_acc,sd_road_acc,dr_age_st,dr_emotion_st,dr_alchoholL_st,dr_alertness_st,dr_vision_st,dr_workload_st,dr_attitude_st,period_mantainance_st,speeding_freq_st,vh_mass_st,noise_st,vh_HMinterface_st,software_update_st,digital_interface_st,v2v_st,v2i_st,bigdata_st,collective_driving_st,prob_construction_st,cab_temp_st,cab_humidity_st,dr_environment_cond_st,road_surface_st,road_cond_st,weather_st,time_day_st);
        sprintf(message,"%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f\n",r_personality,rate_acc,rate_deacc,avg_gap,un_ObjRecog,acc_now,av_road_acc,sd_road_acc,dr_age_st,dr_emotion_st,dr_alchoholL_st,dr_alertness_st,dr_vision_st,dr_workload_st,dr_attitude_st,period_mantainance_st,speeding_freq_st,vh_mass_st,noise_st,vh_HMinterface_st,software_update_st,digital_interface_st,v2v_st,v2i_st,bigdata_st,collective_driving_st,prob_construction_st,cab_temp_st,cab_humidity_st,dr_environment_cond_st,road_surface_st,road_cond_st,weather_st,time_day_st,pedestrian_active, average_speed,speed_limit,max_car_speed);
    
       
    
   // sprintf(message, "Datasent\n");
    //send the message
    if (sendto(s, message, strlen(message), 0, (struct sockaddr*) &si_other, slen) == SOCKET_ERROR) {
    }
}

void recv_udp() {
    memset(buf, '\0', BUFLEN);
    if (recvfrom(s, buf, BUFLEN, 0, (struct sockaddr*) &si_other, &slen) == SOCKET_ERROR) {
    }
    else {
            parse_csv(buf);
    }
	return;
}

static void mdlInitializeSizes(SimStruct *S)
{
    ssSetNumSFcnParams(S, 0);
    if (ssGetNumSFcnParams(S) != ssGetSFcnParamsCount(S)) {
        return; /* Parameter mismatch reported by the Simulink engine*/
    }

    //if (!ssSetNumInputPorts(S, 2)) return;
    if (!ssSetNumInputPorts(S, 38)) return;
    
    // set position and rotation posrt sizes (drone, ball, team1 x 7, team2 x 7) = 32
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
    //new
    //
    ssSetInputPortWidth(S, 34, 1);
    ssSetInputPortDirectFeedThrough(S, 34, 0);
    ssSetInputPortWidth(S, 35, 1);
    ssSetInputPortDirectFeedThrough(S, 35, 0); 
    ssSetInputPortWidth(S, 36, 1);
    ssSetInputPortDirectFeedThrough(S, 36, 0);
    ssSetInputPortWidth(S, 37, 1);
    ssSetInputPortDirectFeedThrough(S, 37, 0);
    
    

    if (!ssSetNumOutputPorts(S, 38)) return;
        //number of outputs
     ssSetOutputPortWidth(S, 0, 1);
     ssSetOutputPortWidth(S, 1, 1);
     ssSetOutputPortWidth(S, 2, 1);
     ssSetOutputPortWidth(S, 3, 1);
     ssSetOutputPortWidth(S, 4, 1);
     ssSetOutputPortWidth(S, 5, 1);
     ssSetOutputPortWidth(S, 6, 1);
     ssSetOutputPortWidth(S, 7, 1);
     ssSetOutputPortWidth(S, 8, 1);
     ssSetOutputPortWidth(S, 9, 1);
     ssSetOutputPortWidth(S, 10, 1);
     ssSetOutputPortWidth(S, 11, 1);
     ssSetOutputPortWidth(S, 12, 1);
     ssSetOutputPortWidth(S, 13, 1);
     ssSetOutputPortWidth(S, 14, 1);
     ssSetOutputPortWidth(S, 15, 1);
     ssSetOutputPortWidth(S, 16, 1);
     ssSetOutputPortWidth(S, 17, 1);
     ssSetOutputPortWidth(S, 18, 1);
     ssSetOutputPortWidth(S, 19, 1);
     ssSetOutputPortWidth(S, 20, 1);
     ssSetOutputPortWidth(S, 21, 1);
     ssSetOutputPortWidth(S, 22, 1);
     ssSetOutputPortWidth(S, 23, 1);
     ssSetOutputPortWidth(S, 24, 1);
     ssSetOutputPortWidth(S, 25, 1);
     ssSetOutputPortWidth(S, 26, 1);
     ssSetOutputPortWidth(S, 27, 1);
     ssSetOutputPortWidth(S, 28, 1);
     ssSetOutputPortWidth(S, 29, 1);
     ssSetOutputPortWidth(S, 30, 1);
     ssSetOutputPortWidth(S, 31, 1);
     ssSetOutputPortWidth(S, 32, 1);
     ssSetOutputPortWidth(S, 33, 1);
     //new
     ssSetOutputPortWidth(S, 34, 1);
     ssSetOutputPortWidth(S, 35, 1);
     ssSetOutputPortWidth(S, 36, 1);
     ssSetOutputPortWidth(S, 37, 1);     
     
     
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
   // InputRealPtrsType ego_speed_sig = ssGetInputPortRealSignalPtrs(S, 0);
    InputRealPtrsType r_personality_sig = ssGetInputPortRealSignalPtrs(S, 0);
    InputRealPtrsType rate_acc_sig = ssGetInputPortRealSignalPtrs(S, 1);
    InputRealPtrsType rate_deacc_sig = ssGetInputPortRealSignalPtrs(S, 2);
    InputRealPtrsType avg_gap_sig = ssGetInputPortRealSignalPtrs(S, 3);
    InputRealPtrsType un_ObjRecog_sig = ssGetInputPortRealSignalPtrs(S, 4);
    InputRealPtrsType acc_now_sig = ssGetInputPortRealSignalPtrs(S, 5);
    InputRealPtrsType av_road_acc_sig = ssGetInputPortRealSignalPtrs(S, 6);
    InputRealPtrsType sd_road_acc_sig = ssGetInputPortRealSignalPtrs(S, 7);
    InputRealPtrsType dr_age_st_sig = ssGetInputPortRealSignalPtrs(S, 8);
    InputRealPtrsType dr_emotion_st_sig = ssGetInputPortRealSignalPtrs(S, 9);
    InputRealPtrsType dr_alchoholL_st_sig = ssGetInputPortRealSignalPtrs(S, 10);
    InputRealPtrsType dr_alertness_st_sig = ssGetInputPortRealSignalPtrs(S, 11);
    InputRealPtrsType dr_vision_st_sig = ssGetInputPortRealSignalPtrs(S, 12);
    InputRealPtrsType dr_workload_st_sig = ssGetInputPortRealSignalPtrs(S, 13);
    InputRealPtrsType dr_attitude_st_sig = ssGetInputPortRealSignalPtrs(S, 14);
    InputRealPtrsType period_mantainance_st_sig = ssGetInputPortRealSignalPtrs(S, 15);
    InputRealPtrsType speeding_freq_st_sig = ssGetInputPortRealSignalPtrs(S, 16);
    InputRealPtrsType vh_mass_st_sig = ssGetInputPortRealSignalPtrs(S, 17);
    InputRealPtrsType noise_st_sig = ssGetInputPortRealSignalPtrs(S, 18);
    InputRealPtrsType vh_HMinterface_st_sig = ssGetInputPortRealSignalPtrs(S, 19);
    InputRealPtrsType software_update_st_sig = ssGetInputPortRealSignalPtrs(S, 20);
    InputRealPtrsType digital_interface_st_sig = ssGetInputPortRealSignalPtrs(S, 21);
    InputRealPtrsType v2v_st_sig = ssGetInputPortRealSignalPtrs(S, 22);
    InputRealPtrsType v2i_st_sig = ssGetInputPortRealSignalPtrs(S, 23);
    InputRealPtrsType bigdata_st_sig = ssGetInputPortRealSignalPtrs(S, 24);
    InputRealPtrsType collective_driving_st_sig = ssGetInputPortRealSignalPtrs(S, 25);
    InputRealPtrsType prob_construction_st_sig = ssGetInputPortRealSignalPtrs(S, 26);
    InputRealPtrsType cab_temp_st_sig = ssGetInputPortRealSignalPtrs(S, 27);
    InputRealPtrsType cab_humidity_st_sig = ssGetInputPortRealSignalPtrs(S, 28);
    InputRealPtrsType dr_environment_cond_st_sig = ssGetInputPortRealSignalPtrs(S, 29);
    InputRealPtrsType road_surface_st_sig = ssGetInputPortRealSignalPtrs(S, 30);
    InputRealPtrsType road_cond_st_sig = ssGetInputPortRealSignalPtrs(S, 31);
    InputRealPtrsType weather_st_sig = ssGetInputPortRealSignalPtrs(S, 32);
    InputRealPtrsType time_day_st_sig = ssGetInputPortRealSignalPtrs(S, 33);
    //new
    InputRealPtrsType pedestrian_active_sig = ssGetInputPortRealSignalPtrs(S, 34);
    InputRealPtrsType average_speed_sig = ssGetInputPortRealSignalPtrs(S, 35);
    InputRealPtrsType speed_limit_sig = ssGetInputPortRealSignalPtrs(S, 36);
    InputRealPtrsType max_car_speed_sig = ssGetInputPortRealSignalPtrs(S, 37);
    
   

    
    //ego_speed =(float) **ego_speed_sig;
    r_personality = (float) **r_personality_sig;
    rate_acc = (float) **rate_acc_sig;
    rate_deacc = (float) **rate_deacc_sig;
    avg_gap = (float) **avg_gap_sig;
    un_ObjRecog = (float) **un_ObjRecog_sig;
    acc_now = (float) **acc_now_sig;
    av_road_acc = (float) **av_road_acc_sig;
    sd_road_acc = (float) **sd_road_acc_sig;
    dr_age_st = (float) **dr_age_st_sig;
    dr_emotion_st = (float) **dr_emotion_st_sig;
    dr_alchoholL_st = (float) **dr_alchoholL_st_sig;
    dr_alertness_st = (float) **dr_alertness_st_sig;
    dr_vision_st = (float) **dr_vision_st_sig;
    dr_workload_st = (float) **dr_workload_st_sig;
    dr_attitude_st = (float) **dr_attitude_st_sig;
    period_mantainance_st = (float) **period_mantainance_st_sig;
    speeding_freq_st = (float) **speeding_freq_st_sig;
    vh_mass_st = (float) **vh_mass_st_sig;
    noise_st = (float) **noise_st_sig;
    vh_HMinterface_st = (float) **vh_HMinterface_st_sig;
    software_update_st = (float) **software_update_st_sig;
    digital_interface_st = (float) **digital_interface_st_sig;
    v2v_st = (float) **v2v_st_sig;
    v2i_st = (float) **v2i_st_sig;
    bigdata_st = (float) **bigdata_st_sig;
    collective_driving_st = (float) **collective_driving_st_sig;
    prob_construction_st = (float) **prob_construction_st_sig;
    cab_temp_st = (float) **cab_temp_st_sig;
    cab_humidity_st = (float) **cab_humidity_st_sig;
    dr_environment_cond_st = (float) **dr_environment_cond_st_sig;
    road_surface_st = (float) **road_surface_st_sig;
    road_cond_st = (float) **road_cond_st_sig;
    weather_st = (float) **weather_st_sig;
    time_day_st = (float) **time_day_st_sig;
    
    //new
     pedestrian_active= (float) **pedestrian_active_sig;
     average_speed= (float) **average_speed_sig;
     speed_limit= (float) **speed_limit_sig;
     max_car_speed= (float) **max_car_speed_sig;
     
     
} 

static void mdlOutputs(SimStruct *S, int_T tid)
{
    send_udp();
    recv_udp();
    
    real_T *test_rec = ssGetOutputPortRealSignal(S, 0);
    real_T *test1_rec= ssGetOutputPortRealSignal(S, 1);
    real_T *test2_rec= ssGetOutputPortRealSignal(S, 2);
    real_T *test3_rec= ssGetOutputPortRealSignal(S, 3);
    real_T *test4_rec= ssGetOutputPortRealSignal(S, 4);
    real_T *test5_rec= ssGetOutputPortRealSignal(S, 5);
    real_T *test6_rec= ssGetOutputPortRealSignal(S, 6);
    real_T *test7_rec= ssGetOutputPortRealSignal(S, 7);
    real_T *test8_rec= ssGetOutputPortRealSignal(S, 8);
    real_T *test9_rec= ssGetOutputPortRealSignal(S, 9);
    real_T *test10_rec= ssGetOutputPortRealSignal(S, 10);
    real_T *test11_rec= ssGetOutputPortRealSignal(S, 11);
    real_T *test12_rec= ssGetOutputPortRealSignal(S, 12);
    real_T *test13_rec= ssGetOutputPortRealSignal(S, 13);
    real_T *test14_rec= ssGetOutputPortRealSignal(S, 14);
    real_T *test15_rec= ssGetOutputPortRealSignal(S, 15);
    real_T *test16_rec= ssGetOutputPortRealSignal(S, 16);
    real_T *test17_rec= ssGetOutputPortRealSignal(S, 17);
    real_T *test18_rec= ssGetOutputPortRealSignal(S, 18);
    real_T *test19_rec= ssGetOutputPortRealSignal(S, 19);
    real_T *test20_rec= ssGetOutputPortRealSignal(S, 20);
    real_T *test21_rec= ssGetOutputPortRealSignal(S, 21);
    real_T *test22_rec= ssGetOutputPortRealSignal(S, 22);
    real_T *test23_rec= ssGetOutputPortRealSignal(S, 23);
    real_T *test24_rec= ssGetOutputPortRealSignal(S, 24);
    real_T *test25_rec= ssGetOutputPortRealSignal(S, 25);
    real_T *test26_rec= ssGetOutputPortRealSignal(S, 26);
    real_T *test27_rec= ssGetOutputPortRealSignal(S, 27);
    real_T *test28_rec= ssGetOutputPortRealSignal(S, 28);
    real_T *test29_rec= ssGetOutputPortRealSignal(S, 29);
    real_T *test30_rec= ssGetOutputPortRealSignal(S, 30);
    real_T *test31_rec= ssGetOutputPortRealSignal(S, 31);
    real_T *test32_rec= ssGetOutputPortRealSignal(S, 32);
    real_T *test33_rec= ssGetOutputPortRealSignal(S, 33);
    //new
    real_T *test34_rec= ssGetOutputPortRealSignal(S, 34);
    real_T *test35_rec= ssGetOutputPortRealSignal(S, 35);
    real_T *test36_rec= ssGetOutputPortRealSignal(S, 36);
    real_T *test37_rec= ssGetOutputPortRealSignal(S, 37);

    
    //test_rec[0] = ego_speed_rec;
    test_rec[0] = r_personality_rec;
    test1_rec[0] = rate_acc_rec;
    test2_rec[0] = rate_deacc_rec;
    test3_rec[0] = avg_gap_rec;
    test4_rec[0] = un_ObjRecog_rec;
    test5_rec[0] = acc_now_rec;
    test6_rec[0] = av_road_acc_rec;
    test7_rec[0] = sd_road_acc_rec;
    test8_rec[0] = dr_age_st_rec;
    test9_rec[0] = dr_emotion_st_rec;
    test10_rec[0] = dr_alchoholL_st_rec;
    test11_rec[0] = dr_alertness_st_rec;
    test12_rec[0] = dr_vision_st_rec;
    test13_rec[0] = dr_workload_st_rec;
    test14_rec[0] = dr_attitude_st_rec;
    test15_rec[0] = period_mantainance_st_rec;
    test16_rec[0] = speeding_freq_st_rec;
    test17_rec[0] = vh_mass_st_rec;
    test18_rec[0] = noise_st_rec;
    test19_rec[0] = vh_HMinterface_st_rec;
    test20_rec[0] = software_update_st_rec;
    test21_rec[0] = digital_interface_st_rec;
    test22_rec[0] = v2v_st_rec;
    test23_rec[0] = v2i_st_rec;
    test24_rec[0] = bigdata_st_rec;
    test25_rec[0] = collective_driving_st_rec;
    test26_rec[0] = prob_construction_st_rec;
    test27_rec[0] = cab_temp_st_rec;
    test28_rec[0] = cab_humidity_st_rec;
    test29_rec[0] = dr_environment_cond_st_rec;
    test30_rec[0] = road_surface_st_rec;
    test31_rec[0] = road_cond_st_rec;
    test32_rec[0] = weather_st_rec;
    test33_rec[0] = time_day_st_rec;
    //new
    test34_rec[0] = pedestrian_active_rec;
    test35_rec[0] = average_speed_rec;
    test36_rec[0] = speed_limit_rec;
    test37_rec[0] = max_car_speed_rec;

     
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
