using AutoMapper;
using ECA.API.Services;

namespace ECA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerUsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        //private readonly ApplicationDbContext _context;
        private readonly IComputerUserService _userService;


        public ComputerUsersController(/*ApplicationDbContext context*/IMapper mapper,IComputerUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            //var users = await _userService.GetUsers();
            var users = await _userService.GetUsers(userId: 31070);
            var mm= _mapper.Map<IEnumerable<ComputerUserDto>>(users);
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ComputerUserDto model)
        {
            var user = new ComputerUser { CDLRIsn = model.CDLRIsn };
            await _userService.Add(user);
            //_context.ComputerUsers.AddAsync(user);
            //_context.SaveChanges();
            return Ok(user);
        }
        [HttpPut(template:"{id}")]
        public async Task<IActionResult> Update(decimal id, [FromBody] ComputerUserDto model)
        {
            var user = await _userService.GetById(id);
            user = _userService.Update(user);//_context.ComputerUsers.SingleOrDefaultAsync(q=>q.UserId == id);    
            if(user == null) return NotFound(value:$"ComputerUser wasn't found with ID:{id}");
            user.name= model.name; 
            //_context.SaveChanges();
            return Ok(user);
        }
        [HttpDelete(template: "{id}")]
        public async Task<IActionResult> Delete(decimal id)
        {
            var user = await _userService.GetById(id);//_context.ComputerUsers.SingleOrDefaultAsync(q => q.UserId == id);
            if (user == null) return NotFound(value: $"ComputerUser wasn't found with ID:{id}");
            _userService.Delete(user);
            //_context.Remove(user);
            //_context.SaveChanges();
            return Ok(user);
        }
    }
}
