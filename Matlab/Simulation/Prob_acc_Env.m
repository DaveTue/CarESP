function [CDF_acc_Env]=Prob_acc_Env(P_acc,Mult_env_var)
%Function to compute the environmental stress cumulative probability as a
%mutually inclusive probability.
CDF_acc_Env=0;
CDF_acc_Env_0=zeros(size(Mult_env_var,1));
n=size(Mult_env_var,1);
    for i=1:n
       
        CDF_acc_Env_0(i)=P_acc*Mult_env_var(i);
        CDF_acc_Env=CDF_acc_Env+CDF_acc_Env_0(i)-CDF_acc_Env_0(i)*CDF_acc_Env;
        
        

    end
    CDF_acc_Env=min(1,CDF_acc_Env);
end