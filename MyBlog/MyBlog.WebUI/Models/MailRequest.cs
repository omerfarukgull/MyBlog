using MyBlog.Entities.Concrete;

namespace MyBlogWebUI.Models
{
    public class MailRequest
    {
        public string Name { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }


        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool? MessageStatus { get; set; }

    }
}
