function prob_acc_road_st = prob_acc_road_st_fun(acc_road_today,mean_acc,SD_acc_road)
 %function to compute the state of the probability of an accident.
 %Modelling the probability of an accident as a normal pdf. 

    pdf_Prob_acc=normpdf(acc_road_today+1,mean_acc,SD_acc_road);
    cdf_Prob_acc=normcdf(acc_road_today,mean_acc,SD_acc_road);

    P_acc=min(1,pdf_Prob_acc/cdf_Prob_acc);
    
    if P_acc<0.1
        prob_acc_road_st=1;
    elseif P_acc>=0.1 && P_acc < 0.25
        prob_acc_road_st=2;
    elseif P_acc>=0.25 && P_acc < 0.4
        prob_acc_road_st=3;
    elseif P_acc>=0.4 && P_acc < 0.55
        prob_acc_road_st=4;
    elseif P_acc>=0.55
        prob_acc_road_st=5;
    end

end
