using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class BlogCountViewComponent : ViewComponent
    {
        private IBlogService _blogService;
        public BlogCountViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetAll();
            return View(values);
        }
    }
}
