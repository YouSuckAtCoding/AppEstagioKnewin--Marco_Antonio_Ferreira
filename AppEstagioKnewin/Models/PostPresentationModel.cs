using System.ComponentModel.DataAnnotations;

namespace AppEstagioKnewin.Models
{
    public class PostPresentationModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3,
            ErrorMessage ="Please met the requirement (3 - 50 characters)")]
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3,
            ErrorMessage = "Please met the requirement (3 - 200 characters)")]
        public string Content { get; set; }
    }
}
