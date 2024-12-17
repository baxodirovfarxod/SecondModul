using _2._6Dars.DataAccess.Entities;
using _2._6Dars.Repositories;
using _2._6Dars.Services.DTOs;
using _2._6Dars.Services.Enums;

namespace _2._6Dars.Services;
public class StudentService : IStudentService
{
    public Guid AddStudent(CreatStudentDTO creatStudentDTO)
    {
        throw new NotImplementedException();
    }

    public void DeleteStudent(Guid studentId)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetAllStudents()
    {
        throw new NotImplementedException();
    }

    public List<Student> GetStudentByDegree(DegreeDTO degreeDTO)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetStudentByGender(GenderDTO genderDTO)
    {
        throw new NotImplementedException();
    }

    public Student GetStudentById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void UpdateStudent(UpdateStudentDTO updateStudentDTO)
    {
        throw new NotImplementedException();
    }
}
