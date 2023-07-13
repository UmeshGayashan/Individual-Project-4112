using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Individual_Project_4112.Models;
using Microsoft.Win32;

namespace Individual_Project_4112.ViewModels
{
    public partial class AddStudentWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string birthday;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public BitmapImage selectedImage;

        public Student Stdnt { get; private set; }
        public AddStudentWindowVM(Student st)
        {
            Stdnt = st;
            firstname = Stdnt.FirstName;
            lastname = Stdnt.LastName;
            age = Stdnt.Age;
            gpa = Stdnt.GPA;
            birthday = Stdnt.Birthday;
            selectedImage = Stdnt.Image;
        }

        public AddStudentWindowVM()
        {
            
        }

        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.Multiselect = false;
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Image successfuly uploded!", "Successfull");
            }
        }
        public Action CloseAction { get; internal set; }
        [RelayCommand]
        public void Save()
        {
            if (gpa < 0.0 || gpa > 4.0)
            {
                MessageBox.Show("GPA value must be between 0 and 4.", "Error");
                return;
            }
<<<<<<< HEAD
            if(age>50)
            {
                MessageBox.Show("Age must be below 50", "Error");
                return;
            }
=======
>>>>>>> 85a97f529e9b231ed8d95f581cdde1f679049760
            if (Stdnt == null)
            {
                Stdnt = new Student()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    Birthday = birthday,
                    Image = selectedImage,
                    GPA = gpa
                };
            }
            else
            {
                Stdnt.FirstName = firstname;
                Stdnt.LastName = lastname;
                Stdnt.Age = age;
                Stdnt.GPA = gpa;
                Stdnt.Image = selectedImage;
                Stdnt.Birthday = birthday;
            }
            if (Stdnt.FirstName != null)
            {
                CloseAction();
            }
            Application.Current.MainWindow.Show();
        }
    }
}
