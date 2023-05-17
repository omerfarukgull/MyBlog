using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Index
{
    public class TrendListViewComponent : ViewComponent
    {
        private IBlogService _blogService;

        public TrendListViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var model =_blogService.GetAll().OrderByDescending(i=>i.Puan).Take(5).Where(i=>i.IsApproved==true);
            return View(model);
        }
    }
}
