using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemWorkstationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        //
        [HttpPut]
        public async Task<IActionResult> ConvertFileToByte([FromForm] MyDto dto)
        {
            /*
           *  // in DB(model class) file datatype is byte[]
           */
            List<string> fileType = new List<string> { ".jpeg",".png",".xlsx"};
            long maxFileSize = 1048576; //1MB
            if (!fileType.Contains(Path.GetExtension(dto.MyFile.FileName).ToLower()))
            {
                return BadRequest(error: "jpg,png, xlsx are allow");
            }
            if (dto.MyFile.Length>maxFileSize)
            {
                return BadRequest(error: "file size is too big");
            }
            byte[] myBytes;
            using var dataStream = new MemoryStream();
            await dto.MyFile.CopyToAsync(dataStream);
            myBytes = dataStream.ToArray();
            return Ok(myBytes);
        }
        public SystemWorkstationsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Add(SystemWorkstationDto model)
        {
            var sysws = new SystemWorkstation { CCPXIsn = model.CCPXIsn };
            await _context.SystemWorkstations.AddAsync(sysws);
            _context.SaveChanges();
            return Ok(model);
        }
    }
}
