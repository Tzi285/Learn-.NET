using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    internal class StudentController : Student
    {
        private List<Student> ListStudent = new List<Student>();
        public StudentController()
        {
            ListStudent.Add(new Student { ID = GenerateID(), Name = "Linh", Gender = "Male", Age = 18, Math = 9.5, Physics = 7.0, Chemistry = 8.0, Biology = 7.5 });
            ListStudent.Add(new Student { ID = GenerateID(), Name = "Chiến", Gender = "Female", Age = 20, Math = 8.0, Physics = 5.6, Chemistry = 9.0, Biology = 8.5 });
        }
        public int GenerateID()
        {
            int max = 1;
            if (ListStudent != null && ListStudent.Count > 0)
            {
                max = ListStudent[0].ID;
                foreach (Student sv in ListStudent)
                {
                    if (max < sv.ID)
                    {
                        max = sv.ID;
                    }
                }
                max++;
            }
            return max;
        }
        public bool IsGenderValid(string gender)
        {
            string lowerCaseGender = gender.ToLower();

            return lowerCaseGender == "male" || lowerCaseGender == "female";
        }
        public void AddStudent()
        {
            Student st = new Student();
            st.ID = GenerateID();
            
            //Name
            Console.WriteLine("Enter name of student: ");

            while(true)
            {
                st.Name = Convert.ToString(Console.ReadLine());
                if(st.Name != null)
                {
                    Console.WriteLine("Name is valid.");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid name. Please enter name again.");
                    Console.ResetColor();
                }
            }
            
            //Gender
            Console.WriteLine("Enter gender: ");

            while (true)
            {
                st.Gender = Convert.ToString(Console.ReadLine());
                if (!string.IsNullOrEmpty(st.Gender) && IsGenderValid(st.Gender))
                {
                    Console.WriteLine("Gender is valid.");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid gender. Please enter either 'Male' or 'Female'.");
                    Console.ResetColor();
                }
            }
            //Age
            Console.WriteLine("Enter student age:");

            while (true)
            {
                st.Age = Convert.ToInt32(Console.ReadLine());
                if (st.Age >= 11 && st.Age <= 50)
                {
                    Console.WriteLine("Age is valid.");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid age. Please enter age again.");
                    Console.ResetColor();
                }
            }
            //Math Score 
            Console.WriteLine("Enter student Math score: ");

            while (true)
            {
                st.Math = Convert.ToDouble(Console.ReadLine());
                if (st.Math >= 0 && st.Math <= 10)
                {
                    Console.WriteLine("Score is valid.");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid score. Please enter score again.");
                    Console.ResetColor();
                }
            }
            //Physics Score
            Console.WriteLine("Enter student Physics score: ");

            while (true)
            {
                st.Physics = Convert.ToDouble(Console.ReadLine());
                if (st.Physics >= 0 && st.Physics<= 10)
                {
                    Console.WriteLine("Score is valid.");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid score. Please enter score again.");
                    Console.ResetColor();
                }
            }
            //Chemistry Score
            Console.WriteLine("Enter student Chemistry score: ");

            while (true)
            {
                st.Chemistry = Convert.ToDouble(Console.ReadLine());
                if (st.Chemistry >= 0 && st.Chemistry <= 10)
                {
                    Console.WriteLine("Score is valid.");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid score. Please enter score again.");
                    Console.ResetColor();
                }
            }
            //Biology Score
            Console.WriteLine("Enter student Biology score: ");

            while (true)
            {
                st.Biology = Convert.ToDouble(Console.ReadLine());
                if (st.Biology >= 0 && st.Biology <= 10)
                {
                    Console.WriteLine("Score is valid.");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid score. Please enter score again.");
                    Console.ResetColor();
                }
            }

            ListStudent.Add(st);
        }

        public void DisplayListStudent(List<Student> listSt)
        {
            Console.WriteLine("{0, -5} {1, -15} {2, -7} {3, 5} {4, 5} {5, 7} {6, 7} {7, 7}",
                  "ID", "Name", "Gender", "Age", "Math", "Physics","Chemistry", "Biology");

            if (listSt != null && listSt.Count > 0)
            {
                foreach (Student st in listSt)
                {
                    Console.WriteLine("{0, -5} {1, -15} {2, -7} {3, 5} {4, 5} {5, 6} {6, 7} {7, 7}",
                                      st.ID, st.Name, st.Gender, st.Age, st.Math, st.Physics, st.Chemistry, st.Biology);
                }
            }
            Console.WriteLine();
        }

        public List<Student> GetListStudents() 
        {
            return ListStudent;
        }
    }
}
