using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardFinal.Data//.Metadata
{
    public class LocationMetadata
    {
        [Required]
        [Display(Name ="Location ID")]       
        public int LocationID { get; set; }
        [Required(ErrorMessage ="Please enter a city")]
        [StringLength(20, ErrorMessage ="Must be 20 characters or less")]        
        public string City { get; set; }
        [Required(ErrorMessage ="Please enter a state")]
        [StringLength(2,ErrorMessage ="Must be 2 characters or less")]
        public string State { get; set; }
        [Display(Name = "Manager ID")]
        [Required]
        public string ManagerID { get; set; }
        [Required]
        [Display(Name = "Store Number")]
        public string StoreNumber { get; set; }
    }
    [MetadataType(typeof(LocationMetadata))]
    public partial class Location { }
}
