using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    class CourseService
    {
        private List<Course> _courses = new List<Course>();

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course), "Cannot add a null course.");
            }

            _courses.Add(course);
            Console.WriteLine($"Course {course.CourseName} added successfully.");
        }

        public bool RemoveCourse(int courseId)
        {
            var courseToRemove = _courses.FirstOrDefault(c => c.CourseId == courseId);
            if (courseToRemove == null)
            {
                Console.WriteLine("Course not found.");
                return false;
            }

            _courses.Remove(courseToRemove);
            Console.WriteLine($"Course with ID {courseId} removed successfully.");
            return true;
        }

        public Course FindCourseById(int courseId)
        {
            return _courses.FirstOrDefault(c => c.CourseId == courseId);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courses;
        }
    }
}
