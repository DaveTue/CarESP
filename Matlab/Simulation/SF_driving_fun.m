    function [SF_driving,gap]= SF_driving_fun(speed_ecar,a_vehicle,event_id,gravity,avg_speed,rate_acc,rate_desacc,crit_gap,pos_ecar_x,pos_ecar_z,rot_ecar,pos_lead_car_x,pos_lead_car_z,speed_lead_car,olanecar_presence,pos_olane_car_x,pos_olane_car_z,rot_olane_car,speed_olane_car,check_if_hit,collisiondetection)
% Computation of the Vehicle operation stress. 
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%{
possible events:
- driving alone
    -straingt line. event_id=1
    -curve. event_id=2
    -lane change. event_id=3 
- driving with another car
    -following another car. event_id=4
    -overtake. event_id=5
%}
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
   
    %a_vehicle=(speed_ecar-speed_0)/(time-time_0);
    
    %changes in code 
    %%%%%%%%%%%%%%%
    if a_vehicle>0
        a_mean=rate_acc;
    else
        a_mean=rate_desacc;
    end
    v_kh_mean=avg_speed*3600/1000;
    if v_kh_mean>=150
        v_kh_mean=150;
    end
    fc_long_mean=0.214*(v_kh_mean/100)^2-0.640*(v_kh_mean/100)+0.615;
    fc_lat_mean=0.925*fc_long_mean;
     if event_id==1 || event_id==4
        mean_exp=abs((gravity*fc_long_mean)/a_mean);
     elseif event_id==2 || event_id==3 || event_id==5
        mean_exp=abs((gravity*fc_lat_mean)/a_mean);  
     end
    
        %%%%%%%%%%%%%%%%%%
    v_kh=speed_ecar*3600/1000;
    if v_kh>=150
        v_kh=150;
    end
    fc_long=0.214*(v_kh/100)^2-0.640*(v_kh/100)+0.615;
    fc_lat=0.925*fc_long;
    %changes
    %%%%%%%%%%%%%%%%%%
    if a_vehicle==0
        X=inf;
    else
        if event_id==1 || event_id==4
            X=abs((gravity*fc_long)/a_vehicle);
         elseif event_id==2 || event_id==3 || event_id==5
            X=abs((gravity*fc_lat)/a_vehicle);  
        end
    end
    SF_acc=mean_exp*exppdf(X,mean_exp);
   %%SF_acc=expcdf(X,1);
    %%%%%%%%%%%%%%%%%%
    %Changs requiered this to be comment out
    %{
     if event_id==1 || event_id==4
        SF_acc=min(1,abs(a_vehicle/(gravity*fc_long)));
     elseif event_id==2 || event_id==3 || event_id==5
        SF_acc=min(1,abs(a_vehicle/(gravity*fc_lat)))    ;  
     end
    %}
     %%%%%
    %l_lead_car=4.78;%unity units
     l_lead_car=4.78;%https://www.automobiledimension.com/car-comparison.php BMX X5
     w_ego_car=1.58; %unity units
     rode_wide=8; %unity units
     %egocar_lane=0;
     if event_id==4 || event_id==5
             if (rot_ecar<=135 && rot_ecar>=45) || (rot_ecar<315 && rot_ecar>225)
                     ego_car_pos=(pos_ecar_x);
                     if (rot_ecar<=135 && rot_ecar>=45)
                        dir=1;
                     else
                        dir=-1;
                     end
                     ego_car_wideleft=pos_ecar_z-dir*w_ego_car/2;
                     ego_car_widerigth=pos_ecar_z+dir*w_ego_car/2;
                    
                    if event_id==4
                        lead_car_pos=(pos_lead_car_x);
                        lead_car_speed=speed_lead_car;
                     elseif event_id==5
                      %path_lead_1=pos_lead_car_z-rode_wide/2;
                      %path_lead_2=pos_lead_car_z+rode_wide/2;
                      
                      path_olane_1=pos_olane_car_z-rode_wide/2;
                      path_olane_2=pos_olane_car_z+rode_wide/2;
                      
                      
                      %Lane for egocar
                      if ego_car_wideleft>= path_olane_1 && ego_car_widerigth<=path_olane_2
                           egocar_lane=1;
                      else
                          egocar_lane=0;
                      end
                      if egocar_lane==0
                            lead_car_pos=(pos_lead_car_x);
                            lead_car_speed=speed_lead_car;
                          elseif egocar_lane==1
                            lead_car_pos=(pos_olane_car_x);
                            if (rot_olane_car<=135 && rot_olane_car>=45 && dir==1)|| (rot_olane_car<315 && rot_olane_car>225 && dir==-1)
                                lead_car_speed=speed_olane_car;
                            elseif  (rot_olane_car<315 && rot_olane_car>225 && dir==1) ||(rot_olane_car<=135 && rot_olane_car>=45 && dir==-1)
                                lead_car_speed=-speed_olane_car;
                            end
                      end
                    end
             
                
         else
             ego_car_pos=(pos_ecar_z);
             if (rot_ecar>135 && rot_ecar<=225)
                dir=-1;
             else
                dir=1;
             end
             ego_car_wideleft=pos_ecar_z-dir*w_ego_car;
             ego_car_widerigth=pos_ecar_z+dir*w_ego_car;
             if event_id==4
                        lead_car_pos=(pos_lead_car_z);
                        lead_car_speed=speed_lead_car;
              elseif event_id==5                  
                      path_olane_1=pos_olane_car_x-rode_wide/2;
                      path_olane_2=pos_olane_car_x+rode_wide/2;
                      %Lane for egocar
                      if ego_car_wideleft>= path_olane_1 && ego_car_widerigth<=path_olane_2
                           egocar_lane=1;
                      else
                          egocar_lane=0;
                      end
                      if egocar_lane==0
                            lead_car_pos=(pos_lead_car_z);
                            lead_car_speed=speed_lead_car;
                      elseif egocar_lane==1
                            lead_car_pos=abs(pos_olane_car_z);
                            if (rot_olane_car>135 && rot_olane_car<=225 && dir==1)|| (rot_olane_car>=315 && rot_olane_car<=365 && dir==-1)||(rot_olane_car>=0 && rot_olane_car<=45 && dir==-1)
                                lead_car_speed=speed_olane_car;
                            elseif  (rot_olane_car>=315 && rot_olane_car<365 && dir==1) ||(rot_olane_car>135 && rot_olane_car<=225 && dir==-1) || (rot_olane_car>=0 && rot_olane_car<=45 && dir==1)
                                lead_car_speed=-speed_olane_car;
                            end
                      end
            end
         end
         if speed_ecar<=lead_car_speed
             TTC=inf;
             %dist_delta=(lead_car_pos-ego_car_pos)*dir;
             gap=inf;
         elseif olanecar_presence==0 && event_id==5  
             TTC=inf;
             gap=inf;
         else
             dist_delta=(lead_car_pos-ego_car_pos)*dir;
             
             if dist_delta<=0
                 TTC=inf;
                 gap=inf;
             else
                TTC= (dist_delta-l_lead_car)/(speed_ecar-lead_car_speed);
                gap=TTC*(speed_ecar-lead_car_speed)/speed_ecar;
             end
         end
         SF_col=crit_gap*exppdf(TTC,crit_gap);
     
     end
     if event_id==1 || event_id==2 || event_id==3
         SF_col=0;
         gap=inf;
     end
     if check_if_hit==1 || collisiondetection==1
         SF_driving=1;
     else
        SF_driving=SF_col+SF_acc-SF_acc*SF_col;
     end
     
end
