using _2._2dars.Models;

namespace _2._2dars.Servisec;
interface ITeacherServic
{
    Teacher AddTeacher(Teacher teacher);
    Teacher GetById(Guid id);
    bool UpdateTeacher(Teacher teacher);
    bool RemoveTeacher(Guid id);
    List<Teacher> GetAllTeachers();
    void DisplayInfo(Teacher teacher);
    Teacher GetTeacherByLogin(string login, string password);
    void AddLike(Guid id);
    void AddDislike(Guid id);
}