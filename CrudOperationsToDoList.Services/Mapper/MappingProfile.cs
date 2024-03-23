using AutoMapper;
using CrudOperationsToDoList.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationsToDoList.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ToDo, ToDoDTO>()
        .ReverseMap();
    }
}