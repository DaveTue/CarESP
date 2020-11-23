function ob_recog_st = ob_recog_st_comp(obt_recog)
%Computation of object recognition state variable as a function of the
%uncertainty of obj recognition
    if obt_recog==1
        ob_recog_st=1;
    elseif obt_recog>=0.75 && obt_recog < 1
        ob_recog_st=2;
    elseif obt_recog>=0.5 && obt_recog < 0.75
        ob_recog_st=3;
    elseif obt_recog>=0.25 && obt_recog < 0.5
        ob_recog_st=4;
    elseif obt_recog<0.25
        ob_recog_st=5;
    end
end