using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class BlogIsapprovCountViewComponent : ViewComponent
    {
        private IBlogService _blogService;
        public BlogIsapprovCountViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetByIsApprovedFalse();
            return View(values);
        }
    }
}
