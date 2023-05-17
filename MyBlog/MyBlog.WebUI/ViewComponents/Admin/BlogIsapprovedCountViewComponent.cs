using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class BlogIsapprovedCountViewComponent : ViewComponent
    {
        private IBlogService _blogService;
        public BlogIsapprovedCountViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetByIsApprovedTrue();
            return View(values);
        }
    }
}
