using System.ComponentModel.DataAnnotations;

namespace AppEstagioKnewin.Models
{
    public class UsuarioPresentationModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3,
           ErrorMessage = "Please met the requirement (3 - 50 characters)")]
        [Display(Name = "User Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3,
          ErrorMessage = "Please met the requirement (3 - 100 characters)")]
        [Display(Name = "User Email")]
        public string EmailAddress { get; set; }
    }
}
