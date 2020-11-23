function gap_st  = gap_st_comp(avg_gap,gap)
%Gap state computing
if  gap==inf
    gap_st=1;
elseif gap>= avg_gap
    gap_st=1;
elseif gap<avg_gap
    gap_st=2;
end
