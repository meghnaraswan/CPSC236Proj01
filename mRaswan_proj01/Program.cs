using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mRaswan_proj01
{
    enum ClassStanding //enumerations, (a value type defined by a set of named constants of the underlying integral numeric type), for the class standing 
    {
        Freshman = 0,
        Sophomore = 1,
        Junior = 2,
        Senior = 3
    }

    struct Student //creating a struct for identifying the aspects of the student
    {
        private int age; //assigning age to an integer
        private string name; //assigning name to a string
        private ClassStanding classStanding; //calling the ClassStanding function to assign classStanding to the enumeration

        public Student(string Name = "", int Age = 0, ClassStanding classStanding = ClassStanding.Freshman) //creating initial aspects for name, age, and classStanding
        {
            //using the this keyword to refer to the current instance of the class
            this.age = Age;
            this.name = Name;
            this.classStanding = classStanding;
        }

        public override String ToString() //using override to provide info about the type
        {
            return String.Format("Name: {0}, Age: {1}, Class Standing: {2}", this.name, this.age, this.classStanding); //this formats in a way so that the name, age, and then class standing will be displayed by using the indexes for each of the three categories in the list
        }

    }

    class StudentManager
    {
        private List<Student> studentList = new List<Student>();

        public StudentManager() { //creating a list
            studentList.Add(new Student("Frank", 22, ClassStanding.Senior));
            studentList.Add(new Student("Charlie", 18, ClassStanding.Freshman));
            studentList.Add(new Student("Mac", 19, ClassStanding.Sophomore));
            studentList.Add(new Student("Dennis", 20, ClassStanding.Junior));
            studentList.Add(new Student("Dee", 20, ClassStanding.Junior));
        }

        public void View() //View will display the list that is stored
        {
            int i = 0; //initialize index to 0
            foreach (Student student in studentList) //calling the Student class
            {
                Console.WriteLine(String.Format("Student #{0}: {1}", i, student.ToString())); //displaying the index number, starting with the students that are already in the list, and if added, adding the new user inputs though a foreach loop
                i++; //increment index by 1
            }
        }

        public void Add() //Add will add the user input for name, age and class standing for students
        {
            Console.Write("Name: "); //user input for name
            string name = Console.ReadLine();

            Console.Write("Age: "); //user input for age
            int age = int.Parse(Console.ReadLine()); //convert the age string to an integer

            Console.Write("Class Standing: ");
            string classStandingString = Console.ReadLine(); //user input for class standing
            ClassStanding classStanding = (ClassStanding)Enum.Parse(typeof(ClassStanding),classStandingString); //this converts string representation of the name to an enumerated object

            Student student = new Student(name, age, classStanding); //calling the student function and using the inputted name, age, and class standing to format it in this order
            studentList.Add(student); //adding the user input into the list
        }

        public void Delete() //Delete deletes a student from the index inputted by the user
        {
            Console.Write("Name the index of the list you want to delete: "); //user input for the index in the list
            int choice = int.Parse(Console.ReadLine()); //convert the choice string to an integer

            studentList.RemoveAt(choice); //removes the index by calling the list
        }

        public void Write() //Write writes the list into a file caled file.txt
        {
            string fileName = "file.txt"; //the file, file.txt, is assigned to the variable fileName
            using (StreamWriter outputFile = new StreamWriter(fileName)) // this writes the string array to a new file named "file.txt".
            {
                foreach (Student student in studentList)
                    outputFile.WriteLine(student);
                Console.WriteLine(String.Format("We have successfully written to your file: {0}", outputFile)); //tells the user the file was successfully written
            }
        }

    }

    class MainProgram
    {
        static void Main(string[] args) //main function
        {
            StudentManager sm = new StudentManager(); //assigning the StudentManager class to a variable, so it will be easier to call the class

            while (true) //infinite loop
            {
                Console.WriteLine("Do you want to V:View the list, A:Add to the list, D:Delete, W:Write to a file ,or Q:Quit? "); //ask for user input
                string option = Console.ReadLine();
                
                switch (option) //switch statement for V, A, D, W, or Q conditions
                {
                    case "V": //if user inputs 'V' or 'v'
                    case "v":
                        sm.View(); //calling the StudentManager class for the View function
                        break;
                    case "A": //if user inputs 'A' or 'a'
                    case "a":
                        sm.Add(); //calling the StudentManager class for the Add function
                        break;
                    case "D": //if user inputs 'D' or 'd'
                    case "d":
                        sm.Delete(); //calling the StudentManager class for the Delete function
                        break;
                    case "W": //if user inputs 'W' or 'w'
                    case "w":
                        sm.Write(); //calling the StudentManager class for the Write function
                        break;
                    case "Q": //if user inputs 'Q' or 'q'
                    case "q":
                        break;
                    default:
                        Console.WriteLine("This is not a valid option."); //if user inputs something other than 'V', 'v', 'A', 'a', 'D', 'd', 'W', 'w', 'Q', or 'q', tell the user that the input was invalid
                        break;
                }
                if (option == "Q" || option == "q") //program will end if user inputs 'Q' or 'q'
                    break;
            }
        }
    }
}

