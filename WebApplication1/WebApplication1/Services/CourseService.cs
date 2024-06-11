using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using softs;
using softs;

namespace softs
{
    public class CourseService
    {
        UserDbContext dbContext;
        /*private List<Course> _courses = new List<Course>();*/
        public CourseService(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Course> GetAllCourses()
        {
            return dbContext.Courses
                .ToList<Course>();
        }
        public bool AddCourse(Course course)
        {
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
            return true;
        }

        public void RemoveCourse(int courseId)
        {
            var course = dbContext.Courses
                .SingleOrDefault(o => o.CourseId == courseId);
            if (course == null) return;
            dbContext.Courses.Remove(course);
            dbContext.SaveChanges();
        }

        public Course GetCourse(int courseId)
        {
            return dbContext.Courses
                .SingleOrDefault(o => o.CourseId == courseId);
        }

        
    }
}
