// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AuthorContact
    {
        public int AuthorId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }

    public class BookAuthor
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
    }

    public class Author_CustomModel
    {
        public int id { get; set; }
    // public long Id { get; internal set; }
    public string Name { get; set; }
        public AuthorContact AuthorContact { get; set; } // Specify the full namespace
        public List<BookAuthor> BookAuthors { get; set; }
    }

