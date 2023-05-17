using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Index
{
    public class LastContentViewComponent:ViewComponent
    {
        private IBlogService _blogService;

        public LastContentViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _blogService.GetAll().OrderByDescending(x => x.Id).Take(4).Where(x=>x.IsApproved==true);
            return View(model);
        }
    }
}
