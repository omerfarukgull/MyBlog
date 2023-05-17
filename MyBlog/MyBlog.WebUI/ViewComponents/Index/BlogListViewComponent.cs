using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Index
{
    public class BlogListViewComponent : ViewComponent
    {
        private IBlogService _blogService;

        public BlogListViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _blogService.GetAll().Where(i=>i.IsApproved==true);
            return View(model);
        }
    }
}
