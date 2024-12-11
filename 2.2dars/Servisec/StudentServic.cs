using _2._2dars.Models;
using System.Globalization;
using System.Text.Json;

namespace _2._2dars.Servisec;

public class StudentServic : IStudentServic
{
    private string studentFilePath;
    private List<Student> students;
    public StudentServic()
    {
        studentFilePath = @"D:\C#\DataBase\Student.json";
        if (File.Exists(studentFilePath) is false)
        {
            File.WriteAllText(studentFilePath, "[]");
        }
        students = GetStudents();
    }
    public Student AddStudent(Student student)
    {
        student.Id = Guid.NewGuid();
        students.Add(student);
        SaveData();
        return student;
    }
    public Student GetByID(Guid Id)
    {
        foreach (var student in students)
        {
            if (student.Id == Id)
            {
                return student;
            }
        }

        return null;
    }
    public bool UpdateStudent(Student student)
    {
        var studentFromDB = GetByID(student.Id);
        if (studentFromDB is null)
        {
            return false;
        }
        var index = students.IndexOf(studentFromDB);
        students[index] = student;
        SaveData();
        return true;
    }
    public bool RemoveStudent(Guid Id)
    {
        var studentFromDB = GetByID(Id);
        if (studentFromDB is null)
        {
            return false;
        }
        students.Remove(studentFromDB);
        SaveData();

        return true;
    }
    public List<Student> GetAllStudents()
    {
        return GetStudents();
    }
    public void AddResult(int result, Guid id)
    {
        var studentFromDB = GetByID(id);
        if (studentFromDB is null )
        {
            return;
        }
        var index = students.IndexOf(studentFromDB);
        students[index].Results.Add(result);
        SaveData();
    }
    public void DisplayInfo(Student student)
    {
        Console.WriteLine($"Id: {student.Id}");
        Console.WriteLine($"FirstName: {student.FirstName}");
        Console.WriteLine($"LastName: {student.LastName}");
        Console.WriteLine($"Age: {student.Age}");
        Console.WriteLine($"Degree: {student.Degree}");
        Console.WriteLine($"Gender: {student.Gender}");
        Console.WriteLine($"Login: {student.Login}");
        Console.WriteLine($"Password: {student.Password}");
        Console.WriteLine("Results: ");
        if (student.Results is null || student.Results.Count == 0)
        {
            Console.WriteLine("- Xali test yechlmagan !");
        }
        else
        {
            foreach (var result in student.Results)
            {
                Console.WriteLine($"- {result}");
            }
        }
    }
    public Student GetStudentByLogin(string login, string password)
    {
        foreach (var student in students)
        {
            if (student.Login == login && student.Password == password)
            {
                return student;
            }
        }

        return null;
    }
    private List<Student> GetStudents()
    {
        var studentsJson = File.ReadAllText(studentFilePath);
        var _students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
        return _students;
    }
    private void SaveData()
    {
        var studentsJson = JsonSerializer.Serialize(students);
        File.WriteAllText(studentFilePath, studentsJson);
    }
}
