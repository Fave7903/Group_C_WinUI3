using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MyDesktopApp2
{
    class StudentDatabaseHelper
    {



        private static List<StudentDetails> LoadStudentDatabase()
        {
            string FileName = "database.json";
            if (File.Exists(FileName))
            {
                string jsonData = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<List<StudentDetails>>(jsonData);
            }

            return new List<StudentDetails>();
        }
        public void UpdateDatabase(StudentDetails studentDetail)
        {
            string FileName = "database.json";

            List<StudentDetails> studentDetails = LoadStudentDatabase();
            studentDetails.Add(studentDetail);
            string jsonData = JsonSerializer.Serialize(studentDetails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, jsonData);
        }

        public static int FetchLastStudent()
        {
            List<StudentDetails> studentDetails = LoadStudentDatabase();
            return studentDetails.Count - 1;
        }

        //     public void registerUser1()
        //     {
        //         String[] DepartmentList = { "Computer Engineering", "Mechatronics", "Agricultural Science", "Maths" };

        //         Console.WriteLine(" Please register");
        //         Console.WriteLine(" Enter Your Name");
        //         string name = Console.ReadLine();
        //         Console.WriteLine(" Enter Your Age");
        //         int age = int.Parse(Console.ReadLine());

        //         Console.WriteLine("The University Currently Offers the following departments");
        //         foreach (string department in DepartmentList)
        //         {
        //             Console.WriteLine(department);
        //             //displays department lists
        //         }

        //         Console.WriteLine("Enter aspiring department");
        //         string DepartmentField = Console.ReadLine().ToLower();
        //         //Enters desired Department

        //         switch (DepartmentField)
        //         {
        //             case "computer engineering":
        //                 DepartmentField = DepartmentList[0];
        //                 break;

        //             case "mechatronics":
        //                 DepartmentField = DepartmentList[1];
        //                 break;

        //             case "agricultural science":
        //                 DepartmentField = DepartmentList[2];
        //                 break;

        //             case "maths":
        //                 DepartmentField = DepartmentList[3];
        //                 break;

        //             default:
        //                 Console.WriteLine("Enter a valid department");
        //                 break;
        //         }

        //         Console.Clear(); //clears the previous screens and inputs

        //         Console.WriteLine("You are applying to the department of " + DepartmentField);
        //         Console.WriteLine("You will need to take a Quiz in order to be considered for this department");

        //         Quiz start = new Quiz(); //launches the Quiz
        //         double userGrade = start.Quizstart();

        //         Console.WriteLine("Test score is " + userGrade + "%");

        //         StudentDetails studentDetails = new StudentDetails()
        //         {
        //             // to initialize the StudentDetails class
        //             Name = name,
        //             Age = age,
        //             Score = userGrade,
        //             Department = DepartmentField
        //             //to add department
        //         };

        //         if (userGrade >= 65)
        //         {
        //             Console.WriteLine("You passed!");

        //             // Serialize the Person instance to JSON
        //             string jsonData = JsonConvert.SerializeObject(studentDetails, Formatting.Indented);

        //             // Define the path and filename where you want to save the JSON data
        //             string filePath = @"database.json";

        //             // Write the JSON data to the file
        //             File.AppendAllText(filePath, jsonData);

        //             Console.WriteLine("Data saved to JSON file successfully.");
        //         }
        //         else
        //         {
        //             Console.WriteLine("You did not pass the quiz. Application not saved.");
        //         }
        //     }
        // }
    }
}
