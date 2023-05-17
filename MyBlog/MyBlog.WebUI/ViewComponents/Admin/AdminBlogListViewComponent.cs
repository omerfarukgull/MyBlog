using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class AdminBlogListViewComponent:ViewComponent
    {
        private IBlogService _blogService;
        public AdminBlogListViewComponent(IBlogService blogService)
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
