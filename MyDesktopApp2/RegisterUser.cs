using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyDesktopApp2
{
    class RegisterUser
    {
        public void registerUser1()
        {
            String[] DepartmentList = { "Computer Engineering", "Mechatronics", "Agricultural Science", "Maths" };

            Console.WriteLine(" Please register");
            Console.WriteLine(" Enter Your Name");
            string name = Console.ReadLine();
            Console.WriteLine(" Enter Your Age");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("The University Currently Offers the following departments");
            foreach (string department in DepartmentList)
            {
                Console.WriteLine(department);
                //displays department lists
            }

            Console.WriteLine("Enter aspiring department");
            string DepartmentField = Console.ReadLine().ToLower();
            //Enters desired Department

            switch (DepartmentField)
            {
                case "computer engineering":
                    DepartmentField = DepartmentList[0];
                    break;

                case "mechatronics":
                    DepartmentField = DepartmentList[1];
                    break;

                case "agricultural science":
                    DepartmentField = DepartmentList[2];
                    break;

                case "maths":
                    DepartmentField = DepartmentList[3];
                    break;

                default:
                    Console.WriteLine("Enter a valid department");
                    break;
            }

            Console.Clear(); //clears the previous screens and inputs

            Console.WriteLine("You are applying to the department of " + DepartmentField);
            Console.WriteLine("You will need to take a Quiz in order to be considered for this department");

            Quiz start = new Quiz(); //launches the Quiz
            double userGrade = start.Quizstart();

            Console.WriteLine("Test score is " + userGrade + "%");

            StudentDetails studentDetails = new StudentDetails()
            {
                // to initialize the StudentDetails class
                Name = name,
                Age = age,
                Score = userGrade,
                Department = DepartmentField
                //to add department
            };
            MatricNumber stud = new MatricNumber();
            if (userGrade >= 65)
            {
                Console.WriteLine("You passed!");

                // // Serialize the Person instance to JSON
                // string jsonData = JsonConvert.SerializeObject(studentDetails, Formatting.Indented);

                // // Define the path and filename where you want to save the JSON data
                // string filePath = @"database.json";

                // // Write the JSON data to the file
                // File.AppendAllText(filePath, jsonData);

                //Use the new API to write to database
                StudentDatabaseHelper helper = new StudentDatabaseHelper();
                helper.UpdateDatabase(studentDetails);
                int num = StudentDatabaseHelper.FetchLastStudent();
                var matric = stud.Generate(studentDetails.Department, num);
                Console.WriteLine("\n" + studentDetails.Name + ", Your Matric Number is: " + matric);
                Console.WriteLine("Data saved to JSON file successfully.\n");
            }
            else
            {
                Console.WriteLine("You did not pass the quiz. Application not saved.\n");
            }
        }
    }
}
