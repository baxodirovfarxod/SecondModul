using _2._2dars.Models;
using System.Text.Json;

namespace _2._2dars.Servisec;

public class TeacherServic
{
    private string teacherFilePath;
    private List<Teacher> teachers;
    public TeacherServic()
    {
        teacherFilePath = @"D:\C#\DataBase\Teacher.json";
        if (File.Exists(teacherFilePath) is false)
        {
            File.WriteAllText(teacherFilePath, "[]");
        }
        teachers = GetTeachers();
    }
    public Teacher AddTeacher(Teacher teacher)
    {
        teacher.Id = Guid.NewGuid();
        teachers.Add(teacher);
        SaveData();
        return teacher;
    }
    public Teacher GetById(Guid id)
    {
        foreach (var teacher in teachers)
        {
            if (teacher.Id == id)
            {
                return teacher;
            }
        }

        return null;
    }
    public bool UpdateTeacher(Teacher teacher)
    {
        var teacherFromDB = GetById(teacher.Id);
        if (teacherFromDB is null)
        {
            return false;
        }
        var index = teachers.IndexOf(teacherFromDB);
        teachers[index] = teacher;
        SaveData();

        return true;
    }
    public bool RemoveTeacher(Guid id)
    {
        var teacherFromDB = GetById(id);
        if (teacherFromDB is null)
        {
            return false;
        }
        teachers.Remove(teacherFromDB);
        SaveData();

        return true;
    }
    public List<Teacher> GetAllTeachers()
    {
        return GetTeachers();
    }
    public void DisplayInfo(Teacher teacher)
    {
        Console.WriteLine($"Id: {teacher.Id}");
        Console.WriteLine($"FirstName: {teacher.FirstName}");
        Console.WriteLine($"LastName: {teacher.LastName}");
        Console.WriteLine($"Age: {teacher.Age}");
        Console.WriteLine($"Gender: {teacher.Gender}");
        Console.WriteLine($"Subject: {teacher.Subject}");
        Console.WriteLine($"Likes: {teacher.Likes}");
        Console.WriteLine($"DisLikes: {teacher.DisLikes}");
        Console.WriteLine($"Login: {teacher.Login}");
        Console.WriteLine($"Password: {teacher.Password}");
    }
    public Teacher GetTeacherByLogin(string login, string password)
    {
        foreach (var teacher in teachers)
        {
            if (teacher.Login == login && teacher.Password == password)
            {
                return teacher;
            }
        }

        return null;
    }
    public void AddLike(Guid id)
    {
        var teacherFromDB = GetById(id);
        if (teacherFromDB is not null)
        {
            teacherFromDB.Likes++;
        }
        SaveData();
    }
    public void AddDislike(Guid id)
    {
        var teacherFromDB = GetById(id);
        if (teacherFromDB is not null)
        {
            teacherFromDB.DisLikes++;
        }
        SaveData();
    }
    private List<Teacher> GetTeachers()
    {
        var teachersJson = File.ReadAllText(teacherFilePath);
        var teachers = JsonSerializer.Deserialize<List<Teacher>>(teachersJson);
        return teachers;
    }
    private void SaveData()
    {
        var teachersJson = JsonSerializer.Serialize(teachers);
        File.WriteAllText(teacherFilePath, teachersJson);
    }
}
