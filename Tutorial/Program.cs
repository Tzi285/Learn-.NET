using System.Collections.Generic;
using Tutorial;

internal class Program
{
    public static void Display()
    {
        Console.WriteLine("--------MENU--------");
        Console.WriteLine("1. Display list students.\r\n" +
            "2. Add student.\r\n" +
            "3. Update student infomation by ID.\r\n" +
            "4. Delete student by ID.\r\n" +
            "5. Search student by name.\r\n" +
            "6. Sort students by name.\r\n" +
            "7. Calculate test average and academic performance.\r\n" +
            "0. Out program");
    }

    private static void Main(string[] args)
    {
        StudentController stCtrl = new StudentController();
        while(true)
        {
            Program.Display();
            Console.Write("Please enter option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (option)
            {
                case 0:
                    Console.WriteLine("End program");
                    return;
                case 1:
                    stCtrl.DisplayListStudent(stCtrl.GetListStudents());
                    Console.WriteLine("");
                    break;
                case 2:
                    stCtrl.AddStudent();

                    Console.WriteLine("Add student successfully.");
                    Console.WriteLine("");
                    break;
                case 3:
                    stCtrl.DisplayListStudent(stCtrl.GetListStudents());
                    Console.WriteLine("");
                    Console.Write("Enter Id of Student you want to update infomation: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());

                    stCtrl.UpdateStudentById(updateId);

                    Console.WriteLine("Update student successfully.");
                    Console.WriteLine("");
                    break;
                case 4:
                    stCtrl.DisplayListStudent(stCtrl.GetListStudents());
                    Console.WriteLine();
                    Console.Write("Enter Id of Student you want to delete: ");
                    int deleteId = Convert.ToInt32(Console.ReadLine());

                    stCtrl.DeleteStudentById(deleteId);

                    Console.WriteLine();
                    break;
                case 5:
                    Console.Write("Enter Id of Student you want to search: ");
                    int searchId = Convert.ToInt32(Console.ReadLine());

                    stCtrl.SearchStudentById(searchId);

                    Console.WriteLine();
                    break;
                case 6:
                    break;
                case 7:
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }
}