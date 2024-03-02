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
        private readonly IDataRepository<Author, AuthorDto ,Author_CustomModel> _dataRepository;

        public AuthorsController(IDataRepository<Author, AuthorDto,Author_CustomModel> dataRepository)
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
        // 
        public IActionResult Put(int id,[FromBody] Author_CustomModel author)
        {
            // int id = 5;
            // Author_CustomModel author = new Author_CustomModel();
            // author.id = 5;
            // author.Name = "Saurabh@1234";
            // author.AuthorContact = new AuthorContact
            // {
            //     AuthorId = 5,
            //     ContactNumber = "9076578103",
            //     Address = "Jainagar Post Gaura Jainagar Deoria"
            // };

            // author.BookAuthors = new List<BookAuthor>
            // {
            //     new BookAuthor
            //     {
            //         AuthorId = 5,
            //         BookId = 5
            //     },
            //     new BookAuthor
            //     {
            //         AuthorId = 6,
            //         BookId = 5
            //     }
            // };

            if (author == null)
            {
                return BadRequest("Author is null.");
            }

            var  authorToUpdate = _dataRepository.Get(id);
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