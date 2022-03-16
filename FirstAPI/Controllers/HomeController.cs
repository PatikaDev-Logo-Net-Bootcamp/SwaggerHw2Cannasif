using FirstAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/register")]
        public IActionResult Register()
        {
            return Ok("Success");
        }

        [HttpPost]
        [Route("/loginForm")]
        public IActionResult UserLoginPost([FromForm] UserModel model)
        {
            var user = new UserModel
            {
                UserName = model.UserName,
                Password = model.Password
            };
            return Ok(user);
        }

        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Delete()
        {
            return Json(new {success=true ,data="Success" });
        }
      
    }
}
