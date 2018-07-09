using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardFinal.Data//.Metadata
{
    public class ApplicationMetadata
    {
        [Required]
        [Display(Name = "Application Number")]      
        public int ApplicationID { get; set; }
        [Required]
        public int OpenPositionID { get; set; }
        [Required]
        [Display(Name = "User ID")]
        public int UserID { get; set; }
        [Required]
        [Display(Name = "Date Applied")]
        public System.DateTime ApplicationDate { get; set; }
        [Required]
        [Display(Name = "Declined?")]
        public bool IsDeclined { get; set; } 
        [Display(Name = "Resume")]       
        public string ResumeFilename { get; set; }
        [Display(Name = "Manager Notes")]
        [UIHint("MultilineText")]
        public string ManagerNotes { get; set; }

        public virtual OpenPosition OpenPosition { get; set; }

    }
    [MetadataType(typeof(ApplicationMetadata))]
    public partial class Application { }
}
