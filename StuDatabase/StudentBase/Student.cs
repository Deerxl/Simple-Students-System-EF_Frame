using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentBase
{
    public class Student
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string TheYearEnterSchool { get; set; }
        public string Major { get; set; }
        public string Development { get; set; }

        public Student()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Student(string id, string name, string sex, string theYearEnterSchool, string major, string development)
        {
            Id = id;
            Name = name;
            Sex = sex;
            TheYearEnterSchool = theYearEnterSchool;
            Major = major;
            Development = development;
        }

    }
}
