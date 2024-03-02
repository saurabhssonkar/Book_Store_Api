﻿using BookStore.Models;
using BookStore.Models.DTO;
using BookStore.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IDataRepository<Book, BookDto> _dataRepository;

        public BooksController(IDataRepository<Book, BookDto> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _dataRepository.Get(id);
            if (book == null)
            {
                return NotFound("Book not found.");
            }

            return Ok(book);
        }
    }
}