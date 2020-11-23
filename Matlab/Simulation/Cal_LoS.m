function [LoS,LoF]=Cal_LoS(goal_id,LoS_0,LoF_0,fix)
% LoF function for the fix LoF tests in different goals scenerios. 
    if fix==1
        if goal_id==2
            LoS=0.5;
            LoF=0.5;
        elseif goal_id==3
            LoS=0.5;
            LoF=0.5;
        elseif goal_id==7
            LoS=1;
            LoF=0;
        elseif goal_id==8
            LoS=0.5;
            LoF=0.5;
        else
            LoS=0.5;
            LoF=0.5;
        end
    else
        LoS=LoS_0;
        LoF=LoF_0;
    end

end