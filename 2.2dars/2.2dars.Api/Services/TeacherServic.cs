using _2._2dars.Api.Models;
using System.Text.Json;

namespace _2._2dars.Api.Services
{
    public class TeacherServic
    {
        private string teacherFilePath;
        public TeacherServic()
        {
            teacherFilePath = "../../../Data/Students.json";
            if (File.Exists(teacherFilePath) is false)
            {
                File.WriteAllText(teacherFilePath, "[]");
            }
        }
        public Teacher AddTeacher(Teacher teacher)
        {
            teacher.Id = Guid.NewGuid();
            var teachers = GetTeachers();
            teachers.Add(teacher);
            SaveData(teachers);
            return teacher;
        }
        public Teacher GetById(Guid teacherId)
        {
            var teachers = GetTeachers();
            foreach (var teacher in teachers)
            {
                if (teacher.Id == teacherId)
                {
                    return teacher;
                }
            }

            return null;
        }
        public bool DeleteTeacher(Guid teacherId)
        {
            var teachers = GetTeachers();
            var teacherFromDb = GetById(teacherId);
            if (teacherFromDb is null)
            {
                return false;
            }

            teachers.Remove(teacherFromDb);
            SaveData(teachers);
            return true;
        }
        public bool UpdateTeacher(Teacher teacher)
        {
            var teachers = GetTeachers();
            var studentFromDb = GetById(teacher.Id);
            if (studentFromDb is null)
            {
                return false;
            }

            var index = teachers.IndexOf(teacher);
            teachers[index] = teacher;
            SaveData(teachers);
            return true;
        }
        public List<Teacher> GetAllStudents()
        {
            return GetTeachers();
        }
        private void SaveData(List<Teacher> teachers)
        {
            var teachersJson = JsonSerializer.Serialize(teachers);
            File.WriteAllText(teacherFilePath, teachersJson);
        }
        private List<Teacher> GetTeachers()
        {
            var teachersJson = File.ReadAllText(teacherFilePath);
            var teachers = JsonSerializer.Deserialize<List<Teacher>>(teachersJson);
            return teachers;
        }
    }
}
