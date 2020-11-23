function y= ConvFun(x,t,alpha,beta,m)
    %Gamma pdf defined for the failure prediction on the Health stress
    %factor funtion
    y = m.*x.*gamcdf(t-x,alpha,beta);

end