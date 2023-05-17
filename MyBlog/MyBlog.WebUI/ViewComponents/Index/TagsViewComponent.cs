using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.Entities.Concrete;

namespace MyBlog.WebUI.ViewComponents.Index
{
    public class TagsViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public TagsViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["category"] != null)
            {
                ViewBag.SelectedCategory = RouteData?.Values["category"];
            }
            
            return View(_categoryService.GetAll());
        }
    }
}
