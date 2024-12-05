using _2._1Dars.Services;
using System.Text;

namespace _2._1Dars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sb = new MyStringBuilder();
            sb.Append("Farxod");
            Console.WriteLine(sb.Display());
            var sb2 = new MyStringBuilder("Robiya");
            Console.WriteLine(sb2.Display());
            sb.Append(" + " + sb2.Display());
            Console.WriteLine(sb.Display());
            sb2.Insert(3, "Xadicha");
            Console.WriteLine(sb2.Display());
        }
    }
}
