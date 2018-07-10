using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardFinal.Data//.Metadata
{
    public class UserDetailMetadata
    {
        [Required]
        [Display(Name = "User ID")]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(75,ErrorMessage ="Must be 50 characters or less")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(75, ErrorMessage = "Must be 75 characters or less")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Resume File")]
        public string ResumeFilename { get; set; }

    }
    [MetadataType(typeof(UserDetailMetadata))]
    public partial class UserDetail { }
}
