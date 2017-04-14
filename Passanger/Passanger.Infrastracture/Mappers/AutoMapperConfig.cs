using AutoMapper;
using Passanger.Core.Domain;
using Passanger.Infrastucture.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passanger.Infrastucture.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => 
            { 
                cfg.CreateMap<User, UserDto>();
            })
            .CreateMapper();
    }
}
