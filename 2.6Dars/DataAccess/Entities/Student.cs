using _2._6Dars.DataAccess.Enums;

namespace _2._6Dars.DataAccess.Entities;
public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }
    public Degree Degree { get; set; }  
}
