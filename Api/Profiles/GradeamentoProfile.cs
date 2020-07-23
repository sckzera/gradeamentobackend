using System.Collections.Generic;
using AutoMapper;

namespace gradeamento_backend.Api.Profiles
{
    public class GradeamentoProfile : Profile
    {
        public GradeamentoProfile()
        {
            CreateMap<Models.GradeamentoInclusao, Entities.Gradeamento>();
            CreateMap<List<Entities.Gradeamento>, List<Models.GradeamentoListaRetorno>>();
            CreateMap<List<Models.GradeamentoListaRetorno>,Entities.Gradeamento>();
        }
    }
}