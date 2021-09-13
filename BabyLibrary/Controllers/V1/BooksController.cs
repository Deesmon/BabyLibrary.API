using AutoMapper;
using BabyLibrary.Contracts.V1;
using BabyLibrary.Contracts.V1.Requests;
using BabyLibrary.Contracts.V1.Responses;
using BabyLibrary.Domain.DTO;
using BabyLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BabyLibrary.Controllers.V1
{
    [ApiController]
    public class BooksController : Controller
    {
        private IBookService _bookService;
        private IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Books.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            var books = await _bookService.GetBooksAsync();

            var response = _mapper.Map<List<GetBookResponse>>(books);

            return Ok(response);
        }

        [HttpGet(ApiRoutes.Books.Get)]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "bookId")]Guid bookId)
        {
            var book = await _bookService.GetBookByIdAsync(bookId);

            if (book is null)
                return NotFound();

            var response = _mapper.Map(book, new GetBookResponse());

            return Ok(response);
        }

        [HttpPost(ApiRoutes.Books.Create)]
        public async Task<IActionResult> CreateAsync([FromBody]CreateBookRequest createBookModel)
        {
            var newBook = _mapper.Map(createBookModel, new Book());

            var createdBook = await _bookService.CreateBookAsync(newBook);

            var response = _mapper.Map(createdBook, new CreateBookResponse());

            //Refactor this so it can be reused
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Books.Get.Replace("{bookId}", newBook.Id.ToString());

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoutes.Books.Update)]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "bookId")]Guid bookId, [FromBody]UpdateBookRequest updateBookRequest)
        {
            var oldBook = await _bookService.GetBookByIdAsync(bookId);

            if (oldBook is null)
                return NotFound();

            oldBook = _mapper.Map(updateBookRequest, oldBook);

            var updatedBook = await _bookService.UpdateBookAsync(oldBook);

            return Ok(updatedBook);
        }

        [HttpDelete(ApiRoutes.Books.Delete)]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "bookId")]Guid bookId)
        {
            var response = await _bookService.DeleteBookAsync(bookId);

            if (response)
                return NoContent();

            return NotFound();
        }
    }
}
