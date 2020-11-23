function [CDF_fail]=Prob_fail_each(x,D,alpha,beta,m)
%computation of probabilit of failure for each component of the car as a
%gamma distribution
    U=max(0,D-x);

       alpha_sys=alpha;
       beta_sys=beta;
       m_sys=m;
       
       
       CDF_fail=zeros(size(x));
     
        for n=1:size(x,2)

            convF=integral(@(z) ConvFun(z,x(n),alpha_sys,beta_sys,m_sys),0,x(n)); 

            prob=exp(-convF);%survival probability
            CDF_fail(n)=1-prob;% faliure probability
            
        end
     
        
    

end