using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    internal class StudentController : IStudentManagement
    {
        private List<Student> ListStudent = new List<Student>();
        public StudentController()
        {
            ListStudent.Add(new Student { ID = GenerateID(), Name = "Reto", Gender = "Male", Age = 18, Math = 9.5, Physics = 7.0, Chemistry = 8.0, Biology = 7.5 });
            ListStudent.Add(new Student { ID = GenerateID(), Name = "Lind", Gender = "Female", Age = 20, Math = 8.0, Physics = 5.6, Chemistry = 9.0, Biology = 8.5 });
            ListStudent.Add(new Student { ID = GenerateID(), Name = "Alice", Gender = "Female", Age = 21, Math = 7.5, Physics = 8.0, Chemistry = 9.5, Biology = 8.0 });
            ListStudent.Add(new Student { ID = GenerateID(), Name = "Bob", Gender = "Male", Age = 19, Math = 8.5, Physics = 7.0, Chemistry = 8.5, Biology = 7.0 });
            ListStudent.Add(new Student { ID = GenerateID(), Name = "Cathy", Gender = "Female", Age = 22, Math = 9.0, Physics = 6.5, Chemistry = 7.5, Biology = 8.5 });
            ListStudent.Add(new Student { ID = GenerateID(), Name = "David", Gender = "Male", Age = 20, Math = 7.0, Physics = 8.5, Chemistry = 9.0, Biology = 6.5 });
            ListStudent.Add(new Student { ID = GenerateID(), Name = "Emily", Gender = "Female", Age = 23, Math = 8.0, Physics = 7.5, Chemistry = 8.0, Biology = 9.0 });
        }
        //Create new student
        public void AddStudent()
        {
            Student st = new Student();
            st.ID = GenerateID();
            
            //Name
            Console.WriteLine("Enter name of student: ");
            st.Name = Console.ReadLine();
            while (string.IsNullOrEmpty(st.Name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid name. Please enter name again.");
                Console.ResetColor();
                st.Name = Console.ReadLine();
            }

            //Gender
            Console.WriteLine("Enter gender: ");
            st.Gender = Console.ReadLine();
            while (string.IsNullOrEmpty(st.Gender) || !IsGenderValid(st.Gender))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid gender. Please enter either 'Male' or 'Female'.");
                Console.ResetColor();
                st.Gender = Console.ReadLine();
            }
            //Age
            Console.WriteLine("Enter student age:");
            int tempAge;
            while (!int.TryParse(Console.ReadLine(), out tempAge) || tempAge < 11 || tempAge > 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid age. Please enter age again.");
                Console.ResetColor();
            }
            st.Age = tempAge;
            // Math, Physics, Chemistry, Biology Scores
            st.Math = GetValidScore("Math");
            st.Physics = GetValidScore("Physics");
            st.Chemistry = GetValidScore("Chemistry");
            st.Biology = GetValidScore("Biology");

            ListStudent.Add(st);
        }
        //Update student infomation
        public Student UpdateStudentById(int id)
        {
            Student existSt = ListStudent.Find(student => student.ID == id);

            if(existSt != null)
            {
                Console.WriteLine("Updating student with\r\n" +
                    $"ID: {existSt.ID}\r\n"+
                    $"Name: {existSt.Name}\r\n" +
                    $"Gender: {existSt.Gender}\r\n" +
                    $"Age: {existSt.Age}"
                    );

                Console.WriteLine("Enter updated name (or press Enter to keep current): ");
                string updatedName = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedName))
                {
                    existSt.Name = updatedName;
                }

                Console.WriteLine("Enter updated gender (or press Enter to keep current): ");
                string updatedGender = Console.ReadLine();
                while(string.IsNullOrEmpty(updatedGender) || !IsGenderValid(updatedGender))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid gender. Please enter either 'Male' or 'Female'.");
                    Console.ResetColor();
                    updatedGender = Console.ReadLine();
                }
                if (!string.IsNullOrEmpty(updatedGender))
                {
                    existSt.Gender = updatedGender;
                }
                Console.WriteLine("Enter updated age (or press Enter to keep current): ");
                string ageInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(ageInput))
                {
                    if (int.TryParse(ageInput, out int updatedAge) && updatedAge >= 11 && updatedAge <= 50)
                    {
                        existSt.Age = updatedAge;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid age input. Age not updated.");
                        Console.ResetColor();
                    }
                }
                return existSt;
            }
            else
            {
                Console.WriteLine("Student isn't exist.");
                return null;
            }

        }
        //List students
        public void DisplayListStudent(List<Student> listSt)
        {
            Console.WriteLine("{0, -5} {1, -15} {2, -7} {3, 5} {4, 5} {5, 7} {6, 7} {7, 7}",
                  "ID", "Name", "Gender", "Age", "Math", "Physics", "Chemistry", "Biology");

            if (listSt != null && listSt.Count > 0)
            {
                foreach (Student st in listSt)
                {
                    Console.WriteLine("{0, -5} {1, -15} {2, -7} {3, 5} {4, 5} {5, 6} {6, 7} {7, 7}",
                                      st.ID, FirstLetterToUpper(st.Name), FirstLetterToUpper(st.Gender), st.Age, st.Math, st.Physics, st.Chemistry, st.Biology);
                }
            }
            Console.WriteLine();
        }
        public List<Student> GetListStudents()
        {
            return ListStudent;
        }
        //First char upper
        public string FirstLetterToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }
        //Delete student
        public void DeleteStudentById(int id)
        {
            Student existSt = ListStudent.Find(student => student.ID == id);

            if (existSt != null)
            {
                Console.WriteLine("Are you sure to delete this student(Enter Yes / No): ");
                string yn = Console.ReadLine();
                while (string.IsNullOrEmpty(yn) || !IsYesNoValid(yn))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid confirmation. Please enter again.");
                    Console.ResetColor();
                    yn = Console.ReadLine();
                }
                if( yn.ToLower() == "yes")
                {
                    ListStudent.Remove(existSt);
                    Console.WriteLine("Delete student successfully.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Delete student failed");
                    Console.ResetColor();
                }
            }
        }
        //Search student by id
        public void SearchStudentById(int id)
        {
            Student existSt = ListStudent.Find(student => student.ID == id);

            if (existSt != null && ListStudent.Count > 0)
            {
                foreach (Student st in ListStudent)
                {
                    if(st.ID == existSt.ID)
                    {
                        Console.WriteLine("{0, -5} {1, -15} {2, -7} {3, 5} {4, 5} {5, 7} {6, 7} {7, 7}",
                              "ID", "Name", "Gender", "Age", "Math", "Physics", "Chemistry", "Biology");

                        Console.WriteLine("{0, -5} {1, -15} {2, -7} {3, 5} {4, 5} {5, 6} {6, 7} {7, 7}",
                                          st.ID, FirstLetterToUpper(st.Name), FirstLetterToUpper(st.Gender), st.Age, st.Math, st.Physics, st.Chemistry, st.Biology);
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student doesn't exist.");
                Console.ResetColor();
            }
        }
        //Search student by name
        public List<Student> SearchStudentByName(string name)
        {
            string lowerCaseName = name.ToLower();
            
            List<Student> foundStudents = new List<Student>();

            foreach (var student in ListStudent)
            {
                string lowerCaseStudentName = student.Name.ToLower();

                if (lowerCaseStudentName.Contains(lowerCaseName))
                {
                    foundStudents.Add(student);
                }
            }
            return foundStudents;
        }
        //Display list student
        public void DisplaySearchResults(List<Student> students)
        {
            if (students.Count > 0)
            {
                Console.WriteLine("{0, -5} {1, -15} {2, -7} {3, 5} {4, 5} {5, 7} {6, 7} {7, 7}",
                    "ID", "Name", "Gender", "Age", "Math", "Physics", "Chemistry", "Biology");
                foreach (Student student in students)
                {
                    Console.WriteLine("{0, -5} {1, -15} {2, -7} {3, 5} {4, 5} {5, 6} {6, 7} {7, 7}",
                        student.ID, FirstLetterToUpper(student.Name), FirstLetterToUpper(student.Gender), student.Age, student.Math, student.Physics, student.Chemistry, student.Biology);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No students found with the given name.");
                Console.ResetColor();
            }
        }
        //Calculate average student by id
        public void CalculateAverageById(int id)
        {
        }
        //Id auto increase
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
        //Check gender valid
        public bool IsGenderValid(string gender)    
        {
            string lowerCaseGender = gender.ToLower();

            return lowerCaseGender == "male" || lowerCaseGender == "female";
        }
        //Check score valid
        public double GetValidScore(string subject)
        {
            double score;

            while (true)
            {
                Console.WriteLine($"Enter student {subject} score: ");
                if (double.TryParse(Console.ReadLine(), out score) && score >= 0 && score <= 10)
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
            return score;
        }
        //Check Yes/No
        public bool IsYesNoValid(string str)
        {
            string lowerCaseGender = str.ToLower();

            return lowerCaseGender == "yes" || lowerCaseGender == "no";
        }
    }
}
