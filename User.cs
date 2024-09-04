using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_003_30_08_2024
{
    internal class User
    {
        public int UserId {  get; set; }
        [Required]
        [StringLength(20,MinimumLength =5)]
        public string UserLogin { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        [Required]
        public string PasswordHash { get; set; }

    }
}
