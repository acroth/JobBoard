using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardFinal.Data//.Metadata
{
    public class PositionMetadata
    {
        [Required]
        [Display(Name = "Position ID")]
        public int PositionID { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        [StringLength(50,ErrorMessage ="Must be 50 characters or less")]
        [Display(Name = "Job Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter a value")]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Pay { get; set; }

    }
    [MetadataType(typeof(PositionMetadata))]
    public partial class Position { }
}
