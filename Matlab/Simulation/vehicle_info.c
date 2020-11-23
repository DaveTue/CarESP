#define S_FUNCTION_NAME vehicle_info /* Defines and Includes */
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
#define PORT 54325	//The port on which to listen for incoming data

// Global variables
WSADATA wsa; 
int s;
struct sockaddr_in si_other;
int terminate_threads;
int slen = sizeof(si_other);
char buf[BUFLEN];
char message[BUFLEN];


float ego_speed = 0;
float ego_posx = 0;
float ego_posz=0;
float ego_acc=0;
float ego_direction=0;

float lead_presence=0;
float lead_speed=0;
float lead_posx=0;
float lead_posz=0;

float olane_presence=0;
float olane_speed=0;
float olane_posx=0;
float olane_posz=0;
float olane_direction=0; 

float distance=0;
        
//float test1 = 0;
float ego_speed_rec = 0;
float ego_posx_rec = 0;
float ego_posz_rec=0;
float ego_acc_rec=0;
float ego_direction_rec=0;

float lead_presence_rec=0;
float lead_speed_rec=0;
float lead_posx_rec=0;
float lead_posz_rec=0;

float olane_presence_rec=0;
float olane_speed_rec=0;
float olane_posx_rec=0;
float olane_posz_rec=0;
float olane_direction_rec=0; 

float distance_rec=0;
 
//float t1_rec = 0;

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
	ego_speed_rec = strtof(p,NULL); //interpret the p as floting values. 
    p = strtok(NULL, ",");
	ego_posx_rec = strtof(p, NULL);
    p = strtok(NULL, ",");
	ego_posz_rec = strtof(p, NULL);
    p = strtok(NULL, ",");
	ego_acc_rec = strtof(p, NULL);
    p = strtok(NULL, ",");
	ego_direction_rec = strtof(p, NULL);
    p = strtok(NULL, ",");
	lead_presence_rec = strtof(p, NULL);
    p = strtok(NULL, ",");
	lead_speed_rec = strtof(p, NULL);
    p = strtok(NULL, ",");
	lead_posx_rec = strtof(p, NULL);
    p = strtok(NULL, ",");
	lead_posz_rec = strtof(p, NULL);
    p = strtok(NULL, ",");
	olane_presence_rec = strtof(p, NULL);
    p = strtok(NULL, ",");
	olane_speed_rec = strtof(p, NULL);
    p = strtok(NULL, ",");
	olane_posx_rec = strtof(p, NULL);
    p = strtok(NULL, ",");
	olane_posz_rec = strtof(p, NULL);
    p = strtok(NULL, ",");
	olane_direction_rec = strtof(p, NULL);
    p = strtok(NULL, ",");
    distance_rec = strtof(p, NULL);
   
     
}

void send_udp() {
        sprintf(message, "%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f,%f\n", ego_speed,ego_posx,ego_posz,ego_acc,ego_direction,lead_presence,lead_speed,lead_posx,lead_posz,olane_presence,olane_speed,olane_posx,olane_posz,olane_direction,distance);
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
    if (!ssSetNumInputPorts(S, 15)) return;
    
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
    

    if (!ssSetNumOutputPorts(S, 15)) return;
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
    InputRealPtrsType ego_speed_sig = ssGetInputPortRealSignalPtrs(S, 0);
    InputRealPtrsType ego_posx_sig = ssGetInputPortRealSignalPtrs(S, 1);
    InputRealPtrsType ego_posz_sig = ssGetInputPortRealSignalPtrs(S, 2);
    InputRealPtrsType ego_acc_sig = ssGetInputPortRealSignalPtrs(S, 3);
    InputRealPtrsType ego_direction_sig = ssGetInputPortRealSignalPtrs(S, 4);
    InputRealPtrsType lead_presence_sig = ssGetInputPortRealSignalPtrs(S, 5);
    InputRealPtrsType lead_speed_sig = ssGetInputPortRealSignalPtrs(S, 6);
    InputRealPtrsType lead_posx_sig = ssGetInputPortRealSignalPtrs(S, 7);
    InputRealPtrsType lead_posz_sig = ssGetInputPortRealSignalPtrs(S, 8);
    InputRealPtrsType olane_presence_sig = ssGetInputPortRealSignalPtrs(S, 9);
    InputRealPtrsType olane_speed_sig = ssGetInputPortRealSignalPtrs(S, 10);
    InputRealPtrsType olane_posx_sig = ssGetInputPortRealSignalPtrs(S, 11);
    InputRealPtrsType olane_posz_sig = ssGetInputPortRealSignalPtrs(S, 12);
    InputRealPtrsType olane_direction_sig = ssGetInputPortRealSignalPtrs(S, 13);
    InputRealPtrsType distance_sig = ssGetInputPortRealSignalPtrs(S, 14);
    
    
    
    ego_speed =(float) **ego_speed_sig;
    ego_posx =(float) **ego_posx_sig;
    ego_posz= (float) **ego_posz_sig;
    ego_acc=(float) **ego_acc_sig;
    ego_direction=(float) **ego_direction_sig;

    lead_presence=(float) **lead_presence_sig;
    lead_speed=(float) **lead_speed_sig;
    lead_posx=(float) **lead_posx_sig;
    lead_posz=(float) **lead_posz_sig;

    olane_presence=(float) **olane_presence_sig;
    olane_speed= (float) **olane_speed_sig;
    olane_posx= (float) **olane_posx_sig;
    olane_posz= (float) **olane_posz_sig;
    olane_direction= (float) **olane_direction_sig; 
    
    distance= (float) **distance_sig;
    
    

    
} 

static void mdlOutputs(SimStruct *S, int_T tid)
{
    send_udp();
    recv_udp();
    
    real_T *test_rec = ssGetOutputPortRealSignal(S, 0);
    real_T *test1_rec = ssGetOutputPortRealSignal(S, 1);
    real_T *test2_rec = ssGetOutputPortRealSignal(S, 2);
    real_T *test3_rec = ssGetOutputPortRealSignal(S, 3);
    real_T *test4_rec = ssGetOutputPortRealSignal(S, 4);
    real_T *test5_rec = ssGetOutputPortRealSignal(S, 5);
    real_T *test6_rec = ssGetOutputPortRealSignal(S, 6);
    real_T *test7_rec = ssGetOutputPortRealSignal(S, 7);
    real_T *test8_rec = ssGetOutputPortRealSignal(S, 8);
    real_T *test9_rec = ssGetOutputPortRealSignal(S, 9);
    real_T *test10_rec = ssGetOutputPortRealSignal(S, 10);
    real_T *test11_rec = ssGetOutputPortRealSignal(S, 11);
    real_T *test12_rec = ssGetOutputPortRealSignal(S, 12);
    real_T *test13_rec = ssGetOutputPortRealSignal(S, 13);
    real_T *test14_rec = ssGetOutputPortRealSignal(S, 14);
    
    
    test_rec[0] = ego_speed_rec;
    test1_rec[0] = ego_posx_rec;
    test2_rec[0] = ego_posz_rec;
    test3_rec[0] = ego_acc_rec;
    test4_rec[0] = ego_direction_rec;
    test5_rec[0] = lead_presence_rec;
    test6_rec[0] = lead_speed_rec;
    test7_rec[0] = lead_posx_rec;
    test8_rec[0] = lead_posz_rec;
    test9_rec[0] = olane_presence_rec;
    test10_rec[0] = olane_speed_rec;
    test11_rec[0] = olane_posx_rec;
    test12_rec[0] = olane_posz_rec;
    test13_rec[0] = olane_direction_rec;
    test14_rec[0] = distance_rec;
    
     
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
