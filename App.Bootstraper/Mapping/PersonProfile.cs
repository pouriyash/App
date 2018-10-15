using App.DomainModels.Dto.Person;
using App.DomainModels.Entities.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Bootstraper.Mapping
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonSummary>();
        }
    }
}
