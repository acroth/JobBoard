using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobBoardFinal.UI.Models
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = "* Please provide your name.")]
        [StringLength(25, ErrorMessage = "* Max length for name is 25 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* Please provide your email.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "* Max length for email address is 50 characters")]
        public string Email { get; set; }
        [Required(ErrorMessage = "* Please provide a message.")]
        [StringLength(4000, ErrorMessage = "* Max length for message is 4000 characters")]
        [UIHint("MultilineText")]
        public string Message { get; set; }
        [StringLength(50, ErrorMessage = "* Max length for the subject is 50 characters")]
        public string Subject { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime TimeStamp { get; set; }

    }
}