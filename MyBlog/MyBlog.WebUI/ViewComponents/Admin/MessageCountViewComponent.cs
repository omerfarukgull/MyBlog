using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.ViewComponents.Admin
{
    public class MessageCountViewComponent : ViewComponent
    {
        private IMessagesService _MessagesService;
        public MessageCountViewComponent(IMessagesService MessagesService)
        {
            _MessagesService = MessagesService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _MessagesService.GetAll();
            return View(values);
        }
    }
}
