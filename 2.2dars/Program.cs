using _2._2dars.Models;
using _2._2dars.Servisec;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2._2dars;

internal class Program
{
    static void Main(string[] args)
    {
        StartFrontEnd();
    }
    public static void StartFrontEnd()
    {
        var option = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. Stop");
            Console.WriteLine("1. Shaxsiy kabinet");
            option = int.Parse(Console.ReadLine());
            if (option == 0)
            {
                return;
            }
            else if (option == 1)
            {
                Console.Clear();
                Console.Write("Enter login: ");
                var login = Console.ReadLine();
                Console.Write("Enter password: ");
                var password = Console.ReadLine();
                LoginFrontEnd(login, password);
            }
        }
    }
    public static void LoginFrontEnd(string login, string password)
    {
        var teacherServic = new TeacherServic();
        var studentServic = new StudentServic();
        if (login == "director" && password == "director")
        {
            Console.Clear();
            DirectorFrontEnd();
        }
        else if (teacherServic.GetTeacherByLogin(login, password) is not null)
        {
            Console.Clear();
            TeacherFrontEnd(login, password);
        }
        else if (studentServic.GetStudentByLogin(login, password) is not null)
        {
            Console.Clear();
            StudentFrontEnd(login, password);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Login yoki parol xato !");
            Console.ReadKey();
            Console.Clear();
        }
    }
    public static void DirectorFrontEnd()
    {
        var teacherServic = new TeacherServic();
        var option = 0;
        while (true)
        {
            Console.WriteLine("0. Back");
            Console.WriteLine("1. Add teacher");
            Console.WriteLine("2. Update teacher");
            Console.WriteLine("3. Delete teacher");
            Console.WriteLine("4. Get all teacher");
            option = int.Parse(Console.ReadLine());
            if (option == 0)
            {
                Console.Clear();
                break;
            }
            else if (option == 1)
            {
                Console.Clear();
                var teacher = new Teacher();
                Console.Write("Enter teacher first name: ");
                teacher.FirstName = Console.ReadLine();
                Console.Write("Enter teacher last name: ");
                teacher.LastName = Console.ReadLine();
                Console.Write("Enter teacher age: ");
                teacher.Age = int.Parse(Console.ReadLine());
                Console.Write("Enter teacher subject: ");
                teacher.Subject = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("Select techer gender: ");
                    Console.WriteLine("1. Male");
                    Console.WriteLine("2. Female");
                    option = int.Parse(Console.ReadLine());
                    if (option == 1)
                    {
                        teacher.Gender = "Male";
                        break;
                    }
                    else if (option == 2)
                    {
                        teacher.Gender = "Female";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("1 yoki 2 ni tanlang !");
                    }
                }
                Console.Write("Enter teacher login: ");
                teacher.Login = Console.ReadLine();
                Console.Write("Enter teacher password: ");
                teacher.Password = Console.ReadLine();
                teacher.Likes = 0;
                teacher.DisLikes = 0;
                var result = teacherServic.AddTeacher(teacher);
                if (result is not null)
                {
                    Console.Clear();
                    Console.WriteLine("Ustoz qo'shildi !");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Xatolik !");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else if (option == 2)
            {
                var teacher = new Teacher();
                Console.Write("Enter teacher Id: ");
                teacher.Id = Guid.Parse(Console.ReadLine());
                Console.Write("Enter teacher first name: ");
                teacher.FirstName = Console.ReadLine();
                Console.Write("Enter teacher last name: ");
                teacher.LastName = Console.ReadLine();
                Console.Write("Enter teacher age: ");
                teacher.Age = int.Parse(Console.ReadLine());
                Console.Write("Enter teacher subject: ");
                teacher.Subject = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("Select techer gender: ");
                    Console.WriteLine("1. Male");
                    Console.WriteLine("2. Female");
                    option = int.Parse(Console.ReadLine());
                    if (option == 1)
                    {
                        teacher.Gender = "Male";
                        break;
                    }
                    else if (option == 2)
                    {
                        teacher.Gender = "Female";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("1 yoki 2 ni tanlang !");
                    }
                }
                Console.Write("Enter teacher login: ");
                teacher.Login = Console.ReadLine();
                Console.Write("Enter teacher password: ");
                teacher.Password = Console.ReadLine();
                teacher.Likes = teacherServic.GetById(teacher.Id).Likes;
                teacher.DisLikes = teacherServic.GetById(teacher.Id).DisLikes;
                var result = teacherServic.UpdateTeacher(teacher);
                if (result is true)
                {
                    Console.Clear();
                    Console.WriteLine("Ustoz qo'shildi !");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Xatolik !");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else if (option == 3)
            {
                Console.Write("Enter deleted teacher id: ");
                var id = Guid.Parse(Console.ReadLine());
                var result = teacherServic.RemoveTeacher(id);
                if (result is true)
                {
                    Console.Clear();
                    Console.WriteLine("Ustoz o'chirildi !");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Xatolik !");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else if (option == 4)
            {
                var teachers = teacherServic.GetAllTeachers();
                if (teachers.Count is 0 || teachers is null)
                {
                    Console.Clear();
                    Console.WriteLine("- Ustozlar yo'q !");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    foreach (var teacher in teachers)
                    {
                        Console.Clear();
                        teacherServic.DisplayInfo(teacher);
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }
    }
    public static void TeacherFrontEnd(string login, string password)
    {
        var studentServic = new StudentServic();
        var teacherServic = new TeacherServic();
        var testServic = new TestServic();
        var teacher = teacherServic.GetTeacherByLogin(login, password);
        var option = 0;
        while (true) 
        {
            Console.Clear();
            Console.WriteLine("0. Back");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Update student");
            Console.WriteLine("3. Delete student");
            Console.WriteLine("4. Get all students");
            Console.WriteLine("5. My Info");
            Console.WriteLine("6. Add Test");
            Console.WriteLine("7. Update Test");
            Console.WriteLine("8. Delete Test");
            Console.WriteLine("9. Get all tests");
            option = int.Parse(Console.ReadLine());
            if (option == 0)
            {
                return;
            }
            else if (option == 1)
            {
                Console.Clear();
                var student = new Student();
                Console.Write("Enter first name: ");
                student.FirstName = Console.ReadLine();
                Console.Write("Enter last name: ");
                student.LastName = Console.ReadLine();
                Console.Write("Enter student age: ");
                student.Age = int.Parse(Console.ReadLine());
                Console.Write("Enter student degree: ");
                student.Degree = Console.ReadLine();
                student.Results = new List<int>();
                while (true)
                {
                    Console.WriteLine("Select student gender: ");
                    Console.WriteLine("1. Male");
                    Console.WriteLine("2. Female");
                    option = int.Parse(Console.ReadLine());
                    if (option == 1)
                    {
                        student.Gender = "Male";
                        break;
                    }
                    else if (option == 2)
                    {
                        student.Gender = "Female";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("1 yoki 2 ni tanlang !");
                    }
                }
                Console.Write("Enter student login: ");
                student.Login = Console.ReadLine();
                Console.Write("Enter student password: ");
                student.Password = Console.ReadLine();
                var result = studentServic.AddStudent(student);
                if (result is null)
                {
                    Console.Clear();
                    Console.WriteLine("Xatolik !");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Student qo'shildi !");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else if (option == 2)
            {
                var student = new Student();
                Console.Write("Enter student id: ");
                student.Id = Guid.Parse(Console.ReadLine());
                Console.Write("Enter first name: ");
                student.FirstName = Console.ReadLine();
                Console.Write("Enter last name: ");
                student.LastName = Console.ReadLine();
                Console.Write("Enter student age: ");
                student.Age = int.Parse(Console.ReadLine());
                Console.Write("Enter student degree: ");
                student.Degree = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("Select student gender: ");
                    Console.WriteLine("1. Male");
                    Console.WriteLine("2. Female");
                    option = int.Parse(Console.ReadLine());
                    if (option == 1)
                    {
                        student.Gender = "Male";
                        break;
                    }
                    else if (option == 2)
                    {
                        student.Gender = "Female";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("1 yoki 2 ni tanlang !");
                    }
                }
                Console.Write("Enter student login: ");
                student.Login = Console.ReadLine();
                Console.Write("Enter student password: ");
                student.Password = Console.ReadLine();
                student.Results = studentServic.GetByID(student.Id).Results;
                var result = studentServic.UpdateStudent(student);
                if (result is false)
                {
                    Console.Clear();
                    Console.WriteLine("Xatolik !");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Student malumoti yangilandi !");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else if (option == 3)
            {
                Console.Clear();
                Console.Write("Student Id: ");
                var id = Guid.Parse(Console.ReadLine());
                var result = studentServic.RemoveStudent(id);
                if (result is false)
                {
                    Console.Clear();
                    Console.WriteLine("Xatolik !");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Student o'chirildi !");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else if (option == 4)
            {
                var students = studentServic.GetAllStudents();
                foreach (var student in students)
                {
                    Console.Clear();
                    studentServic.DisplayInfo(student);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else if (option == 5)
            {
                Console.Clear();
                teacherServic.DisplayInfo(teacher);
                Console.ReadKey();
            }
            else if (option == 6)
            {
                var test = new Test();
                Console.Write("Enter test question: ");
                test.QuestionText = Console.ReadLine();
                Console.Write($"Enter A varyant: ");
                test.AVaryant = Console.ReadLine();
                Console.Write($"Enter B varyant: ");
                test.BVaryant = Console.ReadLine();
                Console.Write($"Enter C varyant: ");
                test.CVaryant = Console.ReadLine();
                Console.Write($"Enter correct answer: ");
                test.Answer = Console.ReadLine();
                testServic.AddTest(test);
            }
            else if (option == 7)
            {
                var test = new Test();
                Console.Write("Enter test id: ");
                test.Id = Guid.Parse(Console.ReadLine());
                Console.Write("Enter test question: ");
                test.QuestionText = Console.ReadLine();
                Console.Write($"Enter A varyant: ");
                test.AVaryant = Console.ReadLine();
                Console.Write($"Enter B varyant: ");
                test.BVaryant = Console.ReadLine();
                Console.Write($"Enter C varyant: ");
                test.CVaryant = Console.ReadLine();
                Console.Write($"Enter correct answer: ");
                test.Answer = Console.ReadLine();
                testServic.UpdateTest(test);

            }
            else if (option == 8)
            {
                Console.Write("Enter deleted text id: ");
                var id = Guid.Parse(Console.ReadLine());
                testServic.RemoveTest(id);
            }
            else if (option == 9)
            {
                var tests = testServic.GetAllTests();
                foreach (var test in tests)
                {
                    Console.Clear();
                    testServic.DisplayInfo(test);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
    public static void StudentFrontEnd(string login, string password)
    {
        var option = 0;
        var studentServic = new StudentServic();
        var testServic = new TestServic();
        var teacherServic = new TeacherServic();
        var student = studentServic.GetStudentByLogin(login, password);
        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. Back");
            Console.WriteLine("1. Solving tests");
            Console.WriteLine("2. Like or Dislike teacher");
            Console.WriteLine("3. My info");
            option = int.Parse(Console.ReadLine());
            if (option == 0)
            {
                break;
            }
            else if (option == 1)
            {
                Console.Write("Enter tests amount: ");
                var amount = int.Parse(Console.ReadLine());
                var tests = testServic.GetRandomTests(amount);
                var result = 0;
                foreach (var test in tests)
                {
                    Console.Clear();
                    Console.WriteLine($"Question: {test.QuestionText}");
                    Console.WriteLine($"A varyant: {test.AVaryant}");
                    Console.WriteLine($"B varyant: {test.BVaryant}");
                    Console.WriteLine($"C varyant: {test.CVaryant}");
                    Console.Write("Answer: ");
                    var answer = Console.ReadLine();
                    if (answer == test.Answer)
                    {
                        result++;
                    }
                }
                studentServic.AddResult(result, student.Id);
            }
            else if (option == 2)
            {
                var teachers = teacherServic.GetAllTeachers();
                if (teachers is null || teachers.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("- Ustozlar yo'q");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    foreach (var teacher in teachers)
                    {
                        Console.Clear();
                        Console.WriteLine($"First name: {teacher.FirstName}");
                        Console.WriteLine($"Last name: {teacher.LastName}");
                        Console.WriteLine($"Age: {teacher.Age}");
                        Console.WriteLine($"Subject: {teacher.Subject}");
                        Console.WriteLine();
                        Console.WriteLine("0. Continue");
                        Console.WriteLine("1. Like");
                        Console.WriteLine("2. Dislike");
                        option = int.Parse(Console.ReadLine());
                        if (option == 1)
                        {
                            teacherServic.AddLike(teacher.Id);
                        }
                        else if (option == 2)
                        {
                            teacherServic.AddDislike(teacher.Id);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                Console.Clear();
            }
            else if (option == 3)
            {
                Console.Clear();
                studentServic.DisplayInfo(student);
                Console.ReadKey();
            }
        }
    }
}
