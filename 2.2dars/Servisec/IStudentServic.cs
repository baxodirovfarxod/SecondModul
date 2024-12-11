using _2._2dars.Models;

namespace _2._2dars.Servisec
{
    interface IStudentServic
    {
        public Student AddStudent(Student student);
        public Student GetByID(Guid Id);
        public bool UpdateStudent(Student student);
        public bool RemoveStudent(Guid Id);
        public List<Student> GetAllStudents();
        public void AddResult(int result, Guid id);
        public void DisplayInfo(Student student);
        public Student GetStudentByLogin(string login, string password);

    }
}
