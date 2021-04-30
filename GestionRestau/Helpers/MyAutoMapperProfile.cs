using AutoMapper; 
using GestionRestau.Models;
using GestionRestau.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Helpers
{
    public class MyAutoMapperProfile : Profile
    {
        public MyAutoMapperProfile()
        {
            CreateMap<TableCmd, TableCmdViewModel>()
                .ReverseMap();

            CreateMap<TableCmd, DetailsTableCmdViewModel>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Serveur.Name))
                .ForMember(dest => dest.Telephone,
                    opt => opt.MapFrom(src => src.Serveur.Telephone))
                .ForMember(dest => dest.NbPlace,
                    opt => opt.DoNotUseDestinationValue());

        }

    }
}
