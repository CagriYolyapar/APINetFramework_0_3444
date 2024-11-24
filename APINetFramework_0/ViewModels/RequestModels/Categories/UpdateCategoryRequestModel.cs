using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APINetFramework_0.ViewModels.RequestModels.Categories
{
    public class UpdateCategoryRequestModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

    }
}