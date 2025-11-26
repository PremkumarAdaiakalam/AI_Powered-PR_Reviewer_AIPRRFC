using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace DemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static string _cachedUser;
        [HttpGet("{id}")]
        public async Task<string> GetUser(int id)
        {
            // :x: BAD: blocking call instead of awaiting
            var data = Task.Delay(1000).Result;
            // :x: BAD: no validation
            if (id == 0)
                return null;
            // :x: BAD: static mutable state (thread safety)
            _cachedUser = $"User_{id}";
            return _cachedUser;
        }
    }
}