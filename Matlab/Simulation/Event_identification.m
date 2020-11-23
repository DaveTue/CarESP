function event_id = Event_identification(egocar_x,egocar_z,egocar_rot,olanecar_presence, leadcar_presence,turn_trigger)
%Event identificion between: straght line, car following, lane change,
%overtaking. All using the unity units. 

%straight line lane change

w_ego_car=1.58; %unity units
lanechange_trigger=0;
    if egocar_rot>=45 && egocar_rot<=135      
        lane_position=816;%z coordinate
        egocar_l=egocar_z-w_ego_car/2;
        egocar_r=egocar_z+w_ego_car/2; 
        direction=1;
    elseif egocar_rot>=225 && egocar_rot<=315
        lane_position=962; %z coordianates
        egocar_l=egocar_z+w_ego_car/2;
        egocar_r=egocar_z-w_ego_car/2;
        direction=-1;
    elseif egocar_rot>135 && egocar_rot<225
        lane_position=954;%xcoordinates
        egocar_l=egocar_x-w_ego_car/2;
        egocar_r=egocar_x+w_ego_car/2;
        direction=1;
    elseif egocar_rot>315 && egocar_rot<=360 || egocar_rot>=0 && egocar_rot<45
        lane_position=752.5;%xcoordinates
         egocar_l=egocar_x+w_ego_car/2;
        egocar_r=egocar_x-w_ego_car/2;
        direction=-1;
    end
    
     if egocar_l>lane_position && direction==1 || egocar_r<lane_position && direction==1
           lanechange_trigger=0;
     elseif egocar_l<lane_position && direction==-1 || egocar_r>lane_position && direction==-1
           lanechange_trigger=0;
     end
      
     if  direction ==1 && egocar_l<=lane_position && egocar_r>=lane_position
         lanechange_trigger=1;
     elseif direction ==-1 && egocar_l>=lane_position && egocar_r<=lane_position
         lanechange_trigger=1;
     end


    %overtaking and car following
    if olanecar_presence==1 && leadcar_presence==1 || olanecar_presence==0 && leadcar_presence==1 && lanechange_trigger==1    
            event_id=5;
    elseif olanecar_presence==0 && leadcar_presence==1 && lanechange_trigger==0
            event_id=4;
    elseif lanechange_trigger==1 && olanecar_presence==0 && leadcar_presence==0 && turn_trigger==0
            event_id=3;
    elseif turn_trigger==1 && olanecar_presence==0 && leadcar_presence==0
            event_id=2;
    else
        event_id=1;
    end
end