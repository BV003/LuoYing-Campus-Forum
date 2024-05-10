using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApplication.Models
{
    class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Instructor { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<string> DaysOfWeek { get; set; } 
        public string Location { get; set; }
        public string Description { get; set; }
        public List<string> Reminders { get; set; } 

        public Course(int courseId, string courseName, string instructor, DateTime startTime, DateTime endTime, List<string> daysOfWeek, string location, string description, List<string> reminders)
        {
            CourseId = courseId;
            CourseName = courseName;
            Instructor = instructor;
            StartTime = startTime;
            EndTime = endTime;
            DaysOfWeek = daysOfWeek;
            Location = location;
            Description = description;
            Reminders = reminders;
        }

        public override bool Equals(object obj)
        {
            if (obj is Course other)
            {
                return CourseId == other.CourseId;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return CourseId.GetHashCode();
        }

        public override string ToString()
        {
            return $"CourseId: {CourseId}, CourseName: {CourseName}, Instructor: {Instructor}, StartTime: {StartTime}, EndTime: {EndTime}, Location: {Location}, Description: {Description}";
        }

        // 添加扩展功能
    }
}
