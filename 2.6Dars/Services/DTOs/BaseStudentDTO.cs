using _2._6Dars.DataAccess.Enums;

namespace _2._6Dars.Services.DTOs;

public class BaseStudentDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
    public Degree Degree { get; set; }
}
