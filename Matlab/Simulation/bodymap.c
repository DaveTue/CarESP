#define S_FUNCTION_NAME bodymap /* Defines and Includes */
#define S_FUNCTION_LEVEL 2         
//to copile mex -O bodymap.c
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
float cabine = 0;
float tires = 0;
float wheels = 0;
float motor = 0;
float dahboard = 0;
float door = 0;
float body = 0;
float windshield = 0;
float light=0;
float communication=0;

//float stress=0;

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
    sprintf(message, "%f,%f,%f,%f,%f,%f,%f,%f,%f,%f\n",cabine,tires,wheels,motor,dahboard,door,body,windshield,light,communication);
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
    if (!ssSetNumInputPorts(S, 10)) return;
    
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
    InputRealPtrsType cabine_sig = ssGetInputPortRealSignalPtrs(S, 0);
    InputRealPtrsType tires_sig = ssGetInputPortRealSignalPtrs(S, 1);
    InputRealPtrsType wheels_sig = ssGetInputPortRealSignalPtrs(S, 2);
    InputRealPtrsType motor_sig = ssGetInputPortRealSignalPtrs(S, 3);
    InputRealPtrsType dahboard_sig= ssGetInputPortRealSignalPtrs(S, 4);
    InputRealPtrsType door_sig = ssGetInputPortRealSignalPtrs(S, 5);
    InputRealPtrsType body_sig = ssGetInputPortRealSignalPtrs(S, 6);
    InputRealPtrsType windshield_sig = ssGetInputPortRealSignalPtrs(S, 7);
    InputRealPtrsType light_sig = ssGetInputPortRealSignalPtrs(S, 8);
    InputRealPtrsType communication_sig = ssGetInputPortRealSignalPtrs(S, 9);
    //assigning values to be sent to their respective variables
   // mood = (float) **mood_sig;
    cabine= (float) **cabine_sig;
    tires= (float) **tires_sig;
    wheels= (float) **wheels_sig;
    motor= (float) **motor_sig;
    dahboard= (float) **dahboard_sig;
    door= (float) **door_sig;
    body= (float) **body_sig;
    windshield= (float) **windshield_sig;
    light= (float) **light_sig;
    communication= (float) **communication_sig;

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
