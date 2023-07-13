using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Individual_Project_4112.Models;
using Individual_Project_4112.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Individual_Project_4112.ViewModels
{
    public partial class StartupWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;
        [ObservableProperty]
        public Student selectedStudent = null;

        public void CloseStartupWindow()
        {
            Application.Current.MainWindow.Close();
        }
        [RelayCommand]
        public void Message()
        {
            MessageBox.Show($"{selectedStudent.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var newVM = new AddStudentWindowVM();
            AddStudentWindow newWindow = new AddStudentWindow(newVM);
            newWindow.ShowDialog();
            if(newVM.Stdnt.FirstName != null)
            {
                students.Add(newVM.Stdnt);
            }
        }

        [RelayCommand]
        public void DeleteStudent()
        {
            if(selectedStudent != null)
            {
                MessageBox.Show($"{selectedStudent.FirstName} is Deleted successfuly.", "DELETED \a ");
                students.Remove(selectedStudent);
            }
            else
            {
                MessageBox.Show("Please select the student before delete.", "Error");


            }
        }

        [RelayCommand]
        public void EditStudent()
        {
            if(selectedStudent != null)
            {
                var oldVM = new AddStudentWindowVM(selectedStudent);
                var window = new AddStudentWindow(oldVM);

                window.ShowDialog();

                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
                students.Insert(index, oldVM.Stdnt);
            }
            else
            {
                MessageBox.Show("Please select the student", "Warning!");
            }
        }

        public StartupWindowVM()
        {
            students = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("/Images/1.png", UriKind.Relative));
            students.Add(new Student(12, "Sample", "Student", "12/1/2000", image1));
        }
    }
}
