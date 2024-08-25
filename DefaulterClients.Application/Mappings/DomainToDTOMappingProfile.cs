using AutoMapper;
using AutoMapper.Configuration.Conventions;
using DefaulterClients.Application.DTOs.Request.Billing;
using DefaulterClients.Application.DTOs.Request.Client;
using DefaulterClients.Application.DTOs.Request.User;
using DefaulterClients.Application.DTOs.Result.Billing;
using DefaulterClients.Application.DTOs.Result.Client;
using DefaulterClients.Application.DTOs.Result.User;
using DefaulterClients.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaulterClients.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Client,ClientRequestDTO>().ReverseMap();
        CreateMap<User,UserResquestDTO>().ReverseMap();
        CreateMap<Billing,BillingRequestDTO>().ReverseMap();


        //User
        CreateMap<User, LoginModelRequestDTO>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

        CreateMap<User, UserResquestDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

        CreateMap<UserResponse, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ReverseMap();


        CreateMap<UserByIdResponse, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdateAt))
            .ForMember(dest => dest.Clients, opt => opt.MapFrom(src => src.Clients)).ReverseMap();


        CreateMap<UserDeletedResponse, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdateAt)).ReverseMap();

        CreateMap<UserResquestDTO, LoginModelRequestDTO>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password)).ReverseMap();

        CreateMap<UserByIdResponse, UserUpdateRequestDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        CreateMap<UserUpdateRequestDTO, UserByIdResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));


        //Client

        CreateMap<ClientResponse, Client>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.Document))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Adress))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User)).ReverseMap();

        CreateMap<ClientUpdateRequestDTO, Client>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.Document))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone)).ReverseMap();


        //Billing
        CreateMap<BillingResult, Billing>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.Paid, opt => opt.MapFrom(src => src.Paid))
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
            .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client)).ReverseMap();

        CreateMap<BillingRequestDTO, BillingResult>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.Paid, opt => opt.MapFrom(src => src.Paid))
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
            .ReverseMap();
       

    }
}
