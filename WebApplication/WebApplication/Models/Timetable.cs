using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    class Timetable
    {
        public int TimetableId { get; set; }
        public string UserId { get; set; } // 关联用户ID
        public List<Course> Courses { get; set; } // 课程列表

        public Timetable(int timetableId, string userId, List<Course> courses)
        {
            TimetableId = timetableId;
            UserId = userId;
            Courses = courses;
        }

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }

        public bool RemoveCourse(int courseId)
        {
            var courseToRemove = Courses.Find(c => c.CourseId == courseId);
            if (courseToRemove != null)
            {
                Courses.Remove(courseToRemove);
                return true;
            }
            return false;
        }

        public void SetReminder(int courseId, string reminder)
        {
            var course = Courses.Find(c => c.CourseId == courseId);
            if (course != null)
            {
                course.Reminders.Add(reminder);
            }
        }

        public void CancelReminder(int courseId, string reminder)
        {
            var course = Courses.Find(c => c.CourseId == courseId);
            if (course != null)
            {
                course.Reminders.Remove(reminder);
            }
        }
    }
}
