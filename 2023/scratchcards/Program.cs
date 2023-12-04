using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

var executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
var projectDirectory = Path.GetFullPath(Path.Combine(executableLocation, @"..\..\.."));
var filePath = Path.Combine(projectDirectory, "scratchcards.txt");

var scratchcards = File.ReadAllLines(filePath);

PartTwo(scratchcards);

static void PartOne(string[] scratchcards)
{
    var total = scratchcards.Length;
    foreach (var card in scratchcards)
    {
        var split = card.Split(" ");
        split = split.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        var cardnumber = split[1][..^1];
        var breakpoint = split.ToList().FindIndex(i => i == "|");
        var winningNumbers = split[2..breakpoint].ToList().Select(x => int.Parse(x)).ToList();
        var myNumbers = split[(breakpoint + 1)..^0].ToList().Select(x =>
        {
            if (x.Equals("")) return -1;

            return int.Parse(x);
        }).ToList();

        var matches = myNumbers.Intersect(winningNumbers).Count();

        var points = Math.Pow(2, matches - 1);
        total += Convert.ToInt32(points);
    }

    // Console.WriteLine($"Part One: {total}");

}


void PartTwo(string[] scratchcards)
{
    var matchesArray = new List<int>();
    var dict = new int[scratchcards.Length];
    var total = scratchcards.Length;
    int index = 0;
    foreach (var card in scratchcards)
    {
        dict[index] = 1;
        index++;
        var split = card.Split(" ");
        split = split.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        var cardnumber = split[1][..^1];
        var breakpoint = split.ToList().FindIndex(i => i == "|");
        var winningNumbers = split[2..breakpoint].ToList().Select(x => int.Parse(x)).ToList();
        var myNumbers = split[(breakpoint + 1)..^0].ToList().Select(x =>
        {
            if (x.Equals("")) return -1;

            return int.Parse(x);
        }).ToList();

        var matches = myNumbers.Intersect(winningNumbers).Count();
        matchesArray.Add(matches);

    }
    total = matchesArray.Count;
    for (int i = 0; i < matchesArray.Count; i++)
    {
        var matches = matchesArray[i];
        var startindex = i + 1;
        for (int j = startindex; j < matches + startindex; j++)
        {
            if (j >= matchesArray.Count) break;

            dict[j] += dict[startindex - 1];

        }




    }

    Console.WriteLine(dict.Sum());
}



