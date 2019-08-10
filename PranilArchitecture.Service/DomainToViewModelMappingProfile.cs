using AutoMapper;
using PranilArchitecture.Data;
using PranilArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PranilArchitecture.Service
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
            : base("DomainToViewModelMappings")
        {
            CreateMap<ExpenseType, ExpenseTypeEntity>();
            CreateMap<MeetingSubject, MeetingSubjectEntity>();
        }
    }
}
