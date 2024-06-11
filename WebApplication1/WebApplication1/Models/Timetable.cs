using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softs
{
    public class Timetable
    {
        public int UserId { get; set; } 
        
        public int TimetableId { get; set; }
        public List<Course> Courses { get; set; } // 课程列表
    }
}
