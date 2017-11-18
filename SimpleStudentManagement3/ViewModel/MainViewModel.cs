using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System;

namespace SimpleStudentManagement3.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<StudentVM> Students { get; set; }
        private StudentVM student;

        public StudentVM Student
        {
            get { return student; }
            set { student = value; RaisePropertyChanged(); }
        }

        public RelayCommand BtnStudentHinzuf�gen { get; set; }
        public RelayCommand BtnStudentEditieren { get; set; }
        public RelayCommand BtnStudentL�schen { get; set; }
        private StudentVM selectedStudent;

        public StudentVM SelectedStudent
        {
            get { return selectedStudent; }
            set { selectedStudent = value; RaisePropertyChanged(); }
        }

        public string NeuStudiengang { get; set; }
        public ObservableCollection<string> Studieng�nge { get; set; }
        public RelayCommand BtnStudiengangHinzuf�gen { get; set; }
        

        public MainViewModel()
        {
            Students = new ObservableCollection<StudentVM>();
            Studieng�nge = new ObservableCollection<string>();
            Student = new StudentVM();
            BtnStudiengangHinzuf�gen = new RelayCommand(() => Studieng�nge.Add(NeuStudiengang), () => { return NeuStudiengang != null; });
            BtnStudentHinzuf�gen = new RelayCommand(() => Students.Add(new StudentVM(Student)), () => { return Student.Vorname != null; });
            BtnStudentEditieren = new RelayCommand(StudentEditieren, () => { return selectedStudent != null; });
            BtnStudentL�schen = new RelayCommand(() => Students.Remove(selectedStudent), () => { return selectedStudent != null; });

            LoadData();
        }

        private void StudentEditieren()
        {
            Student = null;
            Student = selectedStudent;
            Students.Remove(selectedStudent);
        }

        public void LoadData()
        {
            Studieng�nge.Add("BWI");
            Studieng�nge.Add("BIW");
            Students.Add(new StudentVM("Katrin", "Vrtis", 27, "BWI", true));
            Students.Add(new StudentVM("Bernd", "Reiter", 25, "BIW", false));
        }
    }
}