using AutoMapper;
using vendor_Management.Dto;
using vendor_Management.Model;

namespace vendor_Management.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Vendor,VendorCreatingDto>().ReverseMap();
            CreateMap<VendorContactPerson, ContactCreatingDto>().ReverseMap();

        }

    }
}
