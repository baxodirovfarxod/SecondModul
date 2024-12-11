using _2._2dars.Models;

namespace _2._2dars.Servisec;
interface ITestServic
{
    Test AddTest(Test test);
    Test GetById(Guid id);
    bool UpdateTest(Test test);
    bool RemoveTest(Guid id);
    List<Test> GetRandomTests(int amount);
    List<Test> GetAllTests();
    void DisplayInfo(Test test);
}
