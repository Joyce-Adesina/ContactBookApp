using AutoMapper;
using ContactBook_Domain.Dtos.Request;
using ContactBook_Domain.Dtos.Response;
using ContactBook_Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Application.MapInitializer
{
    public class MapInitializer : Profile
    {
        public MapInitializer() 
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<UserRequestDto, User>();
            CreateMap<Contact, ContactResponseDto>();
            CreateMap<ContactRequestDto, Contact>();
        }
    }
    
       
    
}
