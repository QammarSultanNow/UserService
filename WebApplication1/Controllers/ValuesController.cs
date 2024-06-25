using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using WebApplication1.Interface;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
       
        public ValuesController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetInformation()
        {

          var result =  await _userService.GetUserInformation();

            foreach(var item in result)
            {
             var res =  await _userService.DownloadAvatar(item.avatar);
                
              await _userRepository.AddUserData(item , res);
            }

            return Ok(result);
        }


        //[HttpPost]
        //public async Task<IActionResult> AddUser(User user)
        //{
        // var result = await  _userRepository.AddUserData(user);
        // return Ok(result);  
        //}



    }
}
