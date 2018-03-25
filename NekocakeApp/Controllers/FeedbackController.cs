using Microsoft.AspNetCore.Mvc;
using NekocakeApp.Models;

namespace NekocakeApp.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedBackRepository _feedBackRepository;

        public FeedbackController(IFeedBackRepository repository)
        {
            _feedBackRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _feedBackRepository.AddFeedback(feedback);
                return Redirect("FeedbackComplete");
            }
            return View(feedback);
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}