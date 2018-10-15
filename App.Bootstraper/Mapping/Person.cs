using App.DomainModels.Dto.Person;
using App.DomainModels.Entities.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Bootstraper.Mapping
{
    public class Person:Profile
    {
        public Person()
        {
            CreateMap<Person, PersonSummary>();
        }
    }
}
