using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace StudentBase
{
    public class StuDB : DbContext 
    {
        public StuDB()
            : base("StuDB")
        {
        }
        public DbSet<Student> Tb_stu { get; set; }

    }
}
