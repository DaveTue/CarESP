function U = Utility_fun_opt(x,r,max_x)
%function to compute the utility of the speed as a function of the r (personality indicator)    
if x==0
    U_temp=0;
else
    if r>=1
        r=0.999;
    end
    U_temp=((x)^(1-r))/(1-r);
end
    max_U=((max_x)^(1-r))/(1-r);
    U=U_temp/max_U;
    
end