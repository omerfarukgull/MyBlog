using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Index
{
    public class FooterTagViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public FooterTagViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["category"] != null)
                ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_categoryService.GetAll().Take(6));
        }
    }
}
