function [CDF_acc_VC]=Prob_acc_VC(P_acc_VC,Mult_VC_var)
%Function to compute the competency stress factor as the decrease of
%uncertainty for recognition due to enable of system for object
%recognition. 
CDF_acc_VC=P_acc_VC; %uncertainty of object recognition
n=size(Mult_VC_var,1);
    for i=1:n
    
        CDF_acc_VC=CDF_acc_VC*(1-Mult_VC_var(i));
       
        
    end

end