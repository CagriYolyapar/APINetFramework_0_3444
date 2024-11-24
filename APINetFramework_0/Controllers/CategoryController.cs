using APINetFramework_0.DesignPatterns.SingletonPattern;
using APINetFramework_0.Models;
using APINetFramework_0.ViewModels.RequestModels.Categories;
using APINetFramework_0.ViewModels.ResponseModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APINetFramework_0.Controllers
{
    public class CategoryController : ApiController
    {
        NorthwindEntities1 _db;
        public CategoryController()
        {
            _db = DBTool.DbInstance;
            
        }

        List<CategoryResponseModel> ListCategories()
        {
            return _db.Categories.Select(x => new CategoryResponseModel
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Id = x.CategoryID
            }).ToList();
        }


        [HttpGet]
        public List<CategoryResponseModel> GetCategories()
        {
            return ListCategories();
        }

        [HttpGet]
        public CategoryResponseModel GetCategory(int id)
        {
            return _db.Categories.Where(x => x.CategoryID == id).Select(x => new CategoryResponseModel
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Id = x.CategoryID
            }).FirstOrDefault();
        }

        [HttpPost]
        public List<CategoryResponseModel> AddCategory(CreateCategoryRequestModel createCategory)
        {
            Category c = new Category()
            {
                CategoryName = createCategory.CategoryName,
                Description = createCategory.Description
            };
            _db.Categories.Add(c);
            _db.SaveChanges();
            return ListCategories();
        }

        [HttpPut]
        public List<CategoryResponseModel> UpdateCategory(UpdateCategoryRequestModel updateCategory)
        {
            Category c = _db.Categories.Find(updateCategory.Id);
            c.CategoryName = updateCategory.CategoryName;
            c.Description = updateCategory.Description;
            _db.SaveChanges();
            return ListCategories();
        }

        [HttpDelete]
        public List<CategoryResponseModel> DeleteCategory(int id)
        {
          
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return ListCategories();
        }


    }
}
