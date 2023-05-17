using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class AdminNavbarViewComponent : ViewComponent
    {
        private IAuthorService _authorService;
        public AdminNavbarViewComponent(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public IViewComponentResult Invoke()
        {
            var entity = _authorService.GetAll().FirstOrDefault();
            return View(entity);
        }
    }
}
