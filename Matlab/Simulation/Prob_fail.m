function [CDF_fail]=Prob_fail(x,D,alpha,beta,m)
%function to compute the total probability to fail (health stress). 
U=max(0,D-x);
[U_sys,index]=min(U(U>0));
       alpha_sys=alpha(index);
       beta_sys=beta(index);
       
       m_sys=mean(m);
       
       
       CDF_fail=zeros(size(x));
     
        for n=1:size(x,2)

            convF=integral(@(z) ConvFun(z,x(n),alpha_sys,beta_sys,m_sys),0,x(n)); %gamma probability

            prob=exp(-convF);% survival probability 
            CDF_fail(n)=1-prob; % failure probability
           
        end
     
        
    

end