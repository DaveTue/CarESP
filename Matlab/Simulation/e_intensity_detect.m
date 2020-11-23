function [goal_id,agent_id,event_id,action_id,LoS,LoF] = e_intensity_detect(event_0,event_detected,sf_total,check_hit,check_trigger,check_collision,gap_st,egocar_speed,max_speed)
    %Function to compute the goal, agent and LoS & LoF as a fucntion of the
    %events and other variables: pedestrian hit, speed of vehicle,
    %collision, and possitive/negative event detection
    
    safe=1-sf_total; %safe probability/ complement of the stress factor
    if event_0==1 && (event_detected==1)
        goal_id=6;
        agent_id=6;
        LoS=safe;
        LoF=sf_total;
        if check_trigger>=1 && check_hit<=0
            event_id=11;
            action_id=11;
        elseif check_hit==1
            event_id=12;
            action_id=12;
        else
            event_id=11;
            action_id=11;
        end  
    else
        if event_detected==1 
            goal_id=1;
            agent_id=1;
            LoS=0.5;
            LoF=0.5;
            if egocar_speed<=max_speed
                event_id=1;
                action_id=1;
            else
                event_id=2;
                action_id=2;
            end
        end
         if event_detected==2
            goal_id=8;
            agent_id=1;
            LoS=safe;
            LoF=sf_total;
             if sf_total<=safe
                event_id=13;
                action_id=13;
            else
                event_id=14;
                action_id=14;
            end
         end
         if event_detected==3
             goal_id=3;
             agent_id=1;
             LoS=safe;
             LoF=sf_total;
             if sf_total<=safe
                event_id=5;
                action_id=5;
            else
                event_id=6;
                action_id=6;
            end
         end
         
         if event_detected ==4
             goal_id=2;
             agent_id=3;
             LoS=safe;
             LoF=sf_total;
             if check_collision==1
                 goal_id=7;
                 agent_id=3;
                 event_id=12;
                 action_id=12;
             else
                 if gap_st==1
                     event_id=3;
                     action_id=3;
                 elseif gap_st==2
                     event_id=4;
                     action_id=4;
                 end
             end
         end
          if event_detected ==5
             goal_id=7;
             agent_id=3;
             LoS=safe;
             LoF=sf_total;
             if check_collision==0
                 event_id=11;
                 action_id=11;
             elseif check_collision==1
                 event_id=12;
                 action_id=12;
             end
           end
        
    end
end
