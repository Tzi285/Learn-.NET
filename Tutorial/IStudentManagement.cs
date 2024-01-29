using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    internal interface IStudentManagement
    {
        void AddStudent();
        void DisplayListStudent(List<Student> students);
        Student UpdateStudentById(int id);
        void DeleteStudentById(int id);
        List<Student> GetListStudents();
        void SearchStudentById(int id);
        List<Student> SearchStudentByName(string? name);
        void DisplaySearchResults(List<Student> students);
    }
}
