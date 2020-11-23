function [speed_opt,max_fun]=Opt_Fun(SF_VH,SF_VC,r,max_speed,a_vehicle,event_id,gravity,avg_speed,rate_acc,rate_desacc,crit_gap,pos_ecar_x,pos_ecar_z,rot_ecar,pos_lead_car_x,pos_lead_car_z,speed_lead_car,olanecar_presence,pos_olane_car_x,pos_olane_car_z,rot_olane_car,speed_olane_car,check_if_hit,collisiondetection,Mean_acc_road,SD_acc_road,acc_road_today,road_surface_st,road_cond_st,weather_st,time_day_st,avgspeed_data) 
%Function to compute the optimization of the speed as a function of the
%stress factor and the personality. 
 speed=linspace(0.1,max_speed,200);
 Fun=zeros(size(speed));
 for i=1:size(speed,2)
     x=speed(i);
     max_x=max_speed;
    U(i) = Utility_fun_opt(x,r,max_x);
    SF_Env(i)=SfactorEnv_fun(Mean_acc_road,SD_acc_road,acc_road_today,road_surface_st,road_cond_st,weather_st,time_day_st,speed(i),avgspeed_data);
    [SF_driving(i),gap]= SF_driving_fun(speed(i),a_vehicle,event_id,gravity,avg_speed,rate_acc,rate_desacc,crit_gap,pos_ecar_x,pos_ecar_z,rot_ecar,pos_lead_car_x,pos_lead_car_z,speed_lead_car,olanecar_presence,pos_olane_car_x,pos_olane_car_z,rot_olane_car,speed_olane_car,check_if_hit,collisiondetection);
    P1=SF_VH+SF_Env(i)-SF_VH*SF_Env(i);
    P2=P1+SF_VC-P1*SF_VC;
    
    SF(i)=P2+SF_driving(i)-P2*SF_driving(i);
    Fun(i)=-SF(i)+U(i);
    if Fun(i)>-.01 && Fun(i)<0.01
        index=i;
    end
 end
  
   max_fun=Fun(index);
    speed_opt=speed(index);
 
    save('Utility_op','speed','SF','U');

end