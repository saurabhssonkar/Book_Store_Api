using BookStore.Models;
using BookStore.Models.DTO;
using BookStore.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IDataRepository<Author, AuthorDto> _dataRepository;

        public AuthorsController(IDataRepository<Author, AuthorDto> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Authors
        [HttpGet]
        public IActionResult Get()
        {
            var authors = _dataRepository.GetAll();
            return Ok(authors);
        }

        // GET: api/Authors/5
        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult Get(int id)
        {
            var author = _dataRepository.GetDto(id);
            if (author == null)
            {
                return NotFound("Author not found.");
            }

            return Ok(author);
        }

        // POST: api/Authors
        [HttpPost]
        // public IActionResult Post([FromBody] Author author)
        public IActionResult Post([FromBody] Author author)

        {
            //    Author author=new Author();
            //    author.Name = "Sonu";
            //    author.AuthorContact=new AuthorContact {
            //     ContactNumber = "123456788",
            //     Address="Barhaj Deoria",
            //    };


            if (author is null)
            {
                return BadRequest("Author is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(author);
            // return CreatedAtRoute("GetAuthor", new { Id = author.Id }, null);
            return Ok(author);
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        //   public IActionResult Put(int id, [FromBody] Author author)
        // [FromBody] Author_CustomModel author
        // int id,[FromBody] Author_CustomModel author
        // 
        public IActionResult Put( )
        {
                // Console.WriteLine($"Author Id: {author}");
                // Console.WriteLine($"Author Id: {id}");

            int id = 6;
            Author author = new Author();
            author.Id = 6;
            author.Name = "Testing Change Author Name";
            author.AuthorContact = new BookStore.Models.AuthorContact
            {
                AuthorId = 6,
                ContactNumber = "0000000",
                Address = "Noida Sector 62"
            };

            author.BookAuthors = new List<BookAuthors>
            {
                new BookAuthors
                {
                    AuthorId = 4,
                    BookId = 4
                },
                new BookAuthors
                {
                    AuthorId = 3,
                    BookId = 4
                }
            };


            if (author == null)
            {
                return BadRequest("Author is null.");
            }

            var authorToUpdate = _dataRepository.Get(id);
            if (authorToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(authorToUpdate, author);
            return NoContent();
        }
    }
}