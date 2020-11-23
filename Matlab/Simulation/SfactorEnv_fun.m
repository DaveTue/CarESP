function SF_Env=SfactorEnv_fun(Mean_acc_road,SD_acc_road,acc_road_today,road_surface_st,road_cond_st,weather_st,time_day_st,egocar_speed,avgspeed_data)
%Function for the computation of the environmental total stress 

%Database
ds_Env(1,:)=[1,0.12,0.12,0.49,0.16,0.11];
ds_Env(2,:)=[2,0,0.0149,0.0181,0,0];
ds_Env(3,:)=[8,0.235,0.235,0.227,0.227,0.256];
ds_Env(4,:)=[9,0.000006,0.000006,0.000009,0.000012,0.00026];

% data for acccients: https://www.statista.com/statistics/322906/car-drivers-involved-in-road-accidents-in-great-britain-uk/
    if egocar_speed==0 || avgspeed_data==0
        mean_acc=Mean_acc_road;
    else

        mean_acc=Mean_acc_road;
    end
pdf_Prob_acc=normpdf(acc_road_today+1,mean_acc,SD_acc_road);
cdf_Prob_acc=normcdf(acc_road_today,mean_acc,SD_acc_road);
if cdf_Prob_acc==0
    P_acc=1;
else
    P_acc=min(1,pdf_Prob_acc/cdf_Prob_acc);
end



row_Env=size(ds_Env,1);


Input_Env(1,:)=[road_surface_st,1];
Input_Env(2,:)=[road_cond_st,2];
%Input_Env(3,:)=[P_acc_road_st,3];
Input_Env(3,:)=[weather_st,8];
Input_Env(4,:)=[time_day_st,9];

if any(Input_Env(:,1)<1) ||  any(Input_Env(:,1)>5) 
     fprintf ('\nError States can not have a value lower than 1 or bigger than 5\n')
 else
    for i=1:row_Env
        if convertStringsToChars(strcat('Env_',string(Input_Env(i,2))))=='Env_2'
               index_Env=i;
        end
        
    end
    if Input_Env(index_Env,2)>3
        fprintf ('\nError State of Env_2 can not have a value lower than 1 or bigger than 3\n')
    else
        Mult_env_var=zeros(row_Env,1);
    
        for k=1:row_Env
            P_state=Input_Env(k,1);
            ID=find(ds_Env(:,1)==Input_Env(k,2));
            Mult_env_var(k)=ds_Env(ID,1+P_state);
        end
        
        [CDF_acc_Env]=Prob_acc_Env(P_acc,Mult_env_var);
       
    end
    SF_Env=CDF_acc_Env;
end
end