using _2._6Dars.DataAccess.Entities;
using _2._6Dars.Services.DTOs;
using _2._6Dars.Services.Enums;

namespace _2._6Dars.Services;

public interface IStudentService
{
    Guid AddStudent(CreatStudentDTO creatStudentDTO);
    Student GetStudentById(Guid id);
    void DeleteStudent(Guid studentId);
    void UpdateStudent(UpdateStudentDTO updateStudentDTO);
    List<Student> GetAllStudents();
    List<Student> GetStudentByDegree(DegreeDTO degreeDTO);
    List<Student> GetStudentByGender(GenderDTO genderDTO);
}