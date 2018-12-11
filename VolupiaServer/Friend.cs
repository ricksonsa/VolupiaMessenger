using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolupiaServer
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int FriendId { get; set; }

        [Required]
        public bool Accepted { get; set; }
    }
}
