using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Index
{
    public class CommentListViewComponent : ViewComponent
    {
        private ICommentService _commentService;
        public CommentListViewComponent(ICommentService commentService)
        {
                _commentService= commentService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var model = _commentService.GetAll().Where(c=>c.BlogId==id);
            return View(model); 
        }
    }
}
