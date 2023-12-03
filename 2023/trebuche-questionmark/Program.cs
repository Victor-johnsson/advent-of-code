
using System.Reflection;

var executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
var projectDirectory = Path.GetFullPath(Path.Combine(executableLocation, @"..\..\.."));
var filePath = Path.Combine(projectDirectory, "map.txt");

PartOne();
PartTwo();

void PartOne()
{
    var numberString = "1234567890";

    List<int> numbers = new();
    foreach (var line in File.ReadLines(filePath))
    {
        string numberLine = string.Empty;
        foreach (var character in line)
        {
            if(numberString.Contains(character)) numberLine += character;

        }
        string nbr = numberLine[0].ToString() + numberLine[numberLine.Length - 1];
        var tempNumber = int.Parse(nbr);
        numbers.Add(tempNumber);
    }
    Console.WriteLine(numbers.Sum());

   
}


void PartTwo()
{
    var numberString = "1234567890";
    var numberWords = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
    var intArray = new int[] {1,2,3,4,5,6,7,8,9};
    List<int> numbers = new();


    foreach (var line in File.ReadLines(filePath))
    {
 

        string numberLine = string.Empty;
        for (int i = 0; i < line.Length; i++)
        {
            var substring = line.Substring(i);
            if (numberString.Contains(substring[0])) numberLine += substring[0];
            else
            {
                for (int a = 0; a < numberWords.Length; a++)
                {

                    if (substring.StartsWith(numberWords[a])) numberLine += intArray[a].ToString();

                }
            }
           

        }
        string nbr = numberLine[0].ToString() + numberLine[numberLine.Length - 1];
        var tempNumber = int.Parse(nbr);
        numbers.Add(tempNumber);

    }
    Console.WriteLine(numbers.Sum());

}
