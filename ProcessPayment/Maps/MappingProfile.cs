using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProcessPayment.Dtos;
using ProcessPayment.Models;

namespace ProcessPayment.Maps
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentDto, PaymentDto>();

            CreateMap<Payment, GetPaymentDto>()
                .ForMember(dest => dest.PaymentState, opt =>
                    opt.MapFrom(src => src.PaymentState.State.ToString()));
        }
    }
}