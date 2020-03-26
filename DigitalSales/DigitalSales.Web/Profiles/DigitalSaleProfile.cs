using DigitalSales.Entities.Warehouse;
using DigitalSales.Web.Models.Warehouse.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalSales.Web.Models.Warehouse.Article;
using DigitalSales.Entities.Users;
using DigitalSales.Web.Models.Users;
using DigitalSales.Web.Models.Users.Role;
using DigitalSales.Entities.Sales;

namespace DigitalSales.Web.Profiles
{
    public class DigitalSaleProfile : Profile
    {

        public DigitalSaleProfile()
        {
            this.CreateMap<Category, CategoryViewModel>().ReverseMap();
            this.CreateMap<Category, Models.Warehouse.Category.AddViewModel > ().ReverseMap();
            this.CreateMap<Category, Models.Warehouse.Category.UpdateViewModel>().ReverseMap();
            this.CreateMap<Category, Models.Warehouse.Category.SelectViewModel>().ReverseMap();
            
            this.CreateMap<Article, ArticleViewModel>().ReverseMap();
            this.CreateMap<Article, Models.Warehouse.Article.AddViewModel>().ReverseMap();
            this.CreateMap<Article, Models.Warehouse.Article.UpdateViewModel>().ReverseMap();
            
            this.CreateMap<Role, RoleViewModel>().ReverseMap();
            this.CreateMap<Role, Models.Users.Role.AddViewModel>().ReverseMap();
            this.CreateMap<Role, Models.Users.Role.UpdateViewModel>().ReverseMap();
            this.CreateMap<Role, Models.Users.Role.SelectViewModel>().ReverseMap();

            this.CreateMap<User, Models.Users.User.UserViewModel>().ReverseMap();
            this.CreateMap<User, Models.Users.User.AddViewModel>().ReverseMap();
            this.CreateMap<User, Models.Users.User.UpdateViewModel>().ReverseMap();

            this.CreateMap<Person, Models.Sales.Person.PersonViewModel>().ReverseMap();
            this.CreateMap<Person, Models.Sales.Person.AddViewModel>().ReverseMap();
            this.CreateMap<Person, Models.Sales.Person.UpdateViewModel>().ReverseMap();
            this.CreateMap<Person, Models.Sales.Person.SelectViewModel>().ReverseMap();

            this.CreateMap<Entry, Models.Warehouse.Entry.EntryViewModel>().ReverseMap();
            this.CreateMap<Entry, Models.Warehouse.Entry.AddEntryViewModel>().ReverseMap();
            this.CreateMap<DetailEntry, Models.Warehouse.Entry.DetailViewModel>().ReverseMap();
        }        
    }
}
