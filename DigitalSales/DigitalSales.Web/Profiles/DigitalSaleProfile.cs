using DigitalSales.Entities.Warehouse;
using DigitalSales.Web.Models.Warehouse.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalSales.Web.Models.Warehouse.Article;

namespace DigitalSales.Web.Profiles
{
    public class DigitalSaleProfile : Profile
    {

        public DigitalSaleProfile()
        {
            this.CreateMap<Category, CategoryViewModel>().ReverseMap();
            this.CreateMap<Category, AddViewModel>().ReverseMap();
            this.CreateMap<Category, Models.Warehouse.Category.UpdateViewModel>().ReverseMap();
            this.CreateMap<Article, ArticleViewModel>().ReverseMap();
        }        
    }
}
