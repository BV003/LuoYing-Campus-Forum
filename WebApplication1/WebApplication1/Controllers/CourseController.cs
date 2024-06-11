using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softs
{
    [ApiController]
    [Route("api/course")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService courseService;

        public CourseController(CourseService courseService)
        {
            this.courseService = courseService;
        }

        // GET: api/course
        [HttpGet]
        public ActionResult<List<Course>> GetCourses()
        {
            return courseService.GetAllCourses();
        }

        // POST: api/course/add
        [HttpPost("add")]
        public ActionResult<string> AddCourse(string courseName, string description,int courseId,string instructor,string location,DateTime starttime,DateTime endtime,int timetableid )
        {
            Course course = new Course { CourseName = courseName, Description = description, CourseId = courseId,Instructor = instructor,Location = location,StartTime = starttime,EndTime = endtime,TimetableId = timetableid};
            if (courseService.AddCourse(course))
            {
                return Ok("课程添加成功");
            }
            else
            {
                return BadRequest("课程添加失败");
            }
        }

        // DELETE: api/course/remove
        [HttpDelete("remove")]
        public ActionResult<string> RemoveCourse(int courseId)
        {
            courseService.RemoveCourse(courseId);
            return Ok("课程删除成功");
        }

        // GET: api/course/get_info
        [HttpGet("get_info")]
        public ActionResult<Course> GetCourse(int courseId)
        {
            var course = courseService.GetCourse(courseId);
            if (course != null)
            {
                return Ok(course);
            }
            else
            {
                return NotFound("未找到课程");
            }
        }
    }
}

