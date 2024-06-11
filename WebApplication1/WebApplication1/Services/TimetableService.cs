using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace softs
{
    public class TimetableService
    {
        private UserDbContext dbContext;

        public TimetableService(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // 增加时间表
        public bool AddTimetable(Timetable timetable)
        {
            if (timetable == null)
            {
                throw new ArgumentNullException(nameof(timetable), "不能添加空的时间表。");
            }

            dbContext.Timetables.Add(timetable);
            dbContext.SaveChanges();
            return true;
        }

        // 删除时间表
        

        public bool RemoveTimetable(int timetableId)
        {
            using (var transaction = dbContext.Database.BeginTransaction()) // 开启事务
            {
                // 1. 查找要删除的课表
                var timetableToRemove = dbContext.Timetables.SingleOrDefault(t => t.TimetableId == timetableId);
                if (timetableToRemove == null)
                {
                    return false;
                }

                // 2. 查找引用该课表的课程
                var referencingCourses = dbContext.Courses.Where(c => c.TimetableId == timetableId).ToList();

                // 3. 删除引用该课表的课程 (可添加判断是否删除成功)
                foreach (var course in referencingCourses)
                {
                    dbContext.Courses.Remove(course);
                    dbContext.SaveChanges();  // 每次删除后立刻保存更改 (可选)
                }

                // 4. 删除课表
                dbContext.Timetables.Remove(timetableToRemove);
                dbContext.SaveChanges();

                // 5. 提交事务 (所有操作成功才提交)
                transaction.Commit();
                return true;
            }
  
        }


        // 根据用户ID查找时间表
        public Timetable FindTimetableByUserId(int userId)
        {
            return dbContext.Timetables.SingleOrDefault(t => t.UserId == userId);
        }

        // 获取所有时间表
        public List<Timetable> GetAllTimetables()
        {
            return dbContext.Timetables.ToList();
        }

       

        
    }
}

