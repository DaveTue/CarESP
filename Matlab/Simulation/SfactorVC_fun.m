function SF_VC=SfactorVC_fun(Prob_obj_detec,v2v_st,v2i_st,bd_conect_st,coop_auto_st)
%Function to compute the total competency  stress

%database;

ds_VC(1,:)=[2,0.22,0];
ds_VC(2,:)=[3,0.22,0];
ds_VC(3,:)=[6,0.26,0];
ds_VC(4,:)=[8,0.25,0];



row_VC=size(ds_VC,1);
Input_VC=zeros(row_VC,2);


Input_VC(1,:)=[v2v_st,2];
Input_VC(2,:)=[v2i_st,3];
Input_VC(3,:)=[bd_conect_st,6];
Input_VC(4,:)=[coop_auto_st,8];

if any(Input_VC(:,1)<1) ||  any(Input_VC(:,1)>2)
     
    fprintf ('\nError States should have values between 1 to 2\n')
else
        
        Mult_VC_var=zeros(row_VC,1);
       
        for k=1:row_VC
            
            P_state=Input_VC(k,1);
           
            ID=find(ds_VC(:,1)==Input_VC(k,2));
           
            Mult_VC_var(k)=ds_VC(ID,1+P_state);
        end
        
        [CDF_acc_VC]=Prob_acc_VC((1-Prob_obj_detec),Mult_VC_var);
        
end
SF_VC=CDF_acc_VC;
end