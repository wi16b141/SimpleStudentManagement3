using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStudentManagement3.ViewModel
{
    public class StudentVM : ViewModelBase
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }
        public string Studiengang { get; set; }
        public bool HatBezahlt { get; set; }

        public StudentVM() { }
        public StudentVM(StudentVM student)
        {
            Vorname = student.Vorname;
            Nachname = student.Nachname;
            Alter = student.Alter;
            Studiengang = student.Studiengang;
            HatBezahlt = student.HatBezahlt;
        }
        public StudentVM(string vorname, string nachname, int alter, string studiengang, bool hatBezahlt)
        {
            Vorname = vorname;
            Nachname = nachname;
            Alter = alter;
            Studiengang = studiengang;
            HatBezahlt = hatBezahlt;
        }

    }
}
