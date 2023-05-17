using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class CategoryCountViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryCountViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var entity = _categoryService.GetAll();
            return View(entity);
        }
    }
}
