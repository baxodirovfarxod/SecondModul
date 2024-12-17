using _2._6Dars.DataAccess.Entities;

namespace _2._6Dars.Repositories;
public interface IStudentRepository
{
    Guid AddStudent(Student student);
    void UpdateStudent(Student student);
    void DeleteStudent(Guid studentId);
    List<Student> GetAllStudents();
    Student GetStudentById(Guid studentId);
}