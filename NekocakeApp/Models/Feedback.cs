using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace NekocakeApp.Models
{
    public class Feedback
    {
        [BindNever]
        public int FeedbackId { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="Your name is required")]
        public string Name { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="Your email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Your message is required")]
        public string Message { get; set; }
        public bool ContactMe { get; set; }
    }
}
