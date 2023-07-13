using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Individual_Project_4112.Models
{
    public class Student
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public BitmapImage Image { get; set; }

        public string Birthday { get; set; }
        public Double GPA { get; set; }

        public String ImagePath
        {
            get { return $"/Images/{Image}"; }
        }

        public Student(int age, string firstName, string lastName, string dateOfBirth, BitmapImage image)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            Birthday = dateOfBirth;
            Image = image;
        }
        public Student()
        {

        }
    }
}
