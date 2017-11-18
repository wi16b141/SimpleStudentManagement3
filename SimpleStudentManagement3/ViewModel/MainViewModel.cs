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

        public RelayCommand BtnStudentHinzufügen { get; set; }
        public RelayCommand BtnStudentEditieren { get; set; }
        public RelayCommand BtnStudentLöschen { get; set; }
        private StudentVM selectedStudent;

        public StudentVM SelectedStudent
        {
            get { return selectedStudent; }
            set { selectedStudent = value; RaisePropertyChanged(); }
        }

        public string NeuStudiengang { get; set; }
        public ObservableCollection<string> Studiengänge { get; set; }
        public RelayCommand BtnStudiengangHinzufügen { get; set; }
        

        public MainViewModel()
        {
            Students = new ObservableCollection<StudentVM>();
            Studiengänge = new ObservableCollection<string>();
            Student = new StudentVM();
            BtnStudiengangHinzufügen = new RelayCommand(() => Studiengänge.Add(NeuStudiengang), () => { return NeuStudiengang != null; });
            BtnStudentHinzufügen = new RelayCommand(() => Students.Add(new StudentVM(Student)), () => { return Student.Vorname != null; });
            BtnStudentEditieren = new RelayCommand(StudentEditieren, () => { return selectedStudent != null; });
            BtnStudentLöschen = new RelayCommand(() => Students.Remove(selectedStudent), () => { return selectedStudent != null; });

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
            Studiengänge.Add("BWI");
            Studiengänge.Add("BIW");
            Students.Add(new StudentVM("Katrin", "Vrtis", 27, "BWI", true));
            Students.Add(new StudentVM("Bernd", "Reiter", 25, "BIW", false));
        }
    }
}