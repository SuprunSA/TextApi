using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static TextApi.FileWorker;

namespace TextApi.Controllers
{
    [Route("api/TextController/")]
    [ApiController]
    public class TextController : ControllerBase
    {
        [HttpGet("get")]
        public string Get()
        {
            return GetAllText();
        }

        [HttpGet("get/{row}")]
        public ActionResult GetSelectedRow(int row)
        {
            if (row > GetLen())
            {
                return NotFound("Введённое число превышает количество строк в файле");
            }
            else
            {
                return Ok(GetRow(row));
            }
        }

        [HttpGet("getRange")]
        public ActionResult GetRange(int first, int last)
        {
            return Ok(FileWorker.GetRange(first, last));
        }


        [HttpPost("post")]
        public ActionResult Post(string stringToPost, string force)
        {
            if (!string.IsNullOrEmpty(force) && CheckContains(stringToPost))
            {
                return StatusCode(422, "такая сторка уже существует");
            }
            else
            { 
                PostRow(stringToPost);
                return Ok();
            }
        }

        [HttpDelete("delete/{row}")]
        public ActionResult DeleteSelectedRow(int row)
        {
            if (row > GetLen())
            {
                return NotFound("Введённое число превышает количество строк в файле");
            }
            else
            {
                DeleteRow(row);
                return Ok();
            }
        }

        [HttpPut("put/{row}")]
        public ActionResult ChangeSelectedRow(int row, string newStr)
        {
            if (row > GetLen())
            {
                return NotFound("Введённое число превышает количество строк в файле");
            }
            else
            {
                PutRow(row, newStr);
                return Ok();
            }
        }
    }
}
