using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int GroupId { get; set; }

        public override string ToString()
        {
            return $"Student: ID = {Id}, Name = {Name}, Age = {Age}, GroupId = {GroupId}";
        }
    }
}
