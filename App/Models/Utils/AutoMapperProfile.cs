using AutoMapper;
using Domain.Entity;

namespace App.Models.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Car, CarViewModel>();
            CreateMap<Flight, FlightViewModel>();
            CreateMap<Hotel, HotelViewModel>();
            CreateMap<Markup, MarkupViewModel>();
            CreateMap<User, UserViewModel>();

            CreateMap<CarViewModel, Car>();
            CreateMap<FlightViewModel, Flight>();
            CreateMap<HotelViewModel, Hotel>();
            CreateMap<MarkupViewModel, Markup>();
            CreateMap<UserViewModel, User>();
        }
    }
}
