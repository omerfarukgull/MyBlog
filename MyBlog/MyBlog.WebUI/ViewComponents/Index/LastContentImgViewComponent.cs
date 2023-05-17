using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Index
{
    public class LastContentImgViewComponent:ViewComponent
    {
        private IBlogService _blogService;

        public LastContentImgViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _blogService.GetAll().OrderByDescending(x => x.Id).Take(9).Where(x=>x.IsApproved==true);
            return View(model);
        }
    }
}
