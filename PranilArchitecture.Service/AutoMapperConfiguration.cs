using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PranilArchitecture.Service
{
    public class AutoMapperConfiguration
    {
        private static MapperConfiguration mapperConfiguration;

        public static IMapper Mapper { get; set; }

        public static void Configure()
        {
            mapperConfiguration = new MapperConfiguration(x => { x.AddProfile<DomainToViewModelMappingProfile>(); });
            Mapper = mapperConfiguration.CreateMapper();
        }

    }
}
