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
            this.CreateMap<Category, Models.Warehouse.Category.AddViewModel > ().ReverseMap();
            this.CreateMap<Category, Models.Warehouse.Category.UpdateViewModel>().ReverseMap();
            this.CreateMap<Category, Models.Warehouse.Category.SelectViewModel>().ReverseMap();
            this.CreateMap<Article, ArticleViewModel>().ReverseMap();
            this.CreateMap<Article, Models.Warehouse.Article.AddViewModel>().ReverseMap();
            this.CreateMap<Article, Models.Warehouse.Article.UpdateViewModel>().ReverseMap();
        }        
    }
}
