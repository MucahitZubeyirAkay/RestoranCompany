using AutoMapper;
using ENTITIES.Entity;
using RestoranCompany.Entities;
using RestoranCompany.Entity;
using RestoranCompany.Models;

namespace RestoranCompany
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, CreateUserModel>().ReverseMap();
            CreateMap<User, EditUserModel>().ReverseMap();
            CreateMap<Kategori, CategoryViewModel>().ReverseMap();
            CreateMap<Kategori, CreatCategoryModel>().ReverseMap();
            CreateMap<Kategori, EditCategoryModel>().ReverseMap();
            CreateMap<Urun, UrunModel>().ReverseMap();
            CreateMap<Urun, CreatUrunModel>().ReverseMap();
            CreateMap<Urun, EditUrunModel>().ReverseMap();
            //CreateMap<Siparis, SiparisModel>().ReverseMap();


        }
    }
}
