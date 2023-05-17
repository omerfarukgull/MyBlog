using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.Entities.Concrete;
using MyBlog.WebUI.Models;
using MyBlogWebUI.Models;

namespace MyBlog.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IBlogService _blogService;
        private IMessagesService _messagesService;
        private ICommentService _commentService;

        public HomeController(IBlogService blogService, IMessagesService messagesService, ICommentService commentService)
        {
            _blogService = blogService;
            _messagesService = messagesService;
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            var blogListViewModel = new BlogListViewModel
            {
                Blogs = _blogService.GetByIsApprovedTrue()
            };
            return View(blogListViewModel);
        }

        public IActionResult BlogList(string category)
        {
            var blogListViewModel = new BlogListViewModel
            {
                Blogs = _blogService.GetBlogByCategory(category)
            };
            return View(blogListViewModel);
        }

        [HttpGet]
        public IActionResult BlogDetails(string url)
        {
            if (url == null)
            {
                return NotFound();
            }
            Blog blog = _blogService.GetBlogDetails(url);
            if (blog == null)
            {
                return NotFound();
            }
            return View(new BlogDetailModel
            {
                Blog = blog,
                Categories = blog.BlogCategories.Select(c => c.Category).ToList(),
            });
        }
        [HttpPost]
        public IActionResult BlogDetails(BlogDetailModel model)
        {
            Comment comment = new Comment 
            {
                UserName=model.Comment.UserName,
                Mail= model.Comment.Mail,
                Yorum=model.Comment.Yorum,
                BlogId=model.Comment.BlogId,
            };
            _commentService.Add(comment);
            return RedirectToAction("BlogDetails");
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(MessagesModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Messages()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Message = model.Message,
                    Title = model.Title
                };
                _messagesService.Add(entity);
                return View(model);
            }
            return RedirectToAction("Contact");
        }
    }
}
