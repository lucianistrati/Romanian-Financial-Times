using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RomanianFinancialTimes.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public String Title { get; set; }
        
        [Required]
        public String Content { get; set; }
        
        [Required]
        public String Timestamp { get; set;}
        
        [Required]
        public int WriterId { get; set; }
        
        
        [ForeignKey("WriterId")]
        public Writer Writer { get; set; }
        
        public virtual ICollection<Article> Articles { get; set; }
    }
}