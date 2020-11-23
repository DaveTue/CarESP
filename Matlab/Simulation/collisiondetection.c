#define S_FUNCTION_NAME collisiondetection /* Defines and Includes */
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
#define PORT 54319	//The port on which to listen for incoming data

// Global variables
WSADATA wsa; 
int s;
struct sockaddr_in si_other;
int terminate_threads;
int slen = sizeof(si_other);
char buf[BUFLEN];
char message[BUFLEN];

float test = 0;
//float test1 = 0;
float t_rec = 0;
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

    char* p = strtok(str, ",");
	t_rec = strtof(p, NULL);
    
    //p = strtok(str, ",");
	//t1_rec = strtof(p, NULL);
}

void send_udp() {
    sprintf(message, "%f\n", test);
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

    if (!ssSetNumInputPorts(S, 1)) return;
    
    // set position and rotation posrt sizes (drone, ball, team1 x 7, team2 x 7) = 32
    ssSetInputPortWidth(S, 0, 1);
    ssSetInputPortDirectFeedThrough(S, 0, 0);
    
    //ssSetInputPortWidth(S, 1, 1);
    //ssSetInputPortDirectFeedThrough(S, 1, 0);

    if (!ssSetNumOutputPorts(S, 1)) return;

     ssSetOutputPortWidth(S, 0, 1);
     //ssSetOutputPortWidth(S, 1, 1);
     
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
    InputRealPtrsType test_sig = ssGetInputPortRealSignalPtrs(S, 0);
    //InputRealPtrsType test1_sig = ssGetInputPortRealSignalPtrs(S, 1);
    
    test = (float) **test_sig;
    //test1 = (float) **test1_sig;
    
} 

static void mdlOutputs(SimStruct *S, int_T tid)
{
    send_udp();
    recv_udp();
    
    real_T *test_rec = ssGetOutputPortRealSignal(S, 0);
    //real_T *test1_rec = ssGetOutputPortRealSignal(S, 1);
    
    test_rec[0] = t_rec;
    //test1_rec[0] = t1_rec;
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
