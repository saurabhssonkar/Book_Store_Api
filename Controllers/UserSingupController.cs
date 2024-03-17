// using BookStore.Models;
// using BookStore.Models.DTO;
// using BookStore.Models.Repository;
// using Microsoft.AspNetCore.Mvc;

// namespace BookStore.Controllers{
//     [Route("api/singup")]
//     [ApiController]

//     public class Authentication:ControllerBase
//     {
//       private readonly IDataRepository<User, UserDTO> _dataRepository;
//       public Authentication(IDataRepository<User,UserDTO> _dataRepository){
//         _dataRepository = _dataRepository;
//       }

//       [HttpPost]
//       public IActionResult Post([FromBody] User user){
//         if(user==null){
//             return BadRequest();
//         }
//         if(!ModelState.IsValid){
//           return BadRequest();
//         }

        
//       }

        
//     }
// }