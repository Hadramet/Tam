using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tam.webapp.Models
{
    public class User
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public ICollection<UserPlayList> UserPlayLists { get; set; }
        public DateTime AdditionDate { get; set; }

    }
}
