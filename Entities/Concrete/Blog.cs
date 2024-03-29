﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Blog : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ThumbnailImage { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

        // Relationship
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        // for comment
        public List<Comment> Comments { get; set; }
        // for Writer
        public int? WriterID { get; set; } 
		public Writer Writer { get; set; }
	}
}
