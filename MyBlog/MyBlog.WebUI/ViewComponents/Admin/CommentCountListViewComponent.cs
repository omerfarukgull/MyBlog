using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class CommentCountListViewComponent : ViewComponent
    {
        private ICommentService _commentService;
        public CommentCountListViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _commentService.GetAll();
            return View(values);
        }
    }

}
