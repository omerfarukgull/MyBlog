using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class AuthorViewComponent : ViewComponent
    {
        private IAuthorService _authorService;
        public AuthorViewComponent(IAuthorService authorService)
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
