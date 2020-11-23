%Data extraction from Simulink model to .mat files for analysis
t=Emotions_Values{1}.Values.Time;

anger_value=Emotions_Values{1}.Values.Data;
disgust_value=Emotions_Values{2}.Values.Data;
fear_value=Emotions_Values{3}.Values.Data;
happiness_value=Emotions_Values{4}.Values.Data;
neutral_value=Emotions_Values{5}.Values.Data;
sadness_value=Emotions_Values{6}.Values.Data;
surprice_value=Emotions_Values{7}.Values.Data;

emotions=[t,anger_value,disgust_value,fear_value,happiness_value,neutral_value,sadness_value,surprice_value];
save('emotions_val_SC12','emotions')

time2=stress_factor{1}.Values.Time;
Stress_Vhealth=stress_factor{1}.Values.Data;
Stress_environment=stress_factor{2}.Values.Data;
Stress_VC=stress_factor{3}.Values.Data;
Stress_Vdriving=stress_factor{4}.Values.Data;
Stress_total=stress_factor{5}.Values.Data;
Stress=[time2,Stress_Vhealth,Stress_environment,Stress_VC,Stress_Vdriving,Stress_total];
save('stress_value_SC12','Stress')


time5=suggested_speed{1}.Values.Time;
suggested_optspeed=suggested_speed{1}.Values.Data;
opt_speed=[time5,suggested_optspeed];
save('opt_speed_value_SC12','opt_speed')

%{
time5=suggested_speed.Time;
suggested_optspeed=suggested_speed.signals.values;
opt_speed=[time5,suggested_optspeed];
save('opt_speed_value_SC12','opt_speed')
%}


time6=Utility{1}.Values.Time;
utility=Utility{1}.Values.Data; 
utility_val=[time6,utility];
save('utility_value_SC12','utility_val')

time7=egocar_speed{1}.Values.Time;
speed_car=egocar_speed{1}.Values.Data;
egogap=gap{1}.Values.Data;
egocar_speed=[time7,speed_car,egogap];
save('egocar_speed_value_SC12','egocar_speed')

time3=goal_event{1}.Values.Time;
scenario_detected=goal_event{1}.Values.Data;
goal_id=goal_event{2}.Values.Data;
event_id=goal_event{3}.Values.Data;
scenerio_goal_event=[time3,scenario_detected,goal_id,event_id];
save('ScGoalEvent_val_SC12','scenerio_goal_event')

time4=emotion_contribution{1}.Values.Time;
emotion_index=index_emotions{1}.Values.Data;
index_contribution=emotion_contribution{1}.Values.Data;
otheremotions=[time4,emotion_index,index_contribution];
save('otheremotions_val_SC12','otheremotions')

time8=curvedetection{1}.Values.Time;
curvedetection= curvedetection{1}.Values.Data;
curveflag=[time8,curvedetection];
save('curveflag_value_SC12','curveflag')
%}

time9=healthfactor{1}.Values.Time;
healthfactor= healthfactor{1}.Values.Data;
HF=[time8,healthfactor];
save('HF_value_SC12','HF')

clear all