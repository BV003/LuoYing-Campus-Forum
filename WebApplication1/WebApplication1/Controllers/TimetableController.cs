using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using softs;

namespace softs
{
    [ApiController]
    [Route("api/timetable")]
    public class TimetableController : ControllerBase
    {
        private readonly TimetableService timetableService;

        public TimetableController(TimetableService timetableService)
        {
            this.timetableService = timetableService;
        }

        // GET: api/timetable
        [HttpGet]
        public ActionResult<List<Timetable>> GetTimetables()
        {
            var timetables = timetableService.GetAllTimetables();
            return Ok(timetables);
        }

        // POST: api/timetable/add


        public class AddTimetableRequest
        {
            public int TimetableId { get; set; }
            public int UserId { get; set; }
            public List<Course> Courses { get; set; }
        }

        [HttpPost("add")]
        public ActionResult<string> AddTimetable([FromBody] AddTimetableRequest request)
        {
            Timetable timetable = new Timetable
            {
                TimetableId = request.TimetableId,
                UserId = request.UserId,
                Courses = request.Courses
            };

            if (timetableService.AddTimetable(timetable))
            {
                return Ok("时间表添加成功");
            }
            else
            {
                return BadRequest("时间表添加失败");
            }
        }



        // DELETE: api/timetable/remove
        [HttpDelete("remove")]
        public ActionResult<string> RemoveTimetable(int timetableid)
        {
            if (timetableService.RemoveTimetable(timetableid))
            {
                return Ok("时间表删除成功");
            }
            else
            {
                return NotFound("未找到时间表");
            }
        }

        // GET: api/timetable/get_info
        [HttpGet("get_info")]
        public ActionResult<Timetable> GetTimetable(int userId)
        {
            var timetable = timetableService.FindTimetableByUserId(userId);
            if (timetable != null)
            {
                return Ok(timetable);
            }
            else
            {
                return NotFound("未找到时间表");
            }
        }


    }
        
}

