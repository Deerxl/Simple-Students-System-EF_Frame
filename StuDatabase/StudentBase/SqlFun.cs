using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBase
{
    public class SqlFun
    {
        public void Add(Student student)
        {
            using (var db = new StuDB())
            {
                db.Tb_stu.Add(student);
                db.SaveChanges();
            }
        }

        public void Remove(String id)
        {
            using (var db = new StuDB())
            {
                Student student = db.Tb_stu.SingleOrDefault(m => m.Id == id);
                db.Tb_stu.Remove(student);
                db.SaveChanges();
            }
        }

        public void Update(Student student)
        {
            using (var db = new StuDB())
            {
                db.Tb_stu.Attach(student);
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Student SearchById(string temp)
        {
            using (var db = new StuDB())
            {
                List<Student> students = db.Tb_stu
                    .Where(m => m.Id == temp)
                    .ToList();
                if (students.Count > 0)
                {
                    return students[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Student> Search(string temp)
        {
            using (var db = new StuDB())
            {
                return db.Tb_stu
                    .Where(m => m.Id == temp || m.Name == temp || m.Sex == temp 
                    || m.Development  == temp || m.Major == temp || m.TheYearEnterSchool == temp)
                    .ToList();
            }
        }

        public List<Student> Queue()
        {
            using (var db = new StuDB())
            {
                return db.Tb_stu.ToList<Student>();
            }
        }
    }
}
