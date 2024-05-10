using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    class TimetableService
    {
        private List<Timetable> _timetables = new List<Timetable>();

        public void AddTimetable(Timetable timetable)
        {
            if (timetable == null)
            {
                throw new ArgumentNullException(nameof(timetable), "Cannot add a null timetable.");
            }

            _timetables.Add(timetable);
            Console.WriteLine($"Timetable added successfully for user {timetable.UserId}.");
        }

        public bool RemoveTimetable(string userId)
        {
            var timetableToRemove = _timetables.Find(t => t.UserId == userId);
            if (timetableToRemove == null)
            {
                Console.WriteLine("Timetable not found.");
                return false;
            }

            _timetables.Remove(timetableToRemove);
            Console.WriteLine($"Timetable removed successfully for user {userId}.");
            return true;
        }

        public Timetable FindTimetableByUserId(string userId)
        {
            return _timetables.Find(t => t.UserId == userId);
        }

        public IEnumerable<Timetable> GetAllTimetables()
        {
            return _timetables;
        }

        public void AddCourseToTimetable(string userId, Course course)
        {
            var timetable = _timetables.Find(t => t.UserId == userId);
            if (timetable != null)
            {
                timetable.AddCourse(course);
            }
        }

        public bool RemoveCourseFromTimetable(string userId, int courseId)
        {
            var timetable = _timetables.Find(t => t.UserId == userId);
            if (timetable != null)
            {
                return timetable.RemoveCourse(courseId);
            }
            return false;
        }

        public void SetReminderForCourse(string userId, int courseId, string reminder)
        {
            var timetable = _timetables.Find(t => t.UserId == userId);
            if (timetable != null)
            {
                timetable.SetReminder(courseId, reminder);
            }
        }

        public void CancelReminderForCourse(string userId, int courseId, string reminder)
        {
            var timetable = _timetables.Find(t => t.UserId == userId);
            if (timetable != null)
            {
                timetable.CancelReminder(courseId, reminder);
            }
        }
    }
}
