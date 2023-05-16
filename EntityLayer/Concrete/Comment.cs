using EntityLayer.Entityies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }
        public bool Status { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
