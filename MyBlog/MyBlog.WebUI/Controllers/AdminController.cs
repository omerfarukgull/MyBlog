using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using MimeKit;
using MyBlog.Business.Abstract;
using MyBlog.Entities.Concrete;
using MyBlogWebUI.Models;
using X.PagedList;

namespace MyBlog.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;
        private ICommentService _commentService;
        private IMessagesService _messagesService;
        private IAuthorService _authorService;

        public AdminController(IBlogService blogService, ICategoryService categoryService, ICommentService commentService, IMessagesService messagesService, IAuthorService authorService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _commentService = commentService;
            _messagesService = messagesService;
            _authorService = authorService;
        }
        [Route("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        #region Blog İşlemleri

        public IActionResult BlogList(int page = 1)
        {
            var entity = _blogService.GetAll().ToPagedList(page, 10);
            return View(entity);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {

            var authors = _authorService.GetAll();
            List<SelectListItem> authorValues = (from x in authors
                                                 select new SelectListItem
                                                 {
                                                     Text = x.AuthorName,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.au = authorValues;

            var categories = new BlogModel()
            {
                selectedCategories = _categoryService.GetAll(),
            };
            return View(categories);
        }
        [HttpPost]
        public async Task<IActionResult> BlogAdd(BlogModel blog, int[] categoryIds, IFormFile file)
        {
            if (blog != null)
            {
                var etity = new Blog()
                {
                    Title = blog.Title,
                    Url = blog.Url,
                    Description = blog.Description,
                    Content = blog.Content,
                    Puan = blog.Puan,
                    CreateDate = blog.CreateDate,
                    AuthorId = blog.AuthorId,
                    IsApproved = blog.Isapproved,
                    ImgUrl = file.FileName,


                };
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                _blogService.BlogAdd(etity, categoryIds);
                return RedirectToAction("BlogList");
            }
            return View(blog);
        }
        [HttpGet]
        public IActionResult BlogEdit(int? id)
        {
            var authors = _authorService.GetAll();
            List<SelectListItem> authorValues = (from x in authors
                                                 select new SelectListItem
                                                 {
                                                     Text = x.AuthorName,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.au = authorValues;

            var entity = _blogService.GetByIdWithCategories((int)id);
            var model = new BlogModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Url = entity.Url,
                Description = entity.Description,
                Content = entity.Content,
                ImgUrl = entity.ImgUrl,
                Puan = entity.Puan,
                CreateDate = entity.CreateDate,
                AuthorId = entity.AuthorId,
                Isapproved = entity.IsApproved,
                selectedCategories = entity.BlogCategories.Select(i => i.Category).ToList(),
            };
            ViewBag.Categories = _categoryService.GetAll();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> BlogEdit(BlogModel blog, int[] categoryIds, IFormFile file)
        {

            var entity = _blogService.GetById(blog.Id);
            if (entity == null)
            {
                return NotFound();
            }
            else if (entity != null && file != null)
            {
                entity.Title = blog.Title;
                entity.Url = blog.Url;
                entity.Description = blog.Description;
                entity.Content = blog.Content;
                entity.ImgUrl = file.FileName;
                entity.Puan = blog.Puan;
                entity.CreateDate = blog.CreateDate;
                entity.AuthorId = blog.AuthorId;
                entity.IsApproved = blog.Isapproved;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                _blogService.BloggUpdate(entity, categoryIds);
                return RedirectToAction("BlogList");
            }
            else if (entity != null)
            {
                entity.Title = blog.Title;
                entity.Url = blog.Url;
                entity.Description = blog.Description;
                entity.Content = blog.Content;
                entity.ImgUrl = blog.ImgUrl;
                entity.Puan = blog.Puan;
                entity.CreateDate = blog.CreateDate;
                entity.AuthorId = blog.AuthorId;
                entity.IsApproved = blog.Isapproved;
                _blogService.BloggUpdate(entity, categoryIds);
                return RedirectToAction("BlogList");
            }
            ViewBag.Categories = _categoryService.GetAll();

            return View(blog);
        }
        #endregion

        #region Kategori işlemleri
        public IActionResult CatList()
        {
            var category = _categoryService.GetAll();
            return View(category);
        }
        [HttpGet]
        public IActionResult CatAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CatAdd(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category()
                {
                    CategoryName = model.CategoryName,
                    Url = model.Url,
                };
                _categoryService.Add(entity);
                return RedirectToAction("CatList");
            }
            return View(model);


        }

        [HttpGet]
        public IActionResult CatEdit(int id)
        {
            var entity = _categoryService.GetByIdWithBlog(id);

            var model = new CategoryModel()
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName,
                Url = entity.Url,
                Blogs = entity.BlogCategories.Select(b => b.Blog).ToList(),
            };
            return View(model);

        }
        [HttpPost]
        public IActionResult CatEdit(CategoryModel model)
        {

            var entity = _categoryService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.CategoryName = model.CategoryName;
            entity.Url = model.Url;

            _categoryService.Update(entity);

            return RedirectToAction("CatList");

        }
        [HttpPost]
        public IActionResult DeleteFromCategory(int blogId, int categoryId)
        {
            _categoryService.DeleteFromCategory(blogId, categoryId);
            return RedirectToAction("CatList");
        }
        #endregion

        #region Comment İşlemleri
        public IActionResult ComList()
        {
            var entity = _commentService.GetAll();
            return View(entity);
        }
        [HttpGet]
        public IActionResult ComEdit(int id)
        {
            var entity = _commentService.GetById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult ComEdit(Comment model)
        {
            var entity = _commentService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.UserName = model.UserName;
            entity.Mail = model.Mail;
            entity.Yorum = model.Yorum;

            _commentService.Update(entity);

            return RedirectToAction("ComList");

        }
        public IActionResult ComDel(int id)
        {
            var entity = _commentService.GetById(id);
            if (entity != null)
            {
                _commentService.Delete(entity);
            }

            return RedirectToAction("ComList");
        }
        #endregion

        #region Message İşlemleri
        public IActionResult MesList()
        {
            var entity = _messagesService.GetAll();
            return View(entity);
        }

        [HttpGet]
        public IActionResult MesSend(int id)
        {
            var entity = _messagesService.GetById(id);

            var model = new MailRequest()
            {
                Id = entity.Id,
                ReceiverEmail = entity.Email,
                Email = entity.Email,
                UserName = entity.Name,
                Title = entity.Title,
                Message = entity.Message,

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult MesSend(MailRequest mailrequest)
        {

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxaddressFrom = new MailboxAddress("Admin", "myblogtest10@gmail.com");
            mimeMessage.From.Add(mailboxaddressFrom); //kimden geldiği

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailrequest.ReceiverEmail); //Kime gidecek
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = mailrequest.Subject;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = mailrequest.Body
            };

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("myblogtest10@gmail.com", "uzvvbqmjvzvqynbx");
            client.Send(mimeMessage);
            client.Disconnect(true);

            _messagesService.MessageStatusUpdate(mailrequest.Id);

            return RedirectToAction("MesList");
        }
        #endregion

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
