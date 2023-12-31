using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace VGR_WebAPI.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]/")]
    public class VGRController : ControllerBase
    {
        private readonly ILogger<VGRController> _logger;
        private readonly DTO _dto;

        public VGRController(ILogger<VGRController> logger, DTO dto)
        {
            _logger = logger;
            _dto = dto;

        }

        [HttpGet("GetData")]
        public ActionResult Index()
        {
            System.IO.File.AppendAllText("D:\\Check.txt", "Test");
            string json = "";
            json = _dto.get_requests();

            return Ok(json);
        }

        [HttpGet("GetData/{id}")]
        public ActionResult GetDataFromId(int id)
        {
            string json = "";
            json = _dto.get_request_id(id);

            return Ok(json);

        }

        [HttpGet("GetRegister/{id}")]
        public ActionResult GetRegister(int id)
        {
            string json = "";
            json = _dto.get_register(id);

            return Ok(json);
        }

        [HttpGet("GetGoverment")]
        public ActionResult GetGoverment()
        {
            string json = "";
            json = _dto.get_goverment();

            return Ok(json);
        }

        [HttpGet("GetFileName/{id}")]
        public ActionResult GetFileName(int id)
        {
            string json = "";
            json = _dto.get_filename(id);

            return Ok(json);
        }

        [HttpGet("GetDataCollection/{id}")]
        public ActionResult GetDataCollection(int id)
        {
            string json = "";
            json = _dto.get_datacollection(id);

            return Ok(json);
        }

        [HttpGet("GetFile")]
        public ActionResult GetDataCollection([FromQuery] string filename, [FromQuery] string user_id)
        {

            Stream stream;
            stream = _dto.get_file(filename, Convert.ToInt16(user_id));

            return Ok(stream);
        }

        [HttpGet("GetNames")]
        public ActionResult GetNames()
        {
            string json = "";
            json = _dto.get_names();

            return Ok(json);
        }

        [HttpGet("GetmailTemplates")]
        public ActionResult GetmailTemplates()
        {
            string json = "";
            json = _dto.get_mail_templates();

            return Ok(json);
        }

        [HttpGet("GetProject/{id}")]
        public ActionResult GetProject(int id)
        {
            string json = "";
            json = _dto.get_project(id);

            return Ok(json);
        }

        [HttpPost("PostRequest")]
        [Produces("application/json")]
        [Consumes("multipart/form-data")]
        public ActionResult Post([FromForm] List_of_Data data)
        {
            _logger.LogInformation("Incoming FormData: {Data}", data);

            if (data != null)
            {
                _dto.insert(data);

                return Ok(data);
            }

            else
            {
                return BadRequest();
            }
        }

        [HttpPut("Renamefile/{user_id}")]
        public ActionResult Put(int user_id, [FromBody] RenameFileData data)
        {
            if (data.oldFilename != null && data.newFilename != null)
            {
                string oldFileName = data.oldFilename;
                string newFileName = data.newFilename;

                _dto.rename_file(data.oldFilename, data.newFilename, user_id);


            }
            return Ok();
        }


        [HttpPost("Post")]
        public ActionResult Action([FromForm] Data data)
        {
            return Ok(data);
        }
    }
}