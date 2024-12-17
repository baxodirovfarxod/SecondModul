using _2._6Dars.DataAccess.Entities;
using System.Text.Json;

namespace _2._6Dars.Repositories;
public class StudentRepository : IStudentRepository
{
    private readonly string _path;
    private List<Student> _students;
    public StudentRepository()
    {
        _path = @"D:\C#\SecondModul\2.6Dars\DataAccess\Data\Students.json";
        if (File.Exists(_path) is false)
        {
            File.WriteAllText(_path, "[]");
        }

        _students = ReadAllStudents();
    }
    public Guid AddStudent(Student student)
    {
        _students.Add(student);
        SaveData();
        return student.Id;
    }
    public void DeleteStudent(Guid studentId)
    {
        var student = GetStudentById(studentId);
        _students.Remove(student);
        SaveData();
    }
    public List<Student> GetAllStudents()
    {
        return _students;
    }
    public Student GetStudentById(Guid studentId)
    {
        foreach (var student in _students) 
        {
            if (student.Id == studentId)
            {
                return student;
            }
        }

        throw new Exception($"{studentId} lik student bazada yo'q");
    }
    public void UpdateStudent(Student student)
    {
        var _student = GetStudentById(student.Id);
        var index = _students.IndexOf(_student);
        _students[index] = student;
        SaveData();
    }
    private void SaveData()
    {
        var studentsJson = JsonSerializer.Serialize(_students);
        File.WriteAllText(_path, studentsJson);
    }
    private List<Student> ReadAllStudents()
    {
        var studentsJson = File.ReadAllText(_path);
        var students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
        return students;
    }
}
