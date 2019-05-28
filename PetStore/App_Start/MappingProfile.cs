using AutoMapper;
using PetStore.Dtos;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Igracka, IgrackaDto>();
            Mapper.CreateMap<IgrackaDto, Igracka>()
                .ForMember(i => i.Id, opt => opt.Ignore());

            Mapper.CreateMap<Kategorija, KategorijaDto>();
        }
    }
}