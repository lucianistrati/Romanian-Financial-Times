using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace RomanianFinancialTimes.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public String Content { get; set; }

        [Required]
        public String Timestamp { get; set;}
        
        [Required]
        public int ArticleId { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; }
    }
}