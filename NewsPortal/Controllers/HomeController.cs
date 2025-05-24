using Microsoft.AspNetCore.Mvc;
using NewsPortal.Services;
using NewsPortal.Data;
using NewsPortal.Models;
using System.Threading.Tasks;
using System.Linq;

namespace NewsPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsService _newsService;
        private readonly NewsPortalContext _context;

        public HomeController(NewsService newsService, NewsPortalContext context)
        {
            _newsService = newsService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _newsService.GetPostsAsync();
            return View(posts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var post = await _newsService.GetPostAsync(id);
            var user = await _newsService.GetUserAsync(post.UserId);
            var comments = await _newsService.GetCommentsByPostIdAsync(id);
            var feedback = _context.Feedbacks.FirstOrDefault(f => f.PostId == id);

            ViewBag.User = user;
            ViewBag.Comments = comments;
            ViewBag.Feedback = feedback;
            return View(post);
        }
    }
}