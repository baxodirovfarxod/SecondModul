using _2._2dars.Models;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace _2._2dars.Servisec;

public class TestServic : ITestServic
{
    private string testFilePath;
    private List<Test> tests;
    public TestServic()
    {
        testFilePath = @"D:\C#\DataBase\Test.json";
        if (File.Exists(testFilePath) is false)
        {
            File.WriteAllText(testFilePath, "[]");
        }
        tests = GetTests();
    }
    public Test AddTest(Test test)
    {
        test.Id = Guid.NewGuid();
        tests.Add(test);
        SaveData();
        return test;
    }
    public Test GetById(Guid id)
    {
        foreach (var test in tests)
        {
            if (test.Id == id)
            {
                return test;
            }
        }

        return null;
    }
    public bool UpdateTest(Test test)
    {
        var testFromDB = GetById(test.Id);
        if (testFromDB is null)
        {
            return false;
        }
        var index = tests.IndexOf(testFromDB);
        tests[index] = test;
        SaveData();
        return true;
    }
    public bool RemoveTest(Guid id)
    {
        var testFromDB = GetById(id);
        if (testFromDB is null)
        {
            return false;
        }
        tests.Remove(testFromDB);
        SaveData();
        return true;
    }
    public List<Test> GetRandomTests(int amount)
    {
        var rand = new Random();
        var result = new List<Test>();
        if (tests.Count <= amount)
        {
            return tests;
        }
        for (var i = 0; i < amount;)
        {
            if (result.Contains(tests[i]) is false)
            {
                result.Add(tests[i]);
                i++;
            }
        }
        return result;
    }
    public List<Test> GetAllTests()
    {
        return GetTests();
    }
    public void DisplayInfo(Test test)
    {
        Console.WriteLine($"Id: {test.Id}");
        Console.WriteLine($"Test question: {test.QuestionText}");
        Console.WriteLine($"A varyant: {test.AVaryant}");
        Console.WriteLine($"B varyant: {test.BVaryant}");
        Console.WriteLine($"C varyant: {test.CVaryant}");
        Console.WriteLine($"Answer: {test.Answer}");
    }
    private List<Test> GetTests()
    {
        var testsJson = File.ReadAllText(testFilePath);
        var _tests = JsonSerializer.Deserialize<List<Test>>(testsJson);
        return _tests;
    }
    private void SaveData()
    {
        var testJson = JsonSerializer.Serialize(tests);
        File.WriteAllText(testFilePath, testJson);
    }
}
