using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Categories.Queries.GetCategoryList
{
    public class CategoryListVm
    {
        public List<CategoryDto> Categories { get; set; } = new();
    }
}
