﻿using System.Collections.Generic;

namespace BookStore.Models.DTO
{
    public class BookDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        
        public PublisherDto Publisher { get; set; }
        public ICollection<AuthorDto> Authors { get; set; }
    }
}
