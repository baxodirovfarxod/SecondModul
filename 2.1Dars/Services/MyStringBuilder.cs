namespace _2._1Dars.Services;

public class MyStringBuilder
{
    private char[] text;
    private int capacity;
    private int startIndex;
    public MyStringBuilder()
    {
        capacity = 16;
        startIndex = 0;
        text = new char[capacity];
    }
    public MyStringBuilder(int length)
    {
        capacity = length;
        startIndex = 0;
        text = new char[capacity];
    }
    public MyStringBuilder(string stringValue)
    {
        startIndex = 0;
        capacity = 16;
        text = new char[capacity];
        FillList(stringValue, startIndex);
        startIndex += stringValue.Length;
    }
    public void Append(string newText)
    {
        FillList(newText, startIndex);
        startIndex += newText.Length;
    }
    public void Insert(int index, string newText)
    {
        if (index < 0 || index > startIndex || newText == string.Empty)
        {
            Console.WriteLine("Xato !");
        }
        else
        {
            if (startIndex + newText.Length > capacity)
            {
                ResizeCapacity(newText.Length);
            }
            else
            {
                for (var i = startIndex; i >= index; i--)
                {
                    text[i + newText.Length] = text[i];
                }

                for (int i = 0; i < newText.Length; i++)
                {
                    text[index + i] = newText[i];
                }
                startIndex += newText.Length;
            }
        }
    }
    public string Display()
    {
        return new string(text, 0, startIndex);
    }
    public char[] FillList(string newText, int startIndex)
    {
        if (capacity - startIndex < newText.Length)
        {
            ResizeCapacity(newText.Length);
        }

        foreach (var character in newText)
        {
            text[startIndex++] = character;
        }
        return text;
    }
    public void ResizeCapacity(int requiredCapacity)
    {
        while (capacity - startIndex < requiredCapacity)
        {
            capacity *= 2;
        }

        var tempArray = new char[capacity];
        for (var i = 0; i <= startIndex; i++)
        {
            tempArray[i] = text[i];
        }
        text = tempArray;
    }
}
