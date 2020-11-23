function [cabine_st,tires_st,wheels_st,motor_st,dashboard_st,door_st,body_st,windshield_st,ligths_st,comm_st] = bodymapfn(anger,disgust,fear,happiness,neutral,sadness, surprise,stress)
   %function for Rule mapping definition of basic emotions to the systems of the vehicle
    cabine_st=happiness+sadness;
    tires_st=fear+disgust+surprise;
    wheels_st=anger;
    motor_st=anger;
    windshield_st=sadness;
    ligths_st=sadness;
    comm_st=happiness+sadness;
    
    dashboard_st=stress+fear-stress*fear;
    door_st=stress+fear-stress*fear;
    body_st=stress+fear-stress*fear;
    
  
end