using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
      
        public long Id { get; set; }
        [Required (ErrorMessage = "The Name Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email Is Required")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
