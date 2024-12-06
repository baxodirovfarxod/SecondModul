using _2._2dars.Api.Models;
using _2._2dars.Api.Services;

namespace _2._2dars.Api;
internal class Program
{
    private static string student1UserName = "student1";
    private static string student1Password = "student1";

    private static string student2UserName = "student2";
    private static string student2Password = "student2";

    private static string teacherUserName = "teacher";
    private static string teacherPassword = "teacher";

    private static string directorUserName = "director";
    private static string directorPassword = "director";
    static void Main(string[] args)
    {
        StartFrontend();    
    }

    public static void StartFrontend()
    {
        int option;
        while (true)
        {
            Console.WriteLine("0. Stop");
            Console.WriteLine("1. Shaxsiy kabinet");
            Console.Write("Enter: ");
            option = int.Parse(Console.ReadLine());
            if (option == 0)
            {
                break;
            }
            // Shaxsiy Kabinet
            else if (option == 1)
            {
                Console.Clear();
                Console.WriteLine("0. Back");
                Console.WriteLine("1. Director");
                option = int.Parse(Console.ReadLine());
                if (option == 0)
                {
                    Console.Clear();
                }
                else if (option == 1)
                {
                    Console.Write("Enter login: ");
                    var login = Console.ReadLine();
                    Console.Write("Enter password: ");
                    var password = Console.ReadLine();
                    if (login == directorUserName && password == directorPassword)
                    {
                        DirectorCabinet();
                    }
                }
            }
        }
    }
    public static void DirectorCabinet()
    {
        Console.Clear();
        int option;
        var teacherservic = new TeacherServic();
        while (true)
        {
            Console.WriteLine("0. Back");
            Console.WriteLine("1. Add Teacher");
            option = int.Parse(Console.ReadLine());
            if (option == 0)
            {
                Console.Clear();
                break;
            }
            else if (option == 1)
            {
                var teacher = new Teacher();
                Console
            }
        }
    }
}
