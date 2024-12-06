using _2._2dars.Api.Models;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace _2._2dars.Api.Services
{
    public class TestService
    {
        private string testFilePath;
        public TestService()
        {
            testFilePath = "../../../Data/Test.json";
            if (File.Exists(testFilePath) is false)
            {
                File.WriteAllText(testFilePath, "[]");
            }
        }
        public Test AddTest(Test test)
        {
            test.Id = Guid.NewGuid();
            var tests = GetTests();
            tests.Add(test);
            SaveTest(tests);
            return test;
        }
        public Test GetById(Guid Id)
        {
            var tests = GetTests();
            foreach (var test in tests)
            {
                if (test.Id == Id)
                {
                    return test;
                }
            }

            return null;
        }
        public bool UpdateTest(Test test)
        {
            var testFromFile = GetById(test.Id);
            if (testFromFile is null)
            {
                return false;
            }
            var tests = GetTests();
            var index = tests.IndexOf(testFromFile);
            tests[index] = test;
            SaveTest(tests);

            return true;
        }
        public bool DeleteTest(Guid Id)
        {
            var testFromFile = GetById(Id);
            if (testFromFile is null)
            {
                return false;
            }

            var tests = GetTests();
            tests.Remove(testFromFile);
            SaveTest(tests);
            return true;
        }
        public List<Test> GetAllTests()
        {
            return GetTests();
        }
        public List<Test> GetRandomTest(int amount)
        {
            var tests = GetTests();
            var random = new Random();
            var randomTests = new List<Test>();
            for (var i = 0; i < amount; i++)
            {
                var randomIndex = random.Next(0, tests.Count);
                randomTests.Add(tests[randomIndex]);
            }

            return randomTests;
        }
        public int GetAmountTests()
        {
            return GetTests().Count;
        }
        private List<Test> GetTests()
        {
            var testjson = File.ReadAllText(testFilePath);
            var tests = JsonSerializer.Deserialize<List<Test>>(testjson);
            return tests;
        }
        private void SaveTest(List<Test> tests)
        {
            var testJson = JsonSerializer.Serialize(tests);
            File.WriteAllText(testFilePath, testJson);
        }
    }
}
